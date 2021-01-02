onmessage = function (e)
{
    var benchmarkCategoryJson = CSharp.CallMethod("CSharpWasmInterpreted.Program:RunBenchmarkCategory", [e.data]);
    window.top.postMessage(benchmarkCategoryJson);
};