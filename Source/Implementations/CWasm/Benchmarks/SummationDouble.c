#include <stdio.h>
#include <stdlib.h>
#include <time.h>

long SummationDoubleIterations;
double *SummationDoubleList;

void SummationDoubleInitialize(const long iterations)
{
    SummationDoubleIterations = iterations;

    srand(iterations);
    if (SummationDoubleList)
    {
        free(SummationDoubleList);
    }

    SummationDoubleList = (double *)malloc(sizeof(double) * iterations / 1000);

    for (long i = 0; i < iterations / 1000; i++)
    {
        double number = (rand() % 10000) / 100.0;
        SummationDoubleList[i] = number;
    }
}

double SummationDoubleExecute()
{
    double result = 0;
    long count = SummationDoubleIterations / 1000;

    for (long j = 0; j < 1000; j++)
    {
        for (long i = 0; i < count; i++) 
        {
            result += SummationDoubleList[i];
        }
    }

    return result;
}
