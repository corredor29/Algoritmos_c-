# 📊 **Algoritmos de ordenamiento y complejidad temporal**

---

## 🧠 1. ¿Qué es un algoritmo de ordenamiento?

Un **algoritmo de ordenamiento** es un procedimiento que toma una colección de elementos (por ejemplo, un arreglo de números) y los reordena siguiendo un criterio definido, normalmente de menor a mayor o de mayor a menor.

✨ Ordenar datos es fundamental porque muchos otros algoritmos (búsqueda binaria, unión de listas, eliminación de duplicados, análisis estadístico, etc.) dependen de que la colección esté ordenada para ser más simples y rápidos.

---

### 📌 En esta exposición veremos:

* 📈 Qué es la complejidad temporal \(O(\cdot)\)
* ⚙️ Las complejidades típicas más usadas
* 🔄 Cómo se aplican a algoritmos de ordenamiento clásicos:

  * Selection Sort
  * Insertion Sort
  * Merge Sort
  * TimSort
  * Quick Sort
* 🧭 Una introducción al algoritmo de Dijkstra (rutas más cortas)

---

## ⏱️ 2. Complejidad temporal y notación Big O

La **complejidad temporal** mide cómo crece el tiempo de ejecución de un algoritmo cuando aumenta el tamaño de la entrada, que solemos llamar \(n\).

💡 En lugar de contar segundos (que dependen del hardware), contamos aproximadamente el **número de operaciones** que realiza el algoritmo según \(n\).

La **notación Big O**, escrita como \(O(\cdot)\), nos da una cota superior del crecimiento de ese número de operaciones.

✔ Ignora constantes y detalles menores  
✔ Permite comparar algoritmos fácilmente

---

### 📊 2.1. Complejidades temporales típicas

---

#### 🟢 \(O(1)\) – Tiempo constante

Un algoritmo es \(O(1)\) cuando tarda **lo mismo** sin importar cuántos elementos haya.

✔ Hace un número fijo de operaciones  
✔ No depende de \(n\)

> 🔎 **¿Qué hace este ejemplo?**  
> Recibe un arreglo de enteros y devuelve directamente su primer elemento (`arr[0]`).  
> No importa si el arreglo tiene 5 o 5 millones de elementos: siempre realiza exactamente **una operación**, por eso es \(O(1)\).

```csharp
using System;

class Ejemplo1
{
    // Devuelve el primer elemento del arreglo
    // Sin importar el tamaño del arreglo, siempre hace UNA sola operación
    static int GetFirstElement(int[] arr)
    {
        // Acceso directo por índice 0: no recorre nada, costo fijo siempre
        return arr;
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
```

---

#### 🔵 \(O(n)\) – Tiempo lineal

Un algoritmo es \(O(n)\) cuando el número de operaciones crece **proporcionalmente** a la cantidad de elementos.

📈 Si duplicas \(n\), aproximadamente se duplica el trabajo.

> 🔎 **¿Qué hace este ejemplo?**  
> Recibe un arreglo de enteros y calcula la **suma de todos sus elementos** recorriéndolo una sola vez de izquierda a derecha.  
> Si el arreglo tiene 10 elementos hace 10 sumas; si tiene 1000, hace 1000 sumas. El trabajo crece de forma proporcional a \(n\), por eso es \(O(n)\).

```csharp
using System;

class Ejemplo2
{
    // Suma todos los elementos del arreglo recorriéndolo una sola vez
    // Si el arreglo tiene n elementos → hace exactamente n sumas → O(n)
    static int SumArray(int[] arr)
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

    static void Main()
    {
        int[] data = { 1, 2, 3, 4, 5 };

        // El bucle hará exactamente 5 iteraciones (una por elemento)
        int resultado = SumArray(data);

        Console.WriteLine("Suma: " + resultado);
        // Resultado esperado: 15  (1+2+3+4+5)
    }
}
```

---

#### 🔴 \(O(n^2)\) – Tiempo cuadrático

Un algoritmo es \(O(n^2)\) cuando el número de operaciones crece **como el cuadrado** de \(n\).

⚠️ Suele aparecer cuando hay **dos bucles anidados**.

> 🔎 **¿Qué hace este ejemplo?**  
> Recibe un arreglo de enteros y cuenta cuántos **pares de posiciones (i, j)** cumplen que `arr[i] < arr[j]`.  
> Para cada uno de los \(n\) elementos del bucle externo, el bucle interno recorre los \(n\) elementos completos, realizando \(n \times n = n^2\) comparaciones en total. Por eso es \(O(n^2)\).

