#include <stdio.h>
#include <stdlib.h>
#include <time.h>

long ArraySortDoubleIterations;
double *ArraySortDoubleList;

void ArraySortDoubleInitialize(const long iterations)
{
    ArraySortDoubleIterations = iterations;

    srand(iterations);
    if (ArraySortDoubleList)
    {
        free(ArraySortDoubleList);
    }

    ArraySortDoubleList = (double *)malloc(sizeof(double) * iterations);

    for (long i = 0; i < iterations; i++)
    {
        double number = (rand() % 100000000) / 100.0;
        ArraySortDoubleList[i] = number;
    }
}

int ArraySortDoubleCompare(const void* a, const void* b) {
    double double_a = *((double*) a);
    double double_b = *((double*) b);

    if (double_a == double_b) {
        return 0;
    } else if (double_a < double_b) {
        return -1;
    } else {
        return 1;
    }
}

double ArraySortDoubleExecute()
{
    qsort(ArraySortDoubleList, ArraySortDoubleIterations, sizeof(double), ArraySortDoubleCompare);
    return ArraySortDoubleList[ArraySortDoubleIterations / 2];
}
