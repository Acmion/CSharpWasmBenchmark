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
        public static string VersionDirectory { get; } = "net5.0";

        public static string BenchmarkingName { get; } = "Benchmarking";
        public static string CSharpRuntimeName { get; } = "CSharpRuntime";
        public static string CSharpWasmAotName { get; } = "CSharpWasmAot";
        public static string CSharpWasmInterpretedName { get; } = "CSharpWasmInterpreted";
        public static string CSharpWasmBenchmarkName { get; } = "CSharpWasmBenchmark";
        public static string JavaScriptName { get; } = "JavaScript";

        public static string BenchmarkingRootUrl { get; } = "/" + BenchmarkingName;
        public static string BenchmarkingDataUrl { get; } = BenchmarkingRootUrl + "/Data";
        public static string BenchmarkingDataCSharpRuntimeUrl { get; } = BenchmarkingDataUrl + "/" + CSharpRuntimeName;
        public static string BenchmarkingDataCSharpWasmAotUrl { get; } = BenchmarkingDataUrl + "/" + CSharpWasmAotName;
        public static string BenchmarkingDataCSharpWasmInterpretedUrl { get; } = BenchmarkingDataUrl + "/" + CSharpWasmInterpretedName;
        public static string BenchmarkingDataJavaScriptUrl { get; } = BenchmarkingDataUrl + "/JavaScript";

        public static string CSharpRuntimeRootUrl { get; } = "/" + CSharpRuntimeName;
        public static string CSharpWasmAotRootUrl { get; } = "/" + CSharpWasmAotName;
        public static string CSharpWasmInterpretedRootUrl { get; } = "/" + CSharpWasmInterpretedName;
        public static string CSharpWasmBenchmarkAnalyzerRootUrl { get; } = "/";

        public static string RootPath { get; } = GetSolutionRootPath();
        public static string BenchmarkingPath { get; } = RootPath + BenchmarkingRootUrl;
        public static string BenchmarkingDataPath { get; } = RootPath + BenchmarkingDataUrl;
        public static string BenchmarkingDataCSharpRuntimePath { get; } = RootPath + BenchmarkingDataCSharpRuntimeUrl;
        public static string BenchmarkingDataCSharpWasmAotPath { get; } = RootPath + BenchmarkingDataCSharpWasmAotUrl;
        public static string BenchmarkingDataCSharpWasmInterpretedPath { get; } = RootPath + BenchmarkingDataCSharpWasmInterpretedUrl;
        public static string BenchmarkingDataJavaScriptPath { get; } = RootPath + BenchmarkingDataJavaScriptUrl;

        public static string CSharpRuntimePath { get; } = RootPath + CSharpRuntimeRootUrl;
        public static string CSharpWasmAotPath { get; } = RootPath + CSharpWasmAotRootUrl;
        public static string CSharpWasmInterpretedPath { get; } = RootPath + CSharpWasmInterpretedRootUrl;
        public static string CSharpWasmBenchmarkAnalyzerPath { get; } = RootPath + "/" + CSharpWasmBenchmarkName;

        public static bool IsDebug { get; } = GetIsDebug();
        public static string BuildConfiguration { get; } = GetBuildConfiguration();

        public static string CSharpWasmAotDistUrl { get; } = CSharpWasmAotRootUrl + "/bin/" + BuildConfiguration + "/" + VersionDirectory + "/dist";
        public static string CSharpWasmInterpretedDistUrl { get; } = CSharpWasmInterpretedRootUrl + "/bin/" + BuildConfiguration + "/" + VersionDirectory + "/dist";

        public static string CSharpWasmAotIndexHtmlUrl { get; } = CSharpWasmAotDistUrl + "/index.html";
        public static string CSharpWasmInterpretedIndexHtmlUrl { get; } = CSharpWasmInterpretedDistUrl + "/index.html";

        public static string CSharpWasmAotIndexHtmlPath { get; } = RootPath + CSharpWasmAotIndexHtmlUrl;
        public static string CSharpWasmInterpretedIndexHtmlPath { get; } = RootPath + CSharpWasmInterpretedIndexHtmlUrl;


        public static void Main(string[] args)
        {
            if (IsDebug) 
            {
                foreach (var bc in BenchmarkCategory.All) 
                {
                    foreach (var b in bc.Benchmarks) 
                    {
                    }
                }
            }

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


        private static string GetSolutionRootPath([CallerFilePath] string filePath = "")
        {
            return Path.GetDirectoryName(Path.GetDirectoryName(filePath))!.Replace('\\', '/');
        }

        private static bool GetIsDebug() 
        {
            var isDebug = false;
#if DEBUG
            isDebug = true;
#endif
            return isDebug;
        }

        private static string GetBuildConfiguration() 
        {
            return IsDebug ? "Debug" : "Release";
        }
    }
}
