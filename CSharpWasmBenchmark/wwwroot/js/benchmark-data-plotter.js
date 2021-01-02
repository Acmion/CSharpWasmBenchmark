class BenchmarkDataPlotter
{
    static plotBenchmarkCategoryDataFromJson(benchmarkCategoryDataJson, legend = "")
    {
        var benchmarkCategoryData = JSON.parse(benchmarkCategoryDataJson);

        for (var benchmarkData of benchmarkCategoryData.BenchmarkInstanceData)
        {
            BenchmarkDataPlotter.plotBenchmarkData(benchmarkData, legend);
        }
    }

    static plotBenchmarkData(benchmarkData, legend)
    {
        var id = benchmarkData.BenchmarkName;
        document.getElementById(id).innerHTML = "";

        // Calculate the average and std for each parameter value (x).
        // The average is the value of the y-axis and std is the value of the errorbars.

        var allValuesForCertainX = {};
        for (var dp of benchmarkData.DataPoints)
        {
            if (dp.ParameterValue in allValuesForCertainX)
            {
                allValuesForCertainX[dp.ParameterValue].push(dp.ElapsedMilliseconds);
            }
            else
            {
                allValuesForCertainX[dp.ParameterValue] = [dp.ElapsedMilliseconds];
            }
        }

        var xs = Object.keys(allValuesForCertainX);
        var ys = [];
        var std = [];

        for (var x of xs)
        {
            ys.push(MathFunctions.average(allValuesForCertainX[x]));
            std.push(MathFunctions.standardDeviation(allValuesForCertainX[x]));
        }

        var trace = { x: xs, y: ys, error_y: { type: 'data', array: std, visible: true }, name: legend };
        var layout =
        {
            showlegend: legend != "",
            legend:
            {
                orientation: "h",
                y: -0.2
            },
            xaxis:
            {
                title: { text: "Parameter Value" },
                linecolor: '#ddd',
                linewidth: 2,
                mirror: true,
            },
            yaxis:
            {
                title: { text: "Elapsed Milliseconds" },
                linecolor: '#ddd',
                linewidth: 2,
                mirror: true,
            },
            paper_bgcolor: 'rgba(0,0,0,0)',
            plot_bgcolor: 'rgba(0,0,0,0)',
            margin:
            {
                t: 20,
                r: 40,
                b: 50,
                l: 60
            },
            height: 400
        };
        var config = { responsive: true, displayModeBar: false };

        var plotlyDiv = document.getElementById(id);

        if (plotlyDiv.data == null || legend == "")
        {
            Plotly.newPlot(plotlyDiv, [trace], layout, config);
        }
        else
        {
            // Couldn't get the "better" Plotly APIs to work.
            // Does not matter much.

            var plotlyData = plotlyDiv.data;

            plotlyDiv.data.push(trace);

            Plotly.newPlot(plotlyDiv, plotlyData, layout, config);
        }
    }
}