using System;

namespace Algoritmos_grupo.utils;

public class InsertionSortDemo
{
    // Ordena el arreglo de menor a mayor insertando cada elemento en su lugar correcto
    // Funciona como ordenar cartas: toma una carta nueva y la coloca donde corresponde
    public static void InsertionSort(int[] arr)
    {
        int n = arr.Length;

        // Empezamos en i=1 porque arr[0] solo ya forma una zona "ordenada" de un elemento
        // En cada iteración, arr[0..i-1] ya está ordenado y queremos insertar arr[i]
        for (int i = 1; i < n; i++)
        {
            int key = arr[i]; // Guardamos el elemento a insertar (la "carta nueva")
            int j   = i - 1; // j apunta al último elemento de la zona ya ordenada

            // Mientras no lleguemos al inicio Y el elemento de la izquierda sea mayor que key:
            // desplazamos ese elemento una posición a la derecha para abrir espacio
            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j]; // Mueve el elemento mayor un lugar hacia la derecha
                j--;                 // Retrocede para comparar con el siguiente a la izquierda
            }

            // Cuando el while termina, j+1 es el hueco correcto para key:
            // arr[0..j] son todos menores o iguales a key
            // arr[j+2..i] son todos mayores que key (ya desplazados)
            arr[j + 1] = key; // Insertamos key en su posición correcta
        }
    }

    public static void Ejecutar()
    {
        int[] data = { 12, 11, 13, 5, 6 };

        Console.WriteLine("Antes:   " + string.Join(", ", data));

        // i=1: key=11, desplaza 12 → [11, 12, 13, 5, 6]
        // i=2: key=13, no desplaza nada → [11, 12, 13, 5, 6]
        // i=3: key=5,  desplaza 13,12,11 → [5, 11, 12, 13, 6]
        // i=4: key=6,  desplaza 13,12,11 → [5, 6, 11, 12, 13]
        InsertionSort(data);

        Console.WriteLine("Después: " + string.Join(", ", data));
        // Resultado esperado: 5, 6, 11, 12, 13
    }
}