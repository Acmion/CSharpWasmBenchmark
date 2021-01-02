onmessage = function (e)
{
    var benchmarkCategoryJson = CSharp.CallMethod("CSharpWasmAot.Program:RunBenchmarkCategory", [e.data]);
    window.top.postMessage(benchmarkCategoryJson);
};