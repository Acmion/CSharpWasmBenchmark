class NewtonsMethodSecondDegree
{
    Initialize(parameter)
    {
        this.Iterations = parameter;
    }

    Execute()
    {
        var h = 0.001;
        var currentRoot = 0.0;

        for (var i = 0; i < this.Iterations; i++) 
        {
            var derivative = (this.Function(currentRoot + h) - this.Function(currentRoot)) / h;

            currentRoot = currentRoot - this.Function(currentRoot) / derivative;
        }

        return currentRoot;
    }

    Function(x)
    {
        return 5 * x * x - 3 * x + 7;
    }
}