```csharp
using System;

class Ejemplo3
{
    // Cuenta cuántos pares (i, j) existen donde arr[i] < arr[j]
    // Usa dos bucles anidados → por cada elemento recorre TODO el arreglo
    // Con n=5: 5×5 = 25 comparaciones en total → O(n²)
    static int CountPairs(int[] arr)
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

    static void Main()
    {
        int[] data = { 3, 1, 4, 1, 5 };

        // Con 5 elementos se hacen 5×5 = 25 comparaciones en total
        // De esas 25, exactamente 9 cumplen arr[i] < arr[j]
        int resultado = CountPairs(data);

        Console.WriteLine("Pares donde arr[i] < arr[j]: " + resultado);
        // Resultado esperado: 9
    }
}
```

---

#### 🟣 \(O(n \log n)\) – Tiempo casi lineal

Muchos algoritmos de ordenamiento eficientes, como Merge Sort y Quick Sort (en promedio), tienen complejidad \(O(n \log n)\).

📌 Se logra combinando:

* Procesar todos los elementos en cada nivel \((n)\)
* Dividir el problema en partes más pequeñas \((\log n)\)

---

## 💾 3. Complejidad espacial (memoria)

La **complejidad espacial** indica cuánta memoria extra necesita un algoritmo además de los datos de entrada.

---

### 📦 Tipos:

* **\(O(1)\) memoria extra (in-place)**  
  ✔ Usa pocas variables auxiliares  
  ✔ No depende del tamaño de \(n\)  
  ✔ Ejemplo: Selection Sort, Insertion Sort, Quick Sort clásico

* **\(O(n)\) memoria extra**  
  ✔ Usa estructuras auxiliares  
  ✔ Proporcional al tamaño de entrada  
  ✔ Ejemplo: Merge Sort, TimSort

---

## 🎯 4. Selection Sort (Ordenamiento por selección)

### 💡 4.1. Idea general

Selection Sort divide mentalmente el arreglo en dos zonas:

- **Zona izquierda (ordenada):** ya tiene los elementos más pequeños en su posición definitiva
- **Zona derecha (no ordenada):** todavía por procesar

El proceso funciona así:

1. Busca el elemento **más pequeño** de toda la zona no ordenada
2. Lo **intercambia** con el primer elemento de esa zona
3. Avanza el límite de la zona ordenada una posición a la derecha
4. Repite hasta que toda la zona no ordenada quede vacía

La idea clave es que **cada pasada coloca exactamente un elemento en su posición definitiva**, por lo que siempre realiza exactamente \(n-1\) intercambios sin importar los datos.

---

### 📊 4.2. Complejidad

* Mejor caso: \(O(n^2)\)
* Promedio: \(O(n^2)\)
* Peor caso: \(O(n^2)\)
* Memoria: \(O(1)\)

✔ Ventaja: realiza muy pocos intercambios (máximo \(n-1\))  
⚠️ Desventaja: siempre recorre toda la zona no ordenada aunque ya esté ordenado  
⚠️ No es estable (puede cambiar el orden relativo de elementos iguales)

---

### 💻 4.3. Código en C#

> 🔎 **¿Qué hace este ejemplo?**  
> Recibe el arreglo `{ 64, 25, 12, 22, 11 }` y lo ordena de menor a mayor.  
> En cada vuelta del bucle externo, recorre toda la zona no ordenada para encontrar el elemento mínimo y lo coloca al inicio de esa zona mediante un intercambio. Tras \(n-1\) vueltas, el arreglo queda completamente ordenado.  
> Al finalizar imprime: `Después: 11, 12, 22, 25, 64`.

