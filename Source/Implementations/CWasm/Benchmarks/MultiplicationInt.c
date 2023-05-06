#include <stdio.h>
#include <stdlib.h>
#include <time.h>

long MultiplicationIntIterations;
long *MultiplicationIntList;

void MultiplicationIntInitialize(const long iterations)
{
    MultiplicationIntIterations = iterations;

    srand(iterations);
    if (MultiplicationIntList)
    {
        free(MultiplicationIntList);
    }

    MultiplicationIntList = (long *)malloc(sizeof(long) * iterations / 100);

    for (long i = 0; i < iterations / 100; i++)
    {
        long number = rand() % 100;
        MultiplicationIntList[i] = number;
    }
}

long MultiplicationIntExecute()
{
    long result = 0;
    long count = MultiplicationIntIterations / 100;

    for (long j = 0; j < 100; j++)
    {
        for (long i = 0; i < count; i++) 
        {
            result += MultiplicationIntList[i] * i;
        }
    }

    return result;
}
