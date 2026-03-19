using System;

namespace Algoritmos_grupo.utils;

class Ejemplo1
{
    // Devuelve el primer elemento del arreglo
    // Sin importar el tamaño del arreglo, siempre hace UNA sola operación
    static int GetFirstElement(int[] arr)
    {
        // Acceso directo por índice 0: no recorre nada, costo fijo siempre
        return arr[0];
    }

    static void Main()
    {
        int[] data = { 10, 20, 30, 40, 50 };

        // Llamamos la función: hará exactamente 1 operación sin importar cuántos elementos haya
        int resultado = GetFirstElement(data);

        Console.WriteLine("Primer elemento: " + resultado);
        // Resultado esperado: 10
    }
}