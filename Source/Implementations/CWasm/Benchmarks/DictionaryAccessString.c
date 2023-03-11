#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>

struct DictionaryAccessStringEntry { 
    struct DictionaryAccessStringEntry *next; 
    char *key; 
    long value;
};

#define DictionaryAccessStringHASHSIZE 1000

static struct DictionaryAccessStringEntry *DictionaryAccessStringHashTable[DictionaryAccessStringHASHSIZE];
long DictionaryAccessStringIterations;
char **DictionaryAccessStringList;

unsigned DictionaryAccessStringHash(char *key)
{
    unsigned hashval;
    for (hashval = 0; *key != '\0'; key++)
    {
      hashval = *key + 31 * hashval;
    }
    return hashval % DictionaryAccessStringHASHSIZE;
}

struct DictionaryAccessStringEntry *DictionaryAccessStringLookup(char *key)
{
    struct DictionaryAccessStringEntry *current;
    for (current = DictionaryAccessStringHashTable[DictionaryAccessStringHash(key)]; current != NULL; current = current->next)
    {
        if (strcmp(key, current->key) == 0)
        {
          return current; 
        }
    }
    return NULL; 
}

struct DictionaryAccessStringEntry *DictionaryAccessStringInsert(char *key, long value)
{
    struct DictionaryAccessStringEntry *item;
    unsigned hashval;
    if ((item = DictionaryAccessStringLookup(key)) == NULL) 
    { 
        item = (struct DictionaryAccessStringEntry *) malloc(sizeof(*item));
        if (item == NULL || (item->key = strdup(key)) == NULL)
        {
          return NULL;
        }
        hashval = DictionaryAccessStringHash(key);
        item->next = DictionaryAccessStringHashTable[hashval];
        DictionaryAccessStringHashTable[hashval] = item;
    } 

    item->value = value;
    return item;
}

void DictionaryAccessStringFreeTable()
{
    struct DictionaryAccessStringEntry *current, *next;
    int i;
    for (i = 0; i < DictionaryAccessStringHASHSIZE; i++) 
    {
        current = DictionaryAccessStringHashTable[i];
        while (current != NULL) 
        {
            next = current->next;
            free(current->key);
            free(current);
            current = next;
        }
        DictionaryAccessStringHashTable[i] = NULL;
    }
}

void DictionaryAccessStringFreeList()
{
    for (long i = 0; i < DictionaryAccessStringIterations; i++)
    {
        free(DictionaryAccessStringList[i]);
    }
    free(DictionaryAccessStringList);
}

void DictionaryAccessStringInitialize(const long iterations)
{
    srand(iterations);
    if (DictionaryAccessStringList)
    {
        DictionaryAccessStringFreeList();
        DictionaryAccessStringFreeTable();
    }
    
    DictionaryAccessStringIterations = iterations;
    DictionaryAccessStringList = (char **)malloc(sizeof(char *) * iterations);

    for (long i = 0; i < iterations; i++)
    {
        long number = rand() % 1000000;
        char key[20];
        sprintf(key, "%ld:%ld", i, number);
        DictionaryAccessStringList[i] = strdup(key);
        DictionaryAccessStringInsert(key, number);
    }
}

long DictionaryAccessStringExecute()
{
    long result = 0;
    long count = DictionaryAccessStringIterations;

    for (long i = 0; i < count; i++)
    {
        char *key = DictionaryAccessStringList[rand() % count];
        result += DictionaryAccessStringLookup(key)->value;
    }

    return result;
}