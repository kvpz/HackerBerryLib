using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections;

namespace DijkstraShortestReach
{
    public class GraphUtility_1
    {
        public static void PrintQueue(SortedSet<MyTuple<int,int>>.Enumerator Q)
        {
            Console.WriteLine();
            while(Q.MoveNext())
            {
                Console.Write($"{Q.Current.Item1} ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Iterative dijkstra. Complexity: O( # of Edges * Log(# of vertices) )
        /// </summary>
        /// <param name="n">The total amount of vertices in the graph.</param>
        /// <param name="source">The vertice at which the search will start.</param>
        /// <param name="G">The graph of which will be searched. Each tuple is represented as Tuple( To_Node, Weight ) </param>
        /// <param name="D">A list representing the </param>
        public void Dijkstra(int n, int source, ref List<MyTuple<int, int>>[] G, ref List<int> shortest_path_to)
        {
            // Set the shortest path for the node to itself (which is 0).
            shortest_path_to[source] = 0;

            // Priority Queue as used in DFS to maintain the values of the nodes already visited. Tuple< Distance, FromNode >
            LinkedList<MyTuple<int, int>> Q = new LinkedList<MyTuple<int, int>>();

            Q.AddLast(MyTuple<int,int>.Create(0, source));

            while (Q.Any())
            {
                int u = Q.First.Value.Item2;
                Q.RemoveFirst();

                foreach (var next in G[u])
                {
                    int new_weight = shortest_path_to[u] + next.Item2;

                    if (new_weight < shortest_path_to[next.Item1])
                    {
                        int temp_shortest_path = shortest_path_to[next.Item1];

                        MyTuple<int, int> Qtemp = Q.Find(next)?.Value; 

                        if (Qtemp != null) 
                        {
                            //Q.Remove(Qtemp); // O(N)
                            Q.Remove(Q.Find(Qtemp)); // O(1) 
                        }

                        shortest_path_to[next.Item1] = new_weight;
                        Q.AddLast(MyTuple<int,int>.Create(shortest_path_to[next.Item1], next.Item1));
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

                List<MyTuple<int, int>>[] G = new List<MyTuple<int, int>>[number_of_nodes];

                for (int i = 0; i < number_of_nodes; ++i)
                    G[i] = new List<MyTuple<int, int>>(); 

                for (int edge = 0; edge < number_of_edges; ++edge)
                {
                    int node_x, node_y, edge_length; // note, x and y form an undirected edge; they may be repeated with different edge weights
                    string[] inputXYR = Console.ReadLine().Split(' ');
                    node_x = Int32.Parse(inputXYR[0]);
                    node_y = Int32.Parse(inputXYR[1]);
                    edge_length = Int32.Parse(inputXYR[2]);

                    G[node_x].Add(MyTuple<int,int>.Create(node_y, edge_length));
                    G[node_y].Add(MyTuple<int,int>.Create(node_x, edge_length));
                }

                int S = Int32.Parse(Console.ReadLine()); // the starting vertex

                List<int> shortest_path_to = new List<int>(new int[number_of_nodes]);
                for (int si = 0; si < number_of_nodes; ++si)
                    shortest_path_to[si] = (int)1e9;

                GraphUtility_1 graphUtility = new GraphUtility_1();
                graphUtility.Dijkstra(number_of_nodes, S, ref G, ref shortest_path_to);

                // Printing each shortest distance from S to another node (except for S itself).
                for(int i = 1; i < number_of_nodes; ++i)
                {
                    if(i != S)
                    {
                        if(shortest_path_to[i] != (int)1e9)
                        {
                            Console.Write($"{shortest_path_to[i]} ");
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
