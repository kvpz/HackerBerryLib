using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DijkstraShortestReach
{

    public class GraphUtility
    {
        public static void PrintQueue(SortedSet<Tuple<int,int>>.Enumerator Q)
        {
            Console.WriteLine();
            while(Q.MoveNext())
            {
                Console.Write($"{Q.Current.Item1} ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Iterative dijkstra.
        /// </summary>
        /// <param name="n">The total amount of vertices in the graph.</param>
        /// <param name="source">The vertice at which the search will start.</param>
        /// <param name="G">The graph of which will be searched. Each tuple represents the node recieving the edge and the weight.</param>
        /// <param name="D">A list representing the </param>
        public void Dijkstra(int n, int source, ref List<Tuple<int, int>>[] G, ref List<int> short_paths)
        {
            // Set the shortest path for the node to itself (which is 0).
            short_paths[source] = 0;

            // Priority Queue as used in DFS to maintain the values of the nodes already visited. Tuple< Distance, FromNode >
            SortedSet<Tuple<int, int>> Q = new SortedSet<Tuple<int, int>>();
            
            // Add the distance from the source node to itself.
            Q.Add(Tuple.Create(0, source));

            while (Q.Any())
            {
                SortedSet<Tuple<int, int>>.Enumerator top = Q.GetEnumerator();
                top.MoveNext();
                int u = top.Current.Item2;

                Q.Remove(top.Current);

                foreach (var next in G[u])
                {
                    int v = next.Item1;
                    int weight = next.Item2;
                    int new_weight = short_paths[u] + weight;

                    if (new_weight < short_paths[v])
                    {
                        int tempDv = short_paths[v];
                        Tuple<int, int> Qtemp = Q.FirstOrDefault(pred => pred.Item1 == tempDv && pred.Item2 == v);
                        if (Qtemp != null && Qtemp != Q.Last())
                        {
                            Q.Remove(Qtemp);
                        }

                        short_paths[v] = new_weight;
                        Q.Add(Tuple.Create(short_paths[v], v));
                    }
                }
            }
        }
    }

    /*
        Given a graph consisting of N nodes (labeled 1 to N) where a specific node S represents
        the starting position and an edge between two nodes is of a given length, which may or may
        not be equal to other lengths in the graph.

        It is required to calculate the shortest distance from the start position (Node S) to all of
        the other nodes in the graph.

        If a node is unreachable, the distance is assumed -1.

        The node values are not "zero-based" so care must be taken to make the array(s) of size N + 1;
    */ 
     
    public class DijkstraShortestReach
    {
        public void Run()
        {
            int numberOfTestCases = Int32.Parse(Console.ReadLine());
            
            for(int test = 0; test < numberOfTestCases; ++test)
            {
                int number_of_nodes, number_of_edges;
                string[] inputNM = Console.ReadLine().Split(' ');
                number_of_nodes = Int32.Parse(inputNM[0]) + 1;
                number_of_edges = Int32.Parse(inputNM[1]);

                List<Tuple<int, int>>[] G = new List<Tuple<int, int>>[number_of_nodes];

                for (int i = 0; i < number_of_nodes; ++i)
                    G[i] = new List<Tuple<int, int>>(); 

                for (int edge = 0; edge < number_of_edges; ++edge)
                {
                    int node_x, node_y, edge_length; // note, x and y form an undirected edge; they may be repeated with different edge weights
                    string[] inputXYR = Console.ReadLine().Split(' ');
                    node_x = Int32.Parse(inputXYR[0]);
                    node_y = Int32.Parse(inputXYR[1]);
                    edge_length = Int32.Parse(inputXYR[2]);

                    G[node_x].Add(Tuple.Create(node_y, edge_length));
                    G[node_y].Add(Tuple.Create(node_x, edge_length));
                }

                int S = Int32.Parse(Console.ReadLine()); // the starting vertex

                List<int> short_paths = new List<int>(new int[number_of_nodes]);
                for (int si = 0; si < number_of_nodes; ++si)
                    short_paths[si] = (int)1e9;

                GraphUtility graphUtility = new GraphUtility();
                graphUtility.Dijkstra(number_of_nodes, S, ref G, ref short_paths);

                // Printing each shortest distance from S to another node (except for S itself).
                for(int i = 1; i < number_of_nodes; ++i)
                {
                    if(i != S)
                    {
                        if(short_paths[i] != (int)1e9)
                        {
                            Console.Write($"{short_paths[i]} ");
                        }
                        else
                        {
                            Console.Write("-1");
                        }
                    }
                }
                

            }
        }
    }
}
