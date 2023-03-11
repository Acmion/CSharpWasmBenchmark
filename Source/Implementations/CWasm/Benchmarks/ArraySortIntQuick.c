#include <stdio.h>
#include <stdlib.h>
#include <time.h>

long ArraySortIntQuickIterations;
long *ArraySortIntQuickList;

void ArraySortIntQuickInitialize(const long iterations)
{
    ArraySortIntQuickIterations = iterations;

    srand(iterations);
    if (ArraySortIntQuickList)
    {
        free(ArraySortIntQuickList);
    }

    ArraySortIntQuickList = (long *)malloc(sizeof(long) * iterations);

    for (long i = 0; i < iterations; i++)
    {
        long number = rand() % 1000000;
        ArraySortIntQuickList[i] = number;
    }
}

void ArraySortIntQuickSort(long* array, long left, long right);

void ArraySortIntQuickSortMain(long* array) {
    ArraySortIntQuickSort(array, 0, ArraySortIntQuickIterations - 1);
}

long ArraySortIntQuickSelectPivot(long* array, long left, long right) {
    return array[left + (right - left) / 2];
}

long ArraySortIntQuickPartition(long* array, long left, long right) {
    long pivot = ArraySortIntQuickSelectPivot(array, left, right);
    long nleft = left;
    long nright = right;

    while (1) {
        while (array[nleft] - pivot < 0) {
            nleft++;
        }

        while (array[nright] - pivot > 0) {
            nright--;
        }

        if (nleft >= nright) {
            return nright;
        }

        int t = array[nleft];
        array[nleft] = array[nright];
        array[nright] = t;

        nleft++;
        nright--;
    }
}

void ArraySortIntQuickSort(long* array, long left, long right) {
    if (left >= right) {
        return;
    }

    long p = ArraySortIntQuickPartition(array, left, right);
    ArraySortIntQuickSort(array, left, p);
    ArraySortIntQuickSort(array, p + 1, right);
}

long ArraySortIntQuickExecute()
{
    ArraySortIntQuickSortMain(ArraySortIntQuickList);
    return ArraySortIntQuickList[ArraySortIntQuickIterations / 2];
}
