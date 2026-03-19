using System;

namespace Algoritmos_grupo.utils;


public class Ejemplo2
{
    // Suma todos los elementos del arreglo recorriéndolo una sola vez
    // Si el arreglo tiene n elementos → hace exactamente n sumas → O(n)
    public static int SumArray(int[] arr)
    {
        int sum = 0; // Acumulador donde iremos guardando la suma parcial

        // Recorremos cada posición del arreglo de izquierda a derecha
        // Con 5 elementos: 5 iteraciones. Con 1000 elementos: 1000 iteraciones
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i]; // Sumamos el elemento actual al acumulador
        }

        return sum; // Devolvemos la suma total
    }

    public static void Ejecutar()
    {
        int[] data = { 1, 2, 3, 4, 5 };

        // El bucle hará exactamente 5 iteraciones (una por elemento)
        int resultado = SumArray(data);

        Console.WriteLine("Suma: " + resultado);
        // Resultado esperado: 15  (1+2+3+4+5)
    }
}