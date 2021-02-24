# CSharpWasmBenchmark
Comparing the performances of C# Runtime, C# Wasm AOT, C# Wasm Interpreted and JavaScript.

**Note:** The C# Wasm benchmarks are compiled with Uno.Wasm.Bootstrap, which is using some sort of preview .NET 6 tech.
The benchmarks failed when using Blazor Wasm Interpreted, due to some memory error. I will include .NET 6 Blazor in this benchmark, 
whenever it gets ready.

## Building
The building is somewhat unreliable. I recommend that each project be compiled separately. 
Additionally, if you wish to try the performance of Blazor Wasm interpreted, you should 
uncomment the marked section in `Benchmarking/Core/BenchmarkRunner.cs` so that some 
memory errors can be avoided. 

## Results
[https://csharp-wasm-benchmark.acmion.com](https://csharp-wasm-benchmark.acmion.com)