```csharp
using System;

class SelectionSortDemo
{
    // Ordena el arreglo 'arr' de menor a mayor usando Selection Sort
    static void SelectionSort(int[] arr)
    {
        int n = arr.Length;

        // i representa el límite entre zona ordenada (izquierda) y no ordenada (derecha)
        // En cada iteración, colocamos el mínimo de la zona derecha en la posición i
        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i; // Asumimos que el mínimo está en la posición i

            // Recorremos toda la zona no ordenada buscando un valor más pequeño
            for (int j = i + 1; j < n; j++)
            {
                // Si encontramos un valor más pequeño, actualizamos minIndex
                if (arr[j] < arr[minIndex])
                    minIndex = j;
            }

            // Solo intercambiamos si el mínimo real no está ya en la posición i
            // Esto evita un intercambio innecesario cuando i ya tiene el mínimo
            if (minIndex != i)
            {
                int temp      = arr[i];
                arr[i]        = arr[minIndex]; // El mínimo va a su posición definitiva
                arr[minIndex] = temp;          // El elemento desplazado va al hueco
            }
        }
    }

    static void Main()
    {
        int[] data = { 64, 25, 12, 22, 11 };

        Console.WriteLine("Antes:   " + string.Join(", ", data));

        // Pasada 1 (i=0): encuentra 11 en posición 4, intercambia con 64 → [ppl-ai-file-upload.s3.amazonaws](https://ppl-ai-file-upload.s3.amazonaws.com/web/direct-files/collection_e78f29b2-ccbc-407e-8955-e169e9562bd9/27b54d29-f1fb-4744-88e3-1b075f3d18dc/git-flow.md)
        // Pasada 2 (i=1): encuentra 12 en posición 2, intercambia con 25 → [arxiv](https://arxiv.org/pdf/2305.07229.pdf)
        // Pasada 3 (i=2): encuentra 22 en posición 3, intercambia con 25 → [ppl-ai-file-upload.s3.amazonaws](https://ppl-ai-file-upload.s3.amazonaws.com/web/direct-files/collection_e78f29b2-ccbc-407e-8955-e169e9562bd9/df2dc6d3-ba04-42e8-b256-ba3e65d63a30/GIT.md)
        // Pasada 4 (i=3): 25 ya está en su lugar, no intercambia
        SelectionSort(data);

        Console.WriteLine("Después: " + string.Join(", ", data));
        // Resultado esperado: 11, 12, 22, 25, 64
    }
}
```

---

## 🧩 5. Insertion Sort (Ordenamiento por inserción)

### 💡 5.1. Idea general

Insertion Sort funciona exactamente como ordenamos cartas en la mano:

- **Zona izquierda (ordenada):** cartas ya colocadas en orden
- **Zona derecha (no ordenada):** cartas que aún no hemos procesado

El proceso funciona así:

1. Toma el **primer elemento** de la zona no ordenada (la "carta nueva")
2. Lo **compara** con los elementos de la zona ordenada, de derecha a izquierda
3. **Desplaza** hacia la derecha todos los elementos mayores que él
4. **Inserta** la carta nueva en el hueco que quedó libre
5. Repite con el siguiente elemento

La clave de su eficiencia es que si el arreglo ya está ordenado o casi ordenado, los desplazamientos son mínimos y se acerca a \(O(n)\).

---

### 📊 5.2. Complejidad

* Mejor caso: \(O(n)\) — arreglo ya ordenado, sin desplazamientos
* Promedio: \(O(n^2)\)
* Peor caso: \(O(n^2)\) — arreglo ordenado al revés, máximos desplazamientos
* Memoria: \(O(1)\)

✔ Muy eficiente para listas pequeñas (menos de ~20 elementos)  
✔ Excelente para listas casi ordenadas  
✔ Es **estable** (mantiene el orden relativo de elementos iguales)  
✔ TimSort lo usa internamente para ordenar sus runs

---

### 💻 5.3. Código en C#

> 🔎 **¿Qué hace este ejemplo?**  
> Recibe el arreglo `{ 12, 11, 13, 5, 6 }` y lo ordena de menor a mayor.  
> Toma cada elemento desde el índice 1 en adelante y lo "inserta" en el lugar correcto dentro de la parte izquierda ya ordenada, desplazando los elementos mayores hacia la derecha para abrirle espacio.  
> Al finalizar imprime: `Después: 5, 6, 11, 12, 13`.

