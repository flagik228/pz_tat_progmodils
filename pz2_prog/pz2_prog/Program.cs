using System;

int[,] graph = {
{ 0, 1, 1, 0, 0},
    { 0, 0, 0, 1, 0},
    { 0, 1, 0, 0, 1},
    { 0, 0, 1, 0, 0},
    { 0, 0, 0, 1, 0}
};

int n = graph.GetLength(0);
int[,] reachabilityMatrix = new int[n, n];

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        reachabilityMatrix[i, j] = graph[i, j];
    }
}

for (int k = 0; k < n; k++)
{
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            reachabilityMatrix[i, j] = reachabilityMatrix[i, j] | (reachabilityMatrix[i, k] & reachabilityMatrix[k, j]);
        }
    }
}


//После построения матрицы достижимости делаем проверку, является ли граф связным. Для этого нужно проверить, все ли элементы матрицы равны 1:

bool isGraphConnected = true;

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        if (reachabilityMatrix[i, j] != 1)
        {
            isGraphConnected = false;
            break;
        }
    }
}

Console.WriteLine("Граф является связным: " + isGraphConnected);


//Реализация алгоритма Дейкстра для поиска кратчайших путей из заданной вершины в произвольные вершины

int sourceVertex = 0; // Заданная вершина

int[] distances = new int[n];
bool[] visited = new bool[n];

for (int i = 0; i < n; i++)
{
    distances[i] = int.MaxValue;
    visited[i] = false;
}

distances[sourceVertex] = 0;

for (int count = 0; count < n - 1; count++)
{
    int minDistanceVertex = -1;
    int minDistance = int.MaxValue;

    for (int v = 0; v < n; v++)
    {
        if (!visited[v] && distances[v] < minDistance)
        {
            minDistance = distances[v];
            minDistanceVertex = v;
        }
    }

    visited[minDistanceVertex] = true;

    for (int v = 0; v < n; v++)
    {
        int dist = distances[minDistanceVertex] + graph[minDistanceVertex, v];
        if (!visited[v] && graph[minDistanceVertex, v] != 0 && dist < distances[v])
        {
            distances[v] = dist;
        }
    }
}

Console.WriteLine("Длины кратчайших путей из заданной вершины:");

for (int i = 0; i < n; i++)
{
    Console.WriteLine("Вершина " + i + ": " + distances[i]);
}

