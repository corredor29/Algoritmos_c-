using System;

namespace Algoritmos_grupo.utils;


public class QuickSortDemo
{
    // ─────────────────────────────────────────────────────────
    // Partition: reorganiza arr[low..high] alrededor del pivote
    // Al terminar garantiza:
    //   → Todo lo que está a la IZQUIERDA del pivote es <= pivote
    //   → Todo lo que está a la DERECHA  del pivote es >  pivote
    //   → El pivote queda en su POSICIÓN DEFINITIVA
    // Devuelve el índice donde quedó el pivote
    // ─────────────────────────────────────────────────────────
    public static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high]; // Elegimos el último elemento como pivote
        int i = low - 1;       // i es el límite de la "zona de menores/iguales"
                               // Empieza en low-1 porque aún no hay ningún elemento en esa zona

        // Recorremos desde low hasta high-1 (sin incluir al pivote)
        for (int j = low; j < high; j++)
        {
            // Si el elemento actual es menor o igual al pivote
            // debe pertenecer a la zona izquierda
            if (arr[j] <= pivot)
            {
                i++; // Ampliamos la zona izquierda en una posición

                // Intercambiamos arr[i] y arr[j]:
                // arr[j] (<=pivote) pasa a la zona izquierda
                // arr[i] (el que estaba ahí) pasa a la zona derecha
                int temp = arr[i];
                arr[i]   = arr[j];
                arr[j]   = temp;
            }
            // Si arr[j] > pivot: ya está en la zona derecha, no hacemos nada
        }

        // Colocamos el pivote justo después de todos los elementos menores/iguales
        // i+1 es exactamente su posición final en el arreglo ordenado
        int temp1    = arr[i + 1];
        arr[i + 1]   = arr[high]; // El pivote va a su posición definitiva
        arr[high]    = temp1;     // El elemento que estaba ahí va al lugar del pivote

        return i + 1; // Devolvemos la posición final del pivote
    }

    // ─────────────────────────────────────────────────────────
    // QuickSort recursivo
    // 1. Llama a Partition para colocar el pivote en su lugar
    // 2. Aplica recursión al subarreglo izquierdo (menores/iguales al pivote)
    // 3. Aplica recursión al subarreglo derecho (mayores al pivote)
    // ─────────────────────────────────────────────────────────
    public static void QuickSort(int[] arr, int low, int high)
    {
        // Caso base: si el subarreglo tiene 0 o 1 elemento, ya está ordenado
        if (low >= high)
            return;

        // Particionamos: el pivote queda en su lugar definitivo (índice pi)
        int pi = Partition(arr, low, high);

        // Ordenamos el subarreglo izquierdo: elementos desde low hasta pi-1
        // No incluimos pi porque el pivote ya está en su lugar correcto
        QuickSort(arr, low, pi - 1);

        // Ordenamos el subarreglo derecho: elementos desde pi+1 hasta high
        // No incluimos pi porque el pivote ya está en su lugar correcto
        QuickSort(arr, pi + 1, high);
    }

    public static void Ejecutar()
    {
        int[] data = { 10, 7, 8, 9, 1, 5 };

        Console.WriteLine("Antes:   " + string.Join(", ", data));

        // Primera llamada: pivote = 5 (arr[5])
        // Partition deja: [1, 5, 8, 9, 10, 7] con 5 en índice 1
        // Recursión izquierda: [1] → ya ordenado
        // Recursión derecha:   [8, 9, 10, 7] → pivote=7, continúa recursión...
        QuickSort(data, 0, data.Length - 1);

        Console.WriteLine("Después: " + string.Join(", ", data));
        // Resultado esperado: 1, 5, 7, 8, 9, 10
    }
}