```csharp
using System;

class InsertionSortDemo
{
    // Ordena el arreglo 'arr' de menor a mayor usando Insertion Sort
    static void InsertionSort(int[] arr)
    {
        int n = arr.Length;

        // Comenzamos desde el índice 1: el primer elemento (índice 0)
        // ya forma por sí solo una zona "ordenada" de un elemento
        for (int i = 1; i < n; i++)
        {
            int key = arr[i]; // Guardamos el elemento que vamos a insertar
            int j   = i - 1; // j apunta al último elemento de la zona ordenada

            // Desplazamos hacia la derecha todos los elementos de la zona ordenada
            // que sean mayores que key, abriendo espacio para insertar key
            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j]; // Mueve el elemento una posición a la derecha
                j--;                 // Retrocedemos hacia la izquierda
            }

            // j+1 es la posición correcta para key:
            // todos los elementos a su izquierda son menores o iguales,
            // y todos a su derecha son mayores
            arr[j + 1] = key;
        }
    }

    static void Main()
    {
        int[] data = { 12, 11, 13, 5, 6 };

        Console.WriteLine("Antes:   " + string.Join(", ", data));

        // i=1: key=11, desplaza 12          → [ppl-ai-file-upload.s3.amazonaws](https://ppl-ai-file-upload.s3.amazonaws.com/web/direct-files/collection_e78f29b2-ccbc-407e-8955-e169e9562bd9/9538e6ec-6c5d-4a2c-bb0d-5c73512f6084/CSharp.pdf)
        // i=2: key=13, no desplaza nada     → [ppl-ai-file-upload.s3.amazonaws](https://ppl-ai-file-upload.s3.amazonaws.com/web/direct-files/collection_e78f29b2-ccbc-407e-8955-e169e9562bd9/5c1bd1bd-39b4-492b-908d-f128b8cf14b2/HTML2025.md)
        // i=3: key=5,  desplaza 13, 12, 11  → [ 5, 11, 12, 13,  6]
        // i=4: key=6,  desplaza 13, 12, 11  → [ 5,  6, 11, 12, 13]
        InsertionSort(data);

        Console.WriteLine("Después: " + string.Join(", ", data));
        // Resultado esperado: 5, 6, 11, 12, 13
    }
}
```

---

## ⚡ 6. Merge Sort

### 💡 6.1. Idea general

Merge Sort aplica la estrategia **"divide y vencerás"**: en lugar de ordenar un problema grande, lo parte en problemas más pequeños hasta que sean triviales de resolver, y luego une los resultados.

El proceso funciona así:

1. **Divide** el arreglo por la mitad recursivamente hasta tener subarreglos de un solo elemento (que por definición ya están ordenados)
2. **Fusiona** pares de subarreglos ordenados en uno solo ordenado, comparando elemento por elemento
3. Repite la fusión subiendo niveles hasta reconstruir el arreglo completo y ordenado

La clave es que **fusionar dos mitades ya ordenadas es muy eficiente**: basta con un solo recorrido lineal comparando el frente de cada mitad. Por eso garantiza \(O(n \log n)\) en todos los casos.

---

### 📊 6.2. Complejidad

* Mejor caso: \(O(n \log n)\)
* Promedio: \(O(n \log n)\)
* Peor caso: \(O(n \log n)\)
* Memoria: \(O(n)\)

✔ **Estable** (mantiene el orden relativo de elementos iguales)  
✔ Rendimiento garantizado sin importar los datos de entrada  
✔ Ideal para ordenar listas enlazadas y datos externos (archivos grandes)  
⚠️ Requiere memoria adicional proporcional a \(n\) para los arreglos temporales

---

### 💻 6.3. Código en C#

> 🔎 **¿Qué hace este ejemplo?**  
> Recibe el arreglo `{ 3, 7, 6, -10, 15, 23, 55, -13 }` y lo ordena de menor a mayor.  
> `MergeSort` divide recursivamente el arreglo en mitades hasta llegar a subarreglos de un solo elemento. Luego `Merge` va fusionando esas mitades de a pares, comparando sus elementos uno a uno para producir segmentos ordenados cada vez más grandes, hasta reconstruir el arreglo completo.  
> Al finalizar imprime: `Después: -13, -10, 3, 6, 7, 15, 23, 55`.

