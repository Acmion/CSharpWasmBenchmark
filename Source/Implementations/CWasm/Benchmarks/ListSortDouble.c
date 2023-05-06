#include <stdio.h>
#include <stdlib.h>
#include <time.h>

long ListSortDoubleIterations;
double *ListSortDoubleList;

void ListSortDoubleInitialize(const long iterations)
{
    ListSortDoubleIterations = iterations;

    srand(iterations);
    if (ListSortDoubleList)
    {
        free(ListSortDoubleList);
    }

    ListSortDoubleList = (double *)malloc(sizeof(double) * iterations);

    for (long i = 0; i < iterations; i++)
    {
        double number = (rand() % 100000000) / 100.0;
        ListSortDoubleList[i] = number;
    }
}

int ListSortDoubleCompare(const void* a, const void* b) {
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

double ListSortDoubleExecute()
{
    qsort(ListSortDoubleList, ListSortDoubleIterations, sizeof(double), ListSortDoubleCompare);
    return ListSortDoubleList[ListSortDoubleIterations / 2];
}
