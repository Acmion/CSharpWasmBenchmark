#include <stdio.h>
#include <string.h>

long StringConcatenationIterations;
char StringConcatenationCharacteres[] = "abcdefghijklmnopqrstuvwxyz";

void StringConcatenationInitialize(const long iterations)
{
    StringConcatenationIterations = iterations;
}

char StringConcatenationExecute()
{
    char result[StringConcatenationIterations + 1];
    int charactersLength = strlen(StringConcatenationCharacteres);

    for (long i = 0; i < StringConcatenationIterations; i++) {
        result[i] = StringConcatenationCharacteres[i % charactersLength];
    }
    result[StringConcatenationIterations] = '\0';

    return result[StringConcatenationIterations / 2];
}