```csharp
using System;

class MergeSortDemo
{
    // ─────────────────────────────────────────────────────────
    // PASO 1: Merge (fusión)
    // Recibe dos mitades YA ordenadas: arr[left..mid] y arr[mid+1..right]
    // Las combina en un único segmento ordenado dentro del mismo arr
    // ─────────────────────────────────────────────────────────
    static void Merge(int[] arr, int left, int mid, int right)
    {
        int n1 = mid - left + 1; // Cantidad de elementos en la mitad izquierda
        int n2 = right - mid;    // Cantidad de elementos en la mitad derecha

        // Creamos arreglos temporales para no sobreescribir datos mientras fusionamos
        int[] L = new int[n1];
        int[] R = new int[n2];

        // Copiamos los datos originales en los temporales
        for (int i = 0; i < n1; i++)
            L[i] = arr[left + i];

        for (int j = 0; j < n2; j++)
            R[j] = arr[mid + 1 + j];

        int iL = 0;    // Índice para recorrer L
        int iR = 0;    // Índice para recorrer R
        int k  = left; // Índice para escribir en arr

        // Comparamos el frente de L y R, y escribimos el menor en arr
        // Este proceso garantiza que arr[left..right] quede ordenado
        while (iL < n1 && iR < n2)
        {
            if (L[iL] <= R[iR])
            {
                arr[k] = L[iL]; // El elemento de L es menor o igual, lo tomamos
                iL++;
            }
            else
            {
                arr[k] = R[iR]; // El elemento de R es menor, lo tomamos
                iR++;
            }
            k++;
        }

        // Si quedaron elementos en L sin copiar, los agregamos directamente
        // (ya están ordenados y son todos mayores que los últimos de R)
        while (iL < n1) { arr[k] = L[iL]; iL++; k++; }

        // Si quedaron elementos en R sin copiar, los agregamos directamente
        while (iR < n2) { arr[k] = R[iR]; iR++; k++; }
    }

    // ─────────────────────────────────────────────────────────
    // PASO 2: MergeSort recursivo
    // Divide el segmento arr[left..right] en dos mitades,
    // ordena cada mitad recursivamente y luego las fusiona
    // ─────────────────────────────────────────────────────────
    static void MergeSort(int[] arr, int left, int right)
    {
        // Caso base: un subarreglo de 0 o 1 elemento ya está ordenado
        if (left >= right)
            return;

        // Calculamos el punto medio usando esta fórmula para evitar overflow
        // en arreglos muy grandes (en lugar de (left + right) / 2)
        int mid = left + (right - left) / 2;

        MergeSort(arr, left, mid);      // Ordenamos recursivamente la mitad izquierda
        MergeSort(arr, mid + 1, right); // Ordenamos recursivamente la mitad derecha

        // Ahora ambas mitades están ordenadas: las fusionamos
        Merge(arr, left, mid, right);
    }

    static void Main()
    {
        int[] data = { 3, 7, 6, -10, 15, 23, 55, -13 };

        Console.WriteLine("Antes:   " + string.Join(", ", data));

        // MergeSort divide hasta subarreglos de 1 elemento,
        // luego Merge los va uniendo: primero pares, luego grupos de 4, de 8...
        MergeSort(data, 0, data.Length - 1);

        Console.WriteLine("Después: " + string.Join(", ", data));
        // Resultado esperado: -13, -10, 3, 6, 7, 15, 23, 55
    }
}
```

---

## 🔄 7. TimSort (Ordenamiento híbrido)

### 💡 7.1. Idea general

TimSort es el algoritmo de ordenamiento que usa internamente **Python, Java y .NET** en sus métodos `Array.Sort()` y `List.Sort()`. Es un algoritmo **híbrido** que combina dos algoritmos que ya viste:

- **Insertion Sort** → para segmentos pequeños (muy eficiente en listas cortas o casi ordenadas)
- **Merge Sort** → para fusionar esos segmentos en orden

El proceso funciona así:

1. Divide el arreglo en bloques pequeños llamados **runs** (de tamaño `RUN`, típicamente entre 32 y 64)
2. Ordena cada run con **Insertion Sort**
3. Fusiona los runs ordenados con **Merge Sort** hasta tener el arreglo completo

La clave de su eficiencia es que detecta y aprovecha secuencias ya ordenadas que existen naturalmente en los datos del mundo real.

---

### 📊 7.2. Complejidad

* Mejor caso: \(O(n)\) — el arreglo ya está ordenado, cada run no necesita trabajo
* Promedio: \(O(n \log n)\)
* Peor caso: \(O(n \log n)\)
* Memoria: \(O(n)\)

✔ **Estable** (mantiene el orden relativo de elementos iguales)  
✔ Muy eficiente con datos del mundo real (parcialmente ordenados)  
✔ Es el algoritmo que usa `Array.Sort()` en .NET internamente  
⚠️ Más complejo de implementar que los algoritmos simples

---

### 💻 7.3. Código en C#

