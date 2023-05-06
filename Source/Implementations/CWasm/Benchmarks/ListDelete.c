#include <stdio.h>
#include <stdlib.h>
#include <time.h>

long ListDeleteIterations;
long *ListDeleteList;

void ListDeleteInitialize(const long iterations)
{
    ListDeleteIterations = iterations;

    srand(iterations);
    if (ListDeleteList)
    {
        free(ListDeleteList);
    }

    ListDeleteList = (long *)malloc(sizeof(long) * iterations);

    for (long i = 0; i < iterations; i++)
    {
        long number = rand() % 1000000;
        ListDeleteList[i] = number;
    }
}

long ListDeleteExecute()
{
    long count = ListDeleteIterations / 5;
    long newSize = ListDeleteIterations - count;

    for (int i = 0; i < count; i++) 
    {
        long end = ListDeleteIterations - i - 1;
        for (int j = 0; j < end; j++) 
        {
            ListDeleteList[j] = ListDeleteList[j + 1];
        }
        
        ListDeleteList[end] = 0;
    }

    ListDeleteList = (long *)realloc(ListDeleteList, newSize * sizeof(long));

    return ListDeleteList[newSize / 2];
}
