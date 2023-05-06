using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Benchmarking.Core
{
    // NOTE: Using System.Text.Json threw some error when using AOT.


    public record BenchmarkData(string CategoryName, int IterationCount, IEnumerable<BenchmarkInstanceData> BenchmarkInstanceData) 
    {
        public string ToJson() 
        {
            var benchmarkInstanceDataJson = string.Join(", ", BenchmarkInstanceData.Select(bid => bid.ToJson()));

            return $@"{{ ""{nameof(CategoryName)}"": ""{CategoryName}"", ""{nameof(IterationCount)}"": {IterationCount}, ""{nameof(BenchmarkInstanceData)}"": [ {benchmarkInstanceDataJson} ] }}";
        }
    }

    public record BenchmarkInstanceData(string BenchmarkName, string InitializationDescription, string BenchmarkDescription, string ParameterDescription,
                                        string ResultDescription, IEnumerable<BenchmarkExecuteDataPoint> DataPoints)
    {
        public string ToJson() 
        {
            var dataPointsJson = string.Join(", ", DataPoints.Select(dp => dp.ToJson()));

            return $@"{{ ""{nameof(BenchmarkName)}"": ""{BenchmarkName}"", ""{nameof(InitializationDescription)}"": ""{InitializationDescription}"", ""{nameof(BenchmarkDescription)}"": ""{BenchmarkDescription}"", ""{nameof(ParameterDescription)}"": ""{ParameterDescription}"", ""{nameof(ResultDescription)}"": ""{ResultDescription}"", ""{nameof(DataPoints)}"": [ {dataPointsJson} ] }}";
        }
    }

    public record BenchmarkExecuteDataPoint(object ParameterValue, double ElapsedMilliseconds, object Result) 
    {
        public string ToJson() 
        {
            return $@"{{ ""{nameof(ParameterValue)}"": {ParameterValue}, ""{nameof(ElapsedMilliseconds)}"": {ElapsedMilliseconds.ToString(CultureInfo.InvariantCulture)}, ""{nameof(Result)}"": ""{Result}"" }}";
        }
    }
}
