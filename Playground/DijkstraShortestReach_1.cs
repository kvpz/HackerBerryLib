using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraShortestReach
{
    public class MyTuple<T1, T2> : IEqualityComparer<MyTuple<T1, T2>>
    {
        public int Item1 { get; set; }
        public int Item2 { get; set; }
        public bool Equals(MyTuple<T1, T2> x, MyTuple<T1, T2> y)
        {
            return x.Item1 == y.Item1 && x.Item2 == y.Item2;
        }

        public bool Equals(MyTuple<T1, T2> obj)
        {
            return this.Equals(this, obj);
        }

        public int GetHashCode(MyTuple<T1, T2> obj)
        {
            return obj.GetHashCode();
        }

        public static MyTuple<int, int> Create(int a, int b)
        {
            return new MyTuple<int, int>() { Item1 = a, Item2 = b };
        }
    }

    public class GraphUtility
    {
        public void Dijkstra(ref int n, ref int source, ref List<MyTuple<int, int>>[] G, ref List<int> shortest_path_to)
        {
            // Set the shortest path for the node to itself (which is 0).
            shortest_path_to[source] = 0;
            LinkedList<MyTuple<int, int>> Q = new LinkedList<MyTuple<int, int>>();

            //Q.AddLast(new LinkedListNode<MyTuple<int, int>>(MyTuple<int,int>.Create(0, source)));
            Q.AddLast(MyTuple<int, int>.Create(0, source));
            //Q.AddLast(Tuple.Create(0, source));

            while (Q.Any())
            {
                int u = Q.First.Value.Item2;
                Q.RemoveFirst();

                foreach (var next in G[u])
                {
                    int v = next.Item1;
                    int new_weight = shortest_path_to[u] + next.Item2;

                    if (new_weight < shortest_path_to[v])
                    {
                        int temp_shortest_path = shortest_path_to[v];

                        MyTuple<int, int> Qtemp = null;
                        Qtemp = Q.Find(next)?.Value; // too slow.
                        //LinkedListNode<MyTuple<int, int>> lQtemp = Q.Find(Qtemp);

                        if (Qtemp != null) // && Qtemp != Q.Last())
                        {
                            //Q.Remove(Qtemp);
                            Q.Remove(Q.Find(Qtemp));
                        }

                        shortest_path_to[v] = new_weight;

                        Q.AddLast(MyTuple<int, int>.Create(shortest_path_to[v], v));
                    }
                }
            }
        }
    }

    public class DijkstraShortestReach_1
    {
    }
}
