using Benchmarking;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CSharpWasmBenchmark
{
    public class Program
    {
        public static string RootPath { get; } = GetRootPath();

        // Virtual URLs. These URLs will be mapped to certain paths in Startup.cs.
        public static string DataRootUrl { get; } = "/Data";
        public static string BenchmarkingRootUrl { get; } = "/Benchmarking";
        public static string CSharpWasmAotBlazorRootUrl { get; } = "/CSharpWasmAotBlazor";
        public static string CSharpWasmInterpretedBlazorRootUrl { get; } = "/CSharpWasmInterpretedBlazor";

        // Actual file paths. The virtual URLs will be mapped to these.
        public static string DataPath { get; } = RootPath + "../../Data";
        public static string BenchmarkingPath { get; } = RootPath + "../Implementations/Benchmarking";
        public static string CSharpWasmAotBlazorPath { get; } = RootPath + "../Implementations/CSharpWasmAotBlazor";
        public static string CSharpWasmInterpretedBlazorPath { get; } = RootPath + "../Implementations/CSharpWasmInterpretedBlazor";

        // Virtual URLs to the index.html files of the Blazor projects.
        public static string CSharpWasmAotBlazorIndexHtmlUrl { get; } = "/CSharpWasmAotBlazor/bin/Release/net6.0/publish/wwwroot/index.html";
        public static string CSharpWasmInterpretedBlazorIndexHtmlUrl { get; } = "/CSharpWasmInterpretedBlazor/bin/Release/net6.0/publish/wwwroot/index.html";

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


        private static string GetRootPath([CallerFilePath] string filePath = "")
        {
            return Path.GetDirectoryName(filePath)!.Replace('\\', '/') + "/";
        }
    }
}
