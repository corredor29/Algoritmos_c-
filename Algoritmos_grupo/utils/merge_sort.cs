using System;

namespace Algoritmos_grupo.utils;

public class MergeSortDemo
{
    // ─────────────────────────────────────────────────────────
    // Fusiona dos mitades ya ordenadas en un único segmento ordenado
    // Recibe: arr, el índice izquierdo, el medio y el derecho
    // arr[left..mid] está ordenado  Y  arr[mid+1..right] está ordenado
    // Al terminar: arr[left..right] queda completamente ordenado
    // ─────────────────────────────────────────────────────────
    public static void Merge(int[] arr, int left, int mid, int right)
    {
        int n1 = mid - left + 1; // Cantidad de elementos en la mitad izquierda
        int n2 = right - mid;    // Cantidad de elementos en la mitad derecha

        // Copiamos ambas mitades en arreglos temporales
        // Necesitamos copias para no sobreescribir datos mientras fusionamos
        int[] L = new int[n1];
        int[] R = new int[n2];

        for (int i = 0; i < n1; i++) L[i] = arr[left + i];      // Copia la mitad izquierda
        for (int j = 0; j < n2; j++) R[j] = arr[mid + 1 + j];  // Copia la mitad derecha

        int iL = 0;   // Índice para recorrer L (empieza al inicio de la copia izquierda)
        int iR = 0;   // Índice para recorrer R (empieza al inicio de la copia derecha)
        int k  = left; // Índice para escribir el resultado directamente en arr

        // Comparamos el frente de L y R, y escribimos el menor en arr
        // Esto garantiza que arr[left..right] quede en orden ascendente
        while (iL < n1 && iR < n2)
        {
            if (L[iL] <= R[iR])
            {
                arr[k] = L[iL]; // L tiene el menor (o igual): lo copiamos a arr
                iL++;
            }
            else
            {
                arr[k] = R[iR]; // R tiene el menor: lo copiamos a arr
                iR++;
            }
            k++;
        }

        // Si quedaron elementos en L que no se copiaron aún,
        // ya están ordenados y son todos mayores que lo último de R → los copiamos directo
        while (iL < n1) { arr[k] = L[iL]; iL++; k++; }

        // Si quedaron elementos en R que no se copiaron aún, igual los copiamos directo
        while (iR < n2) { arr[k] = R[iR]; iR++; k++; }
    }

    // ─────────────────────────────────────────────────────────
    // Divide arr[left..right] recursivamente hasta subarreglos de 1 elemento,
    // luego los va fusionando de abajo hacia arriba con Merge()
    // ─────────────────────────────────────────────────────────
    public static void MergeSort(int[] arr, int left, int right)
    {
        // Caso base: un subarreglo de 0 o 1 elemento ya está ordenado por definición
        if (left >= right)
            return;

        // Calculamos el punto medio con esta fórmula para evitar overflow
        // (en lugar de la forma naïve (left + right) / 2 que puede desbordar con índices grandes)
        int mid = left + (right - left) / 2;

        MergeSort(arr, left, mid);       // Ordenamos recursivamente la mitad izquierda
        MergeSort(arr, mid + 1, right);  // Ordenamos recursivamente la mitad derecha

        // Ambas mitades ya están ordenadas: las fusionamos en una sola
        Merge(arr, left, mid, right);
    }

    public static void Ejecutar()
    {
        int[] data = { 3, 7, 6, -10, 15, 23, 55, -13 };

        Console.WriteLine("Antes:   " + string.Join(", ", data));

        // MergeSort divide hasta subarreglos de 1 elemento,
        // luego Merge los va uniendo en orden: primero pares, luego grupos de 4, de 8...
        MergeSort(data, 0, data.Length - 1);

        Console.WriteLine("Después: " + string.Join(", ", data));
        // Resultado esperado: -13, -10, 3, 6, 7, 15, 23, 55
    }
}