using System.IO;
using System.Runtime.CompilerServices;

namespace Benchmarking.Core
{
    public static class BenchmarkSettings
    {
        public static string BenchmarkingDataDirectoryPath { get; } = GetBenchmarkingRootPath() + "/Data";

        private static string GetBenchmarkingRootPath([CallerFilePath] string filePath = "")
        {
            return Path.GetDirectoryName(filePath)!.Replace('\\', '/');
        }
    }
}
