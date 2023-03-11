#include <stdio.h>
#include <stdlib.h>
#include <time.h>

long SummationIntIterations;
long *SummationIntList;

void SummationIntInitialize(const long iterations)
{
    SummationIntIterations = iterations;

    srand(iterations);
    if (SummationIntList)
    {
        free(SummationIntList);
    }

    SummationIntList = (long *)malloc(sizeof(long) * iterations / 1000);

    for (long i = 0; i < iterations / 1000; i++)
    {
        long number = rand() % 100;
        SummationIntList[i] = number;
    }
}

long SummationIntExecute()
{
    long result = 0;
    long count = SummationIntIterations / 1000;

    for (long j = 0; j < 1000; j++)
    {
        for (long i = 0; i < count; i++) 
        {
            result += SummationIntList[i];
        }
    }

    return result;
}
