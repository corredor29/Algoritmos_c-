using System;
using Algoritmos_grupo.utils;

class Program
{
    static void Main(string[] args)
    {
        string opcion = "";

        do
        {
            Console.Clear();
            Console.WriteLine("=== MENÚ DE ALGORITMOS ===");
            Console.WriteLine("1. O(1)");
            Console.WriteLine("2. O(n)");
            Console.WriteLine("3. O(n^2)");
            Console.WriteLine("4. Selection Sort");
            Console.WriteLine("5. Insertion Sort");
            Console.WriteLine("6. Merge Sort");
            Console.WriteLine("7. TimSort");
            Console.WriteLine("8. Quick Sort");
            Console.WriteLine("9. Dijkstra");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            opcion = (Console.ReadLine() ?? "").Trim();

            Console.Clear();

            switch (opcion)
            {
                case "1":
                    Ejemplo1.Ejecutar();
                    break;
                case "2":
                    Ejemplo2.Ejecutar();
                    break;
                case "3":
                    Ejemplo3.Ejecutar();
                    break;
                case "4":
                    SelectionSortDemo.Ejecutar();
                    break;
                case "5":
                    InsertionSortDemo.Ejecutar();
                    break;
                case "6":
                    MergeSortDemo.Ejecutar();
                    break;
                case "7":
                    TimSortDemo.Ejecutar();
                    break;
                case "8":
                    QuickSortDemo.Ejecutar();
                    break;
                case "9":
                    DijkstraEjemplo.Ejecutar();
                    break;
                case "0":
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción inválida");
                    break;
            }

            if (opcion != "0")
            {
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }

        } while (opcion != "0");
    }
}