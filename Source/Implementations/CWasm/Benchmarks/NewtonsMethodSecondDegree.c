long NewtonsMethodSecondDegreeIterations;

void NewtonsMethodSecondDegreeInitialize(const long iterations)
{
    NewtonsMethodSecondDegreeIterations = iterations;
}

double NewtonsMethodSecondDegreeFunction(double x) 
{
    return 5 * x * x - 3 * x + 7;
}

double NewtonsMethodSecondDegreeExecute()
{
    double h = 0.001;
    double currentRoot = 0.0;

    for (long i = 0; i < NewtonsMethodSecondDegreeIterations; i++) 
    {
        double derivative = (NewtonsMethodSecondDegreeFunction(currentRoot + h) - NewtonsMethodSecondDegreeFunction(currentRoot)) / h;
        currentRoot = currentRoot - NewtonsMethodSecondDegreeFunction(currentRoot) / derivative;
    }

    return currentRoot;
}
