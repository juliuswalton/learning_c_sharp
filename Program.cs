class Graph
{
    private int vertices;
    private List<int>[] adjacencyList;

    public Graph(int v)
    {
        vertices = v;
        adjacencyList = new List<int>[v];
        for (int i = 0; i < v; i++)
        {
            adjacencyList[i] = new List<int>();
        }

    }

    public void AddEdge(int v, int w)
    {
        adjacencyList[v].Add(w);
    }

    void DfsUtil(int v, bool[] visited)
    {
        visited[v] = true;
        Console.Write(v + " ");

        List<int> vertexList = adjacencyList[v];

        foreach (var vertex in vertexList)
        {
            if (!visited[vertex])
            {
                DfsUtil(vertex, visited);
            }
        }
    }

    public void DFS(int v)
    {
        bool[] visited = new bool[vertices];
        DfsUtil(v, visited);
    }


    public void BFS(int startNode)
    {
        Queue<int> queue = new Queue<int>();
        bool[] visited = new bool[vertices];

        visited[startNode] = true;
        queue.Enqueue(startNode);

        while (queue.Count != 0)
        {
            int currentNode = queue.Dequeue();
            Console.Write(currentNode + " ");

            foreach (int neighbor in adjacencyList[currentNode])
            {
                if (!visited[neighbor])
                {
                    visited[neighbor] = true;
                    queue.Enqueue(neighbor);
                }
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Graph graph = new Graph(4);
        graph.AddEdge(0, 1);
        graph.AddEdge(0, 2);
        graph.AddEdge(1, 2);
        graph.AddEdge(2, 0);
        graph.AddEdge(2, 3);
        graph.AddEdge(3, 3);

        Console.WriteLine("DFS starting from vertex 2:");
        graph.DFS(2);
        Console.WriteLine();

        Console.WriteLine("BFS starting from vertex 2:");
        graph.BFS(2);
        Console.WriteLine();
    }
}