> 🔎 **¿Qué hace este ejemplo?**  
> Recibe el arreglo `{ 64, 34, 25, 12, 22, 11, 90, 5, 77, 43, 18, 3 }` y lo ordena de menor a mayor en dos fases.  
> **Fase 1:** divide el arreglo en bloques (runs) de hasta 32 elementos y ordena cada uno con Insertion Sort.  
> **Fase 2:** fusiona esos runs de a pares usando Merge Sort, duplicando el tamaño de los bloques fusionados en cada ronda hasta que todo el arreglo queda ordenado.  
> Al finalizar imprime: `Después: 3, 5, 11, 12, 18, 22, 25, 34, 43, 64, 77, 90`.

```csharp
using System;

class TimSortDemo
{
    // Tamaño de cada "run" (bloque pequeño que se ordena con Insertion Sort)
    // En implementaciones reales suele ser entre 32 y 64
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
```

---

## 🚀 8. Quick Sort

### 💡 8.1. Idea general

Quick Sort también aplica **"divide y vencerás"**, pero de una forma distinta a Merge Sort: en lugar de dividir por la mitad, elige un **pivote** y reorganiza todos los elementos alrededor de él.

El proceso funciona así:

1. Elige un elemento como **pivote** (en esta implementación, el último elemento)
2. **Particiona** el arreglo: mueve todos los elementos menores o iguales al pivote a su izquierda, y los mayores a su derecha
3. El pivote queda en su **posición definitiva** en el arreglo ordenado
4. Aplica recursión en el subarreglo izquierdo y en el derecho por separado

La clave es que la partición coloca el pivote exactamente donde debe estar, reduciendo el problema en dos subproblemas independientes. En promedio divide el arreglo en mitades similares, logrando \(O(n \log n)\).

---

### 📊 8.2. Complejidad

* Mejor caso: \(O(n \log n)\) — el pivote siempre divide en mitades iguales
* Promedio: \(O(n \log n)\)
* Peor caso: \(O(n^2)\) — el pivote siempre es el mínimo o máximo
* Memoria: \(O(\log n)\) — pila de llamadas recursivas

✔ En la práctica es uno de los algoritmos más rápidos para datos en memoria  
✔ Opera **in-place**: no necesita arreglos auxiliares grandes  
⚠️ No es estable  
⚠️ El peor caso se puede mitigar eligiendo el pivote aleatoriamente

---

### 💻 8.3. Código en C#

> 🔎 **¿Qué hace este ejemplo?**  
> Recibe el arreglo `{ 10, 7, 8, 9, 1, 5 }` y lo ordena de menor a mayor.  
> `Partition` toma el último elemento como pivote (`5`), recorre el arreglo y mueve todos los elementos menores o iguales a su izquierda, colocando al final el pivote en su posición definitiva. `QuickSort` llama recursivamente a `Partition` sobre los subarreglos izquierdo y derecho hasta que todos los elementos están en su posición correcta.  
> Al finalizar imprime: `Después: 1, 5, 7, 8, 9, 10`.

