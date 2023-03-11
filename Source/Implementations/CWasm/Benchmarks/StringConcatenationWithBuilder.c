#include <stdio.h>
#include <string.h>

long StringConcatenationWithBuilderIterations;
char StringConcatenationWithBuilderCharacteres[] = "abcdefghijklmnopqrstuvwxyz";

void StringConcatenationWithBuilderInitialize(const long iterations)
{
    StringConcatenationWithBuilderIterations = iterations;
}

char StringConcatenationWithBuilderExecute()
{
    char result[StringConcatenationWithBuilderIterations + 1];
    int charactersLength = strlen(StringConcatenationWithBuilderCharacteres);

    for (long i = 0; i < StringConcatenationWithBuilderIterations; i++) {
        result[i] = StringConcatenationWithBuilderCharacteres[i % charactersLength];
    }
    result[StringConcatenationWithBuilderIterations] = '\0';

    return result[StringConcatenationWithBuilderIterations / 2];
}
