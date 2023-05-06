long NewtonsMethodThirdDegreeIterations;

void NewtonsMethodThirdDegreeInitialize(const long iterations)
{
    NewtonsMethodThirdDegreeIterations = iterations;
}

double NewtonsMethodThirdDegreeFunction(double x) 
{
    return 11 * x * x * x + 5 * x * x - 3 * x + 7;
}

double NewtonsMethodThirdDegreeExecute()
{
    double h = 0.001;
    double currentRoot = 0.0;

    for (long i = 0; i < NewtonsMethodThirdDegreeIterations; i++) 
    {
        double derivative = (NewtonsMethodThirdDegreeFunction(currentRoot + h) - NewtonsMethodThirdDegreeFunction(currentRoot)) / h;
        currentRoot = currentRoot - NewtonsMethodThirdDegreeFunction(currentRoot) / derivative;
    }

    return currentRoot;
}