```csharp
using System;

class QuickSortDemo
{
    // ─────────────────────────────────────────────────────────
    // PASO 1: Partition (partición)
    // Reorganiza arr[low..high] de forma que:
    //   → Todos los elementos <= pivote queden a su izquierda
    //   → Todos los elementos >  pivote queden a su derecha
    //   → El pivote quede en su posición definitiva
    // Devuelve el índice final del pivote
    // ─────────────────────────────────────────────────────────
    static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high]; // Elegimos el último elemento como pivote
        int i = low - 1;       // i es el límite de la "zona de menores/iguales"
                               // Empieza en low-1 porque aún no hay ningún elemento en esa zona

        // Recorremos desde low hasta high-1 (sin incluir al pivote)
        for (int j = low; j < high; j++)
        {
            // Si el elemento actual es menor o igual al pivote,
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
        int temp1  = arr[i + 1];
        arr[i + 1] = arr[high]; // El pivote va a su posición definitiva
        arr[high]  = temp1;     // El elemento que estaba ahí va al lugar del pivote

        return i + 1; // Devolvemos la posición final del pivote
    }

    // ─────────────────────────────────────────────────────────
    // PASO 2: QuickSort recursivo
    // 1. Llama a Partition para colocar el pivote en su lugar
    // 2. Aplica recursión al subarreglo izquierdo (menores/iguales al pivote)
    // 3. Aplica recursión al subarreglo derecho (mayores al pivote)
    // ─────────────────────────────────────────────────────────
    static void QuickSort(int[] arr, int low, int high)
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

    static void Main()
    {
        int[] data = { 10, 7, 8, 9, 1, 5 };

        Console.WriteLine("Antes:   " + string.Join(", ", data));

        // Primera llamada: pivote = 5 (arr) [ppl-ai-file-upload.s3.amazonaws](https://ppl-ai-file-upload.s3.amazonaws.com/web/direct-files/collection_e78f29b2-ccbc-407e-8955-e169e9562bd9/5c1bd1bd-39b4-492b-908d-f128b8cf14b2/HTML2025.md)
        // Partition deja:  con 5 en índice 1 [ppl-ai-file-upload.s3.amazonaws](https://ppl-ai-file-upload.s3.amazonaws.com/web/direct-files/collection_e78f29b2-ccbc-407e-8955-e169e9562bd9/c2c85a63-8f90-4825-aba9-bc09ea418800/RecorridoGrafos.pdf)
        // Recursión izquierda:  → ya ordenado [ppl-ai-file-upload.s3.amazonaws](https://ppl-ai-file-upload.s3.amazonaws.com/web/direct-files/collection_e78f29b2-ccbc-407e-8955-e169e9562bd9/c2c85a63-8f90-4825-aba9-bc09ea418800/RecorridoGrafos.pdf)
        // Recursión derecha:    → pivote=7, continúa recursión... [ppl-ai-file-upload.s3.amazonaws](https://ppl-ai-file-upload.s3.amazonaws.com/web/direct-files/collection_e78f29b2-ccbc-407e-8955-e169e9562bd9/3d94ab98-0995-4448-93bb-bce988395395/PythonBKEducate.md)
        QuickSort(data, 0, data.Length - 1);

        Console.WriteLine("Después: " + string.Join(", ", data));
        // Resultado esperado: 1, 5, 7, 8, 9, 10
    }
}
```

---

## 📊 9. Tabla comparativa de algoritmos de ordenamiento

| Algoritmo      | Mejor caso      | Promedio        | Peor caso       | Memoria extra | Comentario principal                                         |
| -------------- | --------------- | --------------- | --------------- | ------------- | ------------------------------------------------------------ |
| Selection Sort | \(O(n^2)\)      | \(O(n^2)\)      | \(O(n^2)\)      | \(O(1)\)      | Pocos intercambios, pero lento. No estable.                  |
| Insertion Sort | \(O(n)\)        | \(O(n^2)\)      | \(O(n^2)\)      | \(O(1)\)      | Excelente para listas pequeñas o casi ordenadas. Estable.    |
| Merge Sort     | \(O(n \log n)\) | \(O(n \log n)\) | \(O(n \log n)\) | \(O(n)\)      | Rendimiento garantizado. Estable. Ideal para datos externos. |
| TimSort        | \(O(n)\)        | \(O(n \log n)\) | \(O(n \log n)\) | \(O(n)\)      | Híbrido real (Insertion + Merge). Usado en .NET, Python, Java. |
| Quick Sort     | \(O(n \log n)\) | \(O(n \log n)\) | \(O(n^2)\)      | \(O(\log n)\) | Muy rápido en promedio. In-place. No estable.                |

---

## 🧭 10. Algoritmo de Dijkstra (caminos más cortos)

Aunque no es un algoritmo de ordenamiento, Dijkstra se basa en la idea de **seleccionar repetidamente el vértice con menor distancia provisional** usando una cola de prioridad.

---

### 🎯 10.1. ¿Qué problema resuelve?

* Camino más corto desde una fuente
* Pesos no negativos
* Grafo dirigido o no dirigido

---

### 💡 10.2. Idea intuitiva

1. Distancias = infinito
2. Origen = 0
3. Elegir menor distancia
4. Relajar vecinos

---

### 📊 10.3. Complejidad

* \(O(V^2)\)
* \(O((V + E)\log V)\) con heap
* Memoria: \(O(V)\)

---

### ⚠️ 10.4. Limitaciones

* No admite pesos negativos
* No detecta ciclos negativos
* Solo una fuente

---

### 💻 10.5. Ejemplo sencillo de Dijkstra en C#

Grafo muy simple:

- `0 --2--> 1 --3--> 2`

