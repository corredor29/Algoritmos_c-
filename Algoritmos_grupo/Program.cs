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
                    Console.WriteLine("=== El resultado de O(1) es ===");
                    Ejemplo1.Ejecutar();
                    break;
                case "2":
                    Console.WriteLine("=== El resultado de O(n) es ===");
                    Ejemplo2.Ejecutar();
                    break;
                case "3":
                    Console.WriteLine("=== El resultado de O(n^2) es ===");
                    Ejemplo3.Ejecutar();
                    break;
                case "4":
                    Console.WriteLine("=== El resultado de Selection Sort es ===");
                    SelectionSortDemo.Ejecutar();
                    break;
                case "5":
                    Console.WriteLine("=== El resultado de Insertion Sort es ===");
                    InsertionSortDemo.Ejecutar();
                    break;
                case "6":
                    Console.WriteLine("=== El resultado de Merge Sort es ===");
                    MergeSortDemo.Ejecutar();
                    break;
                case "7":
                    Console.WriteLine("=== El resultado de TimSort es ===");
                    TimSortDemo.Ejecutar();
                    break;
                case "8":
                    Console.WriteLine("=== El resultado de Quick Sort es ===");
                    QuickSortDemo.Ejecutar();
                    break;
                case "9":
                    Console.WriteLine("=== El resultado de Dijkstra es ===");
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