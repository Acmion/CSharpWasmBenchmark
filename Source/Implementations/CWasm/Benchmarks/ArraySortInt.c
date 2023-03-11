#include <stdio.h>
#include <stdlib.h>
#include <time.h>

long ArraySortIntIterations;
long *ArraySortIntList;

void ArraySortIntInitialize(const long iterations)
{
    ArraySortIntIterations = iterations;

    srand(iterations);
    if (ArraySortIntList)
    {
        free(ArraySortIntList);
    }

    ArraySortIntList = (long *)malloc(sizeof(long) * iterations);

    for (long i = 0; i < iterations; i++)
    {
        long number = rand() % 1000000;
        ArraySortIntList[i] = number;
    }
}

int ArraySortIntCompare(const void* a, const void* b) {
    long long_a = *((long*) a);
    long long_b = *((long*) b);

    if (long_a == long_b) {
        return 0;
    } else if (long_a < long_b) {
        return -1;
    } else {
        return 1;
    }
}

long ArraySortIntExecute()
{
    qsort(ArraySortIntList, ArraySortIntIterations, sizeof(long), ArraySortIntCompare);
    return ArraySortIntList[ArraySortIntIterations / 2];
}
