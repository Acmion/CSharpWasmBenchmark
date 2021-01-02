using Acmion.CshtmlComponent;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpWasmBenchmark
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages().AddRazorRuntimeCompilation();

            // CshtmlComponent configuration
            services.AddScoped<ICshtmlComponentTracker, CshtmlComponentTracker>();
            services.AddScoped<ITagHelperComponent, CshtmlComponentInjectionContentHandler>();
            services.AddScoped<ICshtmlComponentInjectionContentStore, CshtmlComponentInjectionContentStore>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            ServeStaticFiles(app, Program.BenchmarkingPath, Program.BenchmarkingRootUrl);
            ServeStaticFiles(app, Program.CSharpRuntimePath, Program.CSharpRuntimeRootUrl);
            ServeStaticFiles(app, Program.CSharpWasmAotPath, Program.CSharpWasmAotRootUrl);
            ServeStaticFiles(app, Program.CSharpWasmInterpretedPath, Program.CSharpWasmInterpretedRootUrl);

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }

        private void ServeStaticFiles(IApplicationBuilder app, string directoryPath, string url) 
        {
            // Serves the files from "directoryPath" under the url "url".

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(directoryPath),
                RequestPath = url,
                OnPrepareResponse = ctx =>
                {
                    var headers = ctx.Context.Response.GetTypedHeaders();
                    headers.CacheControl = new CacheControlHeaderValue
                    {
                        Public = true,
                        MaxAge = TimeSpan.FromSeconds(10)
                    };
                },
                ServeUnknownFileTypes = true
            });
        }
    }
}
