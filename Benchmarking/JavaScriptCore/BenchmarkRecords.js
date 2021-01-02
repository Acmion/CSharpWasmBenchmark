class BenchmarkData
{
    constructor(categoryName, iterationCount, benchmarkInstanceData)
    {
        this.CategoryName = categoryName;
        this.IterationCount = iterationCount;
        this.BenchmarkInstanceData = benchmarkInstanceData;
    }

    ToJson()
    {
        return JSON.stringify(this);
    }
}

class BenchmarkInstanceData
{
    constructor(benchmarkName, initializationDescription, benchmarkDescription, parameterDescription, resultDescription, dataPoints)
    {
        this.BenchmarkName = benchmarkName;
        this.InitializationDescription = initializationDescription;
        this.BenchmarkDescription = benchmarkDescription;
        this.ParameterDescription = parameterDescription;
        this.ResultDescription = resultDescription;
        this.DataPoints = dataPoints;
    }

    ToJson()
    {
        return JSON.stringify(this);
    }
}

class BenchmarkExecuteDataPoint
{
    constructor(parameterValue, elapsedMilliseconds, result)
    {
        this.ParameterValue = parameterValue;
        this.ElapsedMilliseconds = elapsedMilliseconds;
        this.Result = result;
    }

    ToJson()
    {
        return JSON.stringify(this);
    }
}