> 🔎 **¿Qué hace este ejemplo?**  
> Construye un grafo dirigido de 3 nodos con dos aristas: `0→1` con peso 2 y `1→2` con peso 3.  
> `Dijkstra` parte del nodo `0` con distancia `0` y usa una cola de prioridad para explorar siempre el nodo con menor distancia conocida. En cada paso "relaja" las aristas del nodo actual: si llegar a un vecino pasando por este nodo es más corto que la distancia que ya teníamos, la actualiza.  
> Al finalizar imprime: `dist[0→0] = 0`, `dist[0→1] = 2`, `dist[0→2] = 5`.

```csharp
using System;
using System.Collections.Generic;

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
    // Devuelve dist[] donde dist[i] = distancia mínima de s a i
    // ─────────────────────────────────────────────────────────
    static int[] Dijkstra(List<Edge>[] g, int s)
    {
        int n = g.Length;

        int[]  dist = new int[n];  // dist[i] = mejor distancia conocida de s a i
        bool[] vis  = new bool[n]; // vis[i]  = true si ya encontramos la distancia definitiva de i

        const int INF = int.MaxValue; // Usamos int.MaxValue como "infinito" inicial

        // Paso 1: inicializamos todas las distancias a "infinito"
        for (int i = 0; i < n; i++)
            dist[i] = INF;

        dist[s] = 0; // La distancia del origen a sí mismo siempre es 0

        // Cola de prioridad: extrae siempre el nodo con MENOR distancia provisional
        // Parámetros: (elemento, prioridad) → ordena por prioridad de menor a mayor
        var pq = new PriorityQueue<int, int>();
        pq.Enqueue(s, 0); // Insertamos el nodo origen con distancia 0

        while (pq.Count > 0)
        {
            // Extraemos el nodo 'u' con la menor distancia provisional actual
            pq.TryDequeue(out int u, out int d);

            // Si ya procesamos este nodo (puede estar duplicado en la cola), lo ignoramos
            if (vis[u])
                continue;

            vis[u] = true; // Marcamos 'u' como procesado: dist[u] ya es definitivo

            // Recorremos todas las aristas que salen de u
            foreach (var e in g[u])
            {
                int v = e.To; // Nodo vecino al que podemos llegar desde u
                int w = e.W;  // Costo de ir de u a v

                // "Relajación": ¿es más corto ir de s→u→v que la distancia que ya teníamos a v?
                // La condición dist[u] != INF evita overflow al sumar INF + w
                if (dist[u] != INF && dist[u] + w < dist[v])
                {
                    dist[v] = dist[u] + w;  // Actualizamos la distancia mínima a v
                    pq.Enqueue(v, dist[v]); // Reinsertamos v con su nueva prioridad
                }
            }
        }

        return dist; // Devolvemos el arreglo con todas las distancias mínimas desde s
    }

   static void Main()
    {
        // Construimos el grafo: 3 nodos (0, 1, 2) con aristas dirigidas
        // Estructura: 0 --2--> 1 --3--> 2
        var g = new List<Edge>;[13]
        for (int i = 0; i < 3; i++)
            g[i] = new List<Edge>(); // Inicializamos la lista de aristas de cada nodo

        g.Add(new Edge(1, 2)); // Arista: nodo 0 → nodo 1, peso 2
        g.Add(new Edge(2, 3)); // Arista: nodo 1 → nodo 2, peso 3[8]
        // Nodo 2 no tiene aristas salientes

        int[] dist = Dijkstra(g, 0); // Ejecutamos Dijkstra desde el nodo 0

        Console.WriteLine("Dijkstra (origen 0):");
        for (int i = 0; i < dist.Length; i++)
            Console.WriteLine($"  dist[0 -> {i}] = {dist[i]}");

        // Resultado esperado:
        // dist[0 -> 0] = 0  (el origen a sí mismo siempre es 0)
        // dist[0 -> 1] = 2  (camino directo 0→1 con peso 2)
        // dist[0 -> 2] = 5  (camino 0→1→2 con peso 2+3=5)
    }
}
```

---

## 🏁 11. Conclusiones

* ✔ Los algoritmos de ordenamiento son esenciales
* ✔ Big O permite comparar eficiencia
* ✔ Para listas grandes → \(O(n \log n)\)
* ✔ Para listas pequeñas → Insertion Sort
* ✔ TimSort combina lo mejor de ambos mundos y es el estándar en producción

