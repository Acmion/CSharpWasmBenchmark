# CSharpWasmBenchmark
This project compares the performances of C# Runtime, C# Wasm AOT, C# Wasm Interpreted and JavaScript. The goal
is to get a statistical overview of whether the performance of C# Wasm is good enough for your project.  

The results can be viewed here: [https://csharp-wasm-benchmark.acmion.com](https://csharp-wasm-benchmark.acmion.com).

## Building
1. Execute the following commands in a terminal:  
    ```
    dotnet restore ./Source/Implementations/CSharpWasmAotBlazor/CSharpWasmAotBlazor.csproj
    dotnet restore ./Source/Implementations/CSharpWasmInterpretedBlazor/CSharpWasmAotBlazor.csproj
    dotnet restore ./Source/CSharpWasmBenchmark/CSharpWasmBenchmark.csproj

    dotnet publish ./Source/Implementations/CSharpWasmAotBlazor/CSharpWasmAotBlazor.csproj --configuration Release
    dotnet publish ./Source/Implementations/CSharpWasmInterpretedBlazor/CSharpWasmInterpretedBlazor.csproj --configuration Release
    dotnet publish ./Source/CSharpWasmBenchmark/CSharpWasmBenchmark.csproj --configuration Release
    ```
2. Done.

## Execution
1. Execute the following commands in a terminal:
    ```
    dotnet run --configuration Release --project ./Source/CSharpWasmBenchmark/CSharpWasmBenchmark.csproj
    ```
2. Navigate to the URL that is shown in the terminal with a browser.
3. Navigate to `/benchmarks/` and click on an implementation.
4. Click on "Run Benchmarks" to run the benchmarks.
5. Click on "Download Benchmark Data" to download the data.
6. Upload the data in the directory `Data` directly under the repo root. 
7. Navigate to the URL `/results/` and view the results.
8. Done. 

## Architecture
- `Source/Implementations/Benchmarking`: Contains the benchmarking code. All C# projects use the same code. The JS code has been translated as directly as possible from C#.
- `Source/Implementations/CSharpWasmAotBlazor`: Contains the code for the C# project that will be AOT compiled to Wasm.
- `Source/Implementations/CSharpWasmInterpretedBlazor`: Contains the code for the C# project that will be compiled to interpreted Wasm.
- `Source/CSharpWasmBenchmark`: An ASP.NET Core project that benchmarks C# Runtime, C# Wasm AOT, C# Wasm Interpreted and JavaScript. The project also directly handles the benchmarking for the C# Runtime and JavaScript implementations.