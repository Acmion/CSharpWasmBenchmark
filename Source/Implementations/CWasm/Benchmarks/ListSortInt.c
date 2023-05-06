#include <stdio.h>
#include <stdlib.h>
#include <time.h>

long ListSortIntIterations;
long *ListSortIntList;

void ListSortIntInitialize(const long iterations)
{
    ListSortIntIterations = iterations;

    srand(iterations);
    if (ListSortIntList)
    {
        free(ListSortIntList);
    }

    ListSortIntList = (long *)malloc(sizeof(long) * iterations);

    for (long i = 0; i < iterations; i++)
    {
        long number = rand() % 1000000;
        ListSortIntList[i] = number;
    }
}

int ListSortIntCompare(const void* a, const void* b) {
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

long ListSortIntExecute()
{
    qsort(ListSortIntList, ListSortIntIterations, sizeof(long), ListSortIntCompare);
    return ListSortIntList[ListSortIntIterations / 2];
}
