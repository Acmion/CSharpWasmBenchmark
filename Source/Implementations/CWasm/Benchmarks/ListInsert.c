#include <stdio.h>
#include <stdlib.h>
#include <time.h>

long ListInsertIterations;
long *ListInsertList;

void ListInsertInitialize(const long iterations)
{
    ListInsertIterations = iterations;

    srand(iterations);
    if (ListInsertList)
    {
        free(ListInsertList);
    }

    ListInsertList = (long *)malloc(sizeof(long) * iterations);

    for (long i = 0; i < iterations; i++)
    {
        long number = rand() % 1000000;
        ListInsertList[i] = number;
    }
}

long ListInsertExecute()
{
    long count = ListInsertIterations / 5;
    long newSize = ListInsertIterations + count;

    ListInsertList = (long *)realloc(ListInsertList, newSize * sizeof(long));
    for (int i = 0; i < count; i++) 
    {
        for (int j = newSize - 1; j > i; j--) 
        {
            ListInsertList[j] = ListInsertList[j - 1];
        }
        
        ListInsertList[i] = 0;
    }

    return ListInsertList[newSize / 2];
}
