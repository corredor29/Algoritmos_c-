using System;

namespace Algoritmos_grupo.utils;

class DijkstraEjemplo
{
    // Representa una arista dirigida: va desde el nodo actual hasta 'To' con peso 'W'
    class Edge
    {
        public int To; // Nodo destino de esta arista
        public int W;  // Peso (costo) de recorrer esta arista

        public Edge(int to, int w)
        {
            To = to;
            W  = w;
        }
    }

    // ─────────────────────────────────────────────────────────
    // Dijkstra: calcula la distancia mínima desde el nodo 's' a todos los demás
    // g  = grafo representado como lista de adyacencia (g[u] = aristas que salen de u)
    // s  = nodo de origen
    // Devuelve un arreglo dist[] donde dist[i] = distancia mínima de s a i
    // ─────────────────────────────────────────────────────────
    static int[] Dijkstra(List<Edge>[] g, int s)
    {
        int n = g.Length;

        int[]  dist = new int[n];  // dist[i] = mejor distancia conocida de s a i
        bool[] vis  = new bool[n]; // vis[i]  = true si ya encontramos la distancia definitiva de i

        const int INF = int.MaxValue; // Usamos int.MaxValue como "infinito" inicial

        // Paso 1: inicializamos todas las distancias a "infinito"
        // (no sabemos aún cómo llegar a ningún nodo)
        for (int i = 0; i < n; i++)
            dist[i] = INF;

        dist[s] = 0; // La distancia del origen a sí mismo siempre es 0

        // Cola de prioridad: extrae siempre el nodo con MENOR distancia provisional
        // Elemento: (nodo, distancia) → ordena por distancia (segundo parámetro)
        var pq = new PriorityQueue<int, int>();
        pq.Enqueue(s, 0); // Insertamos el nodo origen con distancia 0

        // Procesamos nodos mientras haya en la cola
        while (pq.Count > 0)
        {
            // Extraemos el nodo 'u' con la menor distancia provisional actual
            pq.TryDequeue(out int u, out int d);

            // Si ya procesamos este nodo antes (puede estar duplicado en la cola),
            // lo ignoramos para no hacer trabajo innecesario
            if (vis[u])
                continue;

            vis[u] = true; // Marcamos 'u' como procesado: dist[u] ya es definitivo

            // Recorremos todas las aristas que salen de u
            foreach (var e in g[u])
            {
                int v = e.To; // Nodo vecino al que podemos llegar desde u
                int w = e.W;  // Costo de ir de u a v

                // "Relajación": comprobamos si ir de s→u→v es más corto
                // que la mejor distancia que teníamos hasta v
                // Condición dist[u] != INF evita overflow al sumar INF + w
                if (dist[u] != INF && dist[u] + w < dist[v])
                {
                    dist[v] = dist[u] + w; // Actualizamos la distancia mínima a v
                    pq.Enqueue(v, dist[v]); // Insertamos v en la cola con su nueva prioridad
                    // (puede quedar duplicado en la cola, pero el check vis[] lo maneja)
                }
            }
        }

        return dist; // Devolvemos el arreglo con todas las distancias mínimas desde s
    }

    static void Main()
    {
        // Construimos el grafo: 3 nodos (0, 1, 2) con aristas dirigidas
        // Estructura: 0 --2--> 1 --3--> 2
        var g = new List<Edge>[3];
        for (int i = 0; i < 3; i++)
            g[i] = new List<Edge>(); // Inicializamos la lista de aristas de cada nodo

        g[0].Add(new Edge(1, 2)); // Arista: nodo 0 → nodo 1, peso 2
        g[1].Add(new Edge(2, 3)); // Arista: nodo 1 → nodo 2, peso 3
        // Nodo 2 no tiene aristas salientes

        // Ejecutamos Dijkstra desde el nodo 0
        int[] dist = Dijkstra(g, 0);

        // Mostramos la distancia mínima desde el nodo 0 a cada nodo
        Console.WriteLine("Dijkstra (origen 0):");
        for (int i = 0; i < dist.Length; i++)
            Console.WriteLine($"  dist[0 -> {i}] = {dist[i]}");

        // Resultado esperado:
        // dist[0 -> 0] = 0  (el origen a sí mismo siempre es 0)
        // dist[0 -> 1] = 2  (camino directo 0→1 con peso 2)
        // dist[0 -> 2] = 5  (camino 0→1→2 con peso 2+3=5)
    }
}