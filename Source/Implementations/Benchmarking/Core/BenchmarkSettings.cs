using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Benchmarking
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
