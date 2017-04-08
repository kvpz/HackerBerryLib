using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimilarPair
{
    public class Node
    {
        public int value { get; set; }
        public Node Parent { get; set; }
        public Node Child { get; set; }
    }

    public class Graph<T> where T : Node, new()
    {
        //public List<List<Node>> _adjMatrix { get; set; }
        public List<List<T>> _adjMatrix { get; set; }
        public Graph() { }

        public Graph(int totalVertices)
        {
            //_adjMatrix = new List<List<Node>>(totalVertices);
            _adjMatrix = new List<List<T>>(totalVertices);
            for (int i = 0; i < totalVertices; ++i)
            {
                _adjMatrix.Add(new List<T>()); //new int[totalVertices]));
                //_adjMatrix.Add(new List<Node>()); //new Node[totalVertices]));
            }
        }

        public Graph(int totalVertices, int totalEdges)
        {
            //_adjMatrix = new List<List<Node>>(totalVertices);
            _adjMatrix = new List<List<T>>(totalVertices);
            for (int i = 0; i < totalVertices; ++i)
            {
                _adjMatrix.Add(new List<T>()); //new int[totalVertices]));
                //_adjMatrix.Add(new List<Node>(new Node[totalVertices]));
            }
        }

        //public void AddEdge(int from, int to)
        public void AddEdge(int from, int to) //where T : Node
        {
            /*
            _adjMatrix[from].Add(to);
            _adjMatrix[to].Add(from);
            */
            
            T fromNode = new T() { value = from };
            T toNode = new T() { value = to };
            fromNode.Child = toNode;
            toNode.Parent = fromNode;
            _adjMatrix[from].Add(toNode);
            _adjMatrix[to].Add(fromNode);
            
        }
    }

    public class GraphUtility
    {
        public List<bool> visited { get; set; }
        public uint totalSpecialPairs { get; set; }
        public int currentParentValue { get; set; }
        public int specialKCondition { get; set; }

        public bool MeetPairCondition(Node b)
        {
            //if (b.value == currentParentValue)
            //    return false;
            bool condition = Math.Abs(currentParentValue - b.value) <= specialKCondition;
            if (condition == true && b.Parent != null && b.Parent.value == currentParentValue)
                return true;
            return false;
        }

        public GraphUtility()
        {
            visited = new List<bool>();
        }

        public GraphUtility(int totalVertices)
        {
            visited = new List<bool>(totalVertices);
            for(int i = 0; i < totalVertices; ++i)
            {
                visited.Add(false);
            }
        }

        public void DFS(Node node, Graph<Node> _g)
        {
            visited[node.value] = true;
            //Console.WriteLine(node.value + 1);
            if(MeetPairCondition(node))
            {
                ++totalSpecialPairs;
                Console.WriteLine($"Special pair: {currentParentValue} , {node.value}");
            }
            foreach(Node n in _g._adjMatrix[node.value])
            {
                if(!visited[n.value])
                {
                    DFS(n, _g);
                }
            }
            Console.WriteLine("-----------------------");
        }
    }

    public class SimilarPair
    {
        /*
            Main program. About:
            The goal of this program is to find the number of similar pairs (a,b) satisfying the 
            following conditions: 
            1. Node a is the ancestor of node b
            2. abs(a - b) <= k, where k is an arbitrary qualifier 

            The goal is to determine the amount of similar pairs in the tree.
        */
        public void Run()
        {
            // Get two space separated integers representing # of nodes (n) & similar pair qualifier (k)
            string[] input = Console.ReadLine().Split(' ');
            int n = Int32.Parse(input[0]);
            int k = Int32.Parse(input[1]);
            Graph<Node> graph = new Graph<Node>(n);
            //List<Node> parentNodes = new List<Node>();
            List<int> parentNodes = new List<int>();
            
            // Collect the edges to form the graph
            // Note: The first node in the line is said to be the parent of the second node. Each node <= n.
            for(int i = 0; i < n - 1; ++i)
            {
                input = Console.ReadLine().Split(' ');
                int parent = Int32.Parse(input[0]) - 1;
                int child = Int32.Parse(input[1]) - 1;
                parentNodes.Add(parent);
                graph.AddEdge(parent, child);
            }

            GraphUtility gutility = new GraphUtility(n);
            //gutility.DFS(new Node() { value = 0 }, graph);

            foreach(int parentNode in parentNodes)
            {
                Console.WriteLine($"For parent node {parentNode}:");
                gutility.currentParentValue = parentNode;
                gutility.specialKCondition = k;
                gutility.DFS(new Node() { value = parentNode }, graph);
                gutility.visited = new List<bool>(new bool[n]);
                gutility.visited.ForEach(x => x = false);
            }

            Console.WriteLine(gutility.totalSpecialPairs);
        }
    }
}
