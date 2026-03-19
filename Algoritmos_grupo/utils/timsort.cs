using System;

namespace Algoritmos_grupo.utils;

class TimSortDemo
{
    // Tamaño máximo de cada "run" (bloque que ordena Insertion Sort)
    // Con RUN=32, arreglos de hasta 32 elementos se ordenan directamente con Insertion Sort
    // En implementaciones de producción suele ser 32 o 64
    const int RUN = 32;

    // ─────────────────────────────────────────────────────────
    // FASE 1 – Insertion Sort sobre un segmento [left..right]
    // Se usa para ordenar cada run individualmente
    // Es eficiente para segmentos pequeños y casi ordenados
    // ─────────────────────────────────────────────────────────
    static void InsertionSort(int[] arr, int left, int right)
    {
        // Comenzamos desde left+1: left ya forma una "zona ordenada" de un elemento
        for (int i = left + 1; i <= right; i++)
        {
            int key = arr[i]; // Elemento que vamos a insertar en su posición correcta
            int j   = i - 1;

            // Desplazamos a la derecha los elementos del segmento que sean mayores que key
            // Así abrimos el hueco donde irá key
            while (j >= left && arr[j] > key)
            {
                arr[j + 1] = arr[j]; // Mueve el elemento mayor una posición a la derecha
                j--;
            }

            arr[j + 1] = key; // Insertamos key en el primer hueco libre
        }
    }

    // ─────────────────────────────────────────────────────────
    // FASE 2 – Merge: fusiona dos runs ya ordenados
    // arr[left..mid] está ordenado  Y  arr[mid+1..right] está ordenado
    // Al terminar arr[left..right] queda completamente ordenado
    // ─────────────────────────────────────────────────────────
    static void Merge(int[] arr, int left, int mid, int right)
    {
        int len1 = mid - left + 1; // Tamaño del primer run
        int len2 = right - mid;    // Tamaño del segundo run

        // Copiamos ambos runs en arreglos temporales para no pisar datos mientras fusionamos
        int[] leftArr  = new int[len1];
        int[] rightArr = new int[len2];

        for (int i = 0; i < len1; i++) leftArr[i]  = arr[left + i];
        for (int i = 0; i < len2; i++) rightArr[i] = arr[mid + 1 + i];

        int iL = 0;    // Índice para recorrer leftArr
        int iR = 0;    // Índice para recorrer rightArr
        int k  = left; // Índice para escribir en arr

        // Comparamos el frente de ambos runs y copiamos el menor a arr
        while (iL < len1 && iR < len2)
        {
            if (leftArr[iL] <= rightArr[iR])
                arr[k++] = leftArr[iL++];  // El izquierdo es menor o igual, lo tomamos
            else
                arr[k++] = rightArr[iR++]; // El derecho es menor, lo tomamos
        }

        // Copiamos los elementos restantes de leftArr (si los hay)
        while (iL < len1) arr[k++] = leftArr[iL++];

        // Copiamos los elementos restantes de rightArr (si los hay)
        while (iR < len2) arr[k++] = rightArr[iR++];
    }

    // ─────────────────────────────────────────────────────────
    // TimSort completo: une ambas fases
    // FASE 1 → ordena bloques pequeños (runs) con Insertion Sort
    // FASE 2 → fusiona esos runs con Merge Sort hasta ordenar todo
    // ─────────────────────────────────────────────────────────
    static void TimSort(int[] arr)
    {
        int n = arr.Length;

        // ── FASE 1: Dividir en runs y ordenar cada uno con Insertion Sort ──
        // i avanza de RUN en RUN: 0, 32, 64, 96...
        for (int i = 0; i < n; i += RUN)
        {
            // El run va de i hasta i+RUN-1, pero sin pasarse del final del arreglo
            // Math.Min protege el último bloque que puede ser más pequeño que RUN
            int right = Math.Min(i + RUN - 1, n - 1);
            InsertionSort(arr, i, right); // Ordenamos este bloque pequeño
        }

        // ── FASE 2: Fusionar runs con Merge Sort ──
        // size empieza en RUN y se duplica cada vuelta: RUN, 2*RUN, 4*RUN...
        // Cada vuelta fusiona pares de runs de tamaño 'size'
        for (int size = RUN; size < n; size *= 2)
        {
            // left avanza de 2*size en 2*size: toma el inicio de cada par de runs
            for (int left = 0; left < n; left += 2 * size)
            {
                // mid = fin del primer run del par (sin pasarse del arreglo)
                int mid   = Math.Min(left + size - 1,     n - 1);

                // right = fin del segundo run del par (sin pasarse del arreglo)
                int right = Math.Min(left + 2 * size - 1, n - 1);

                // Solo fusionamos si realmente existe un segundo run
                // (si mid == right, solo hay un run y no hay nada que fusionar)
                if (mid < right)
                    Merge(arr, left, mid, right);
            }
        }
    }

    static void Main()
    {
        int[] data = { 64, 34, 25, 12, 22, 11, 90, 5, 77, 43, 18, 3 };

        Console.WriteLine("Antes:   " + string.Join(", ", data));

        // Con 12 elementos y RUN=32, toda la FASE 1 ordena el arreglo completo en un solo run
        // La FASE 2 no necesita fusionar nada (solo hay un run)
        // Para ver ambas fases en acción prueba con un arreglo de más de 32 elementos
        TimSort(data);

        Console.WriteLine("Después: " + string.Join(", ", data));
        // Resultado esperado: 3, 5, 11, 12, 18, 22, 25, 34, 43, 64, 77, 90
    }
}