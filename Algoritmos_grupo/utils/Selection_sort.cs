using System;

namespace Algoritmos_grupo.utils;

class SelectionSortDemo
{
    // Ordena el arreglo de menor a mayor buscando el mínimo en cada pasada
    // En cada iteración del bucle externo coloca UN elemento en su posición final
    static void SelectionSort(int[] arr)
    {
        int n = arr.Length;

        // El bucle externo avanza el límite de la zona ordenada
        // Después de i=0: el mínimo global está en arr[0]
        // Después de i=1: el segundo mínimo está en arr[1], y así sucesivamente
        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i; // Suponemos que el mínimo de la zona no ordenada está en i

            // Recorremos toda la zona no ordenada (desde i+1 hasta el final)
            // buscando si existe algún elemento más pequeño que arr[minIndex]
            for (int j = i + 1; j < n; j++)
            {
                if (arr[j] < arr[minIndex])
                    minIndex = j; // Encontramos un valor más pequeño, actualizamos
            }

            // Solo intercambiamos si el mínimo real NO estaba ya en la posición i
            // Esto evita un intercambio innecesario cuando i ya tiene el mínimo
            if (minIndex != i)
            {
                int temp        = arr[i];
                arr[i]          = arr[minIndex]; // El mínimo sube a su posición definitiva
                arr[minIndex]   = temp;          // El elemento desplazado va al hueco
            }
        }
    }

    static void Main()
    {
        int[] data = { 64, 25, 12, 22, 11 };

        Console.WriteLine("Antes:   " + string.Join(", ", data));

        // Pasada 1 (i=0): encuentra 11 en posición 4, intercambia con 64 → [11, 25, 12, 22, 64]
        // Pasada 2 (i=1): encuentra 12 en posición 2, intercambia con 25 → [11, 12, 25, 22, 64]
        // Pasada 3 (i=2): encuentra 22 en posición 3, intercambia con 25 → [11, 12, 22, 25, 64]
        // Pasada 4 (i=3): 25 ya está en su lugar, no intercambia
        SelectionSort(data);

        Console.WriteLine("Después: " + string.Join(", ", data));
        // Resultado esperado: 11, 12, 22, 25, 64
    }
}