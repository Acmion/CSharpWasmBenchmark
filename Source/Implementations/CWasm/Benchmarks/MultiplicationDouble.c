#include <stdio.h>
#include <stdlib.h>
#include <time.h>

long MultiplicationDoubleIterations;
double *MultiplicationDoubleList;

void MultiplicationDoubleInitialize(const long iterations)
{
    MultiplicationDoubleIterations = iterations;

    srand(iterations);
    if (MultiplicationDoubleList)
    {
        free(MultiplicationDoubleList);
    }

    MultiplicationDoubleList = (double *)malloc(sizeof(double) * iterations / 100);

    for (long i = 0; i < iterations / 100; i++)
    {
        double number = (rand() % 10000) / 100.0;
        MultiplicationDoubleList[i] = number;
    }
}

double MultiplicationDoubleExecute()
{
    double result = 0.0;
    long count = MultiplicationDoubleIterations / 100;

    for (long j = 0; j < 100; j++)
    {
        for (long i = 0; i < count; i++) 
        {
            result += MultiplicationDoubleList[i] * i;
        }
    }

    return result;
}
