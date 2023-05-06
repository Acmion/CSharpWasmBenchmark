#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>

struct DictionaryAccessIntEntry { 
    struct DictionaryAccessIntEntry *next; 
    long key; 
    long value;
};

#define DictionaryAccessIntHASHSIZE 1000

static struct DictionaryAccessIntEntry *DictionaryAccessIntHashTable[DictionaryAccessIntHASHSIZE];
long DictionaryAccessIntIterations;
long *DictionaryAccessIntList;

unsigned DictionaryAccessIntHash(long key)
{
    return key % DictionaryAccessIntHASHSIZE;
}

struct DictionaryAccessIntEntry *DictionaryAccessIntLookup(long key)
{
    struct DictionaryAccessIntEntry *current;
    for (current = DictionaryAccessIntHashTable[DictionaryAccessIntHash(key)]; current != NULL; current = current->next)
    {
        if (key == current->key)
        {
          return current; 
        }
    }
    return NULL; 
}

struct DictionaryAccessIntEntry *DictionaryAccessIntInsert(long key, long value)
{
    struct DictionaryAccessIntEntry *item;
    unsigned hashval;
    if ((item = DictionaryAccessIntLookup(key)) == NULL) 
    { 
        item = (struct DictionaryAccessIntEntry *) malloc(sizeof(*item));
        if (item == NULL)
        {
          return NULL;
        }
        item->key = key;
        hashval = DictionaryAccessIntHash(key);
        item->next = DictionaryAccessIntHashTable[hashval];
        DictionaryAccessIntHashTable[hashval] = item;
    } 

    item->value = value;
    return item;
}

void DictionaryAccessIntFreeTable()
{
    struct DictionaryAccessIntEntry *current, *next;
    int i;
    for (i = 0; i < DictionaryAccessIntHASHSIZE; i++) 
    {
        current = DictionaryAccessIntHashTable[i];
        while (current != NULL) 
        {
            next = current->next;
            free(current);
            current = next;
        }
        DictionaryAccessIntHashTable[i] = NULL;
    }
}

void DictionaryAccessIntFreeList()
{
    free(DictionaryAccessIntList);
}

void DictionaryAccessIntInitialize(const long iterations)
{
    srand(iterations);
    if (DictionaryAccessIntList)
    {
        DictionaryAccessIntFreeList();
        DictionaryAccessIntFreeTable();
    }
    
    DictionaryAccessIntIterations = iterations;
    DictionaryAccessIntList = (long *)malloc(sizeof(long) * iterations);

    for (long i = 0; i < iterations; i++)
    {
        long number = rand() % 1000000;
        DictionaryAccessIntList[i] = i;
        DictionaryAccessIntInsert(i, number);
    }
}

long DictionaryAccessIntExecute()
{
    long result = 0;
    long count = DictionaryAccessIntIterations;

    for (long i = 0; i < count; i++)
    {
        long key = DictionaryAccessIntList[rand() % count];
        result += DictionaryAccessIntLookup(key)->value;
    }

    return result;
}