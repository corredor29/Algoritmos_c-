using System;

namespace Algoritmos_grupo.utils;

public class Ejemplo3
{
    // Cuenta cuántos pares (i, j) existen donde arr[i] < arr[j]
    // Usa dos bucles anidados → por cada elemento recorre TODO el arreglo
    // Con n=5: 5×5 = 25 comparaciones en total → O(n²)
    public static int CountPairs(int[] arr)
    {
        int count = 0; // Contador de pares válidos encontrados

        // Bucle externo: toma cada elemento como posible "elemento menor"
        for (int i = 0; i < arr.Length; i++)
        {
            // Bucle interno: compara arr[i] contra TODOS los elementos del arreglo
            // Por cada valor de i, este bucle recorre los n elementos completos
            for (int j = 0; j < arr.Length; j++)
            {
                // Si arr[i] es estrictamente menor que arr[j], contamos el par
                if (arr[i] < arr[j])
                    count++;
            }
        }

        return count; // Total de pares donde arr[i] < arr[j]
    }

    public static void Ejecutar()
    {
        int[] data = { 3, 1, 4, 1, 5 };

        // Con 5 elementos se hacen 5×5 = 25 comparaciones en total
        // De esas 25, exactamente 9 cumplen arr[i] < arr[j]
        int resultado = CountPairs(data);

        Console.WriteLine("Pares donde arr[i] < arr[j]: " + resultado);
        // Resultado esperado: 9
    }
}