using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraShortestReach
{
    public class Pair
    {

    }

    public class GraphUtility
    {
        public void Dijkstra(int n, int source, List<Tuple<int,int>>[] G, ref List<int> D)
        //public void Dijkstra(int n, int source, List<List<Tuple<int, int>>> G, ref List<int> D)
        {
            //int infinity = (int)1e9;
            D[source] = 0;
            SortedSet<Tuple<int, int>> Q = new SortedSet<Tuple<int, int>>();
            Q.Add(Tuple.Create(0, source));

            while(Q.Any())
            {
                var top = Q.GetEnumerator();
                top.MoveNext();
                int u = top.Current.Item2;

                Q.Remove(top.Current);

                foreach(var next in G[u])
                {
                    int v = next.Item1;
                    int weight = next.Item2;
                    int new_weight = D[u] + weight;

                    if (new_weight < D[v])
                    {
                        int tempDv = D[v];
                        var Qtemp = Q.FirstOrDefault(pred => pred.Item1 == tempDv && pred.Item2 == v);
                        if (Qtemp != null && Qtemp != Q.Last())
                        {
                            Q.RemoveWhere(pred => pred.Item1 == tempDv && pred.Item2 == v);
                        }

                        D[v] = new_weight;
                        Q.Add(Tuple.Create(D[v], v));
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
                //List<List<Tuple<int, int>>> G = new List<List<Tuple<int, int>>>(number_of_nodes);
                //G.ForEach(a => new List<Tuple<int, int>>());
                for (int i = 0; i < number_of_nodes; ++i)
                    G[i] = new List<Tuple<int, int>>(); //new Tuple<int,int>[number_of_nodes]);

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
                graphUtility.Dijkstra(number_of_nodes, S, G, ref short_paths);

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
