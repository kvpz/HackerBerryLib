using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    public class BFSearch
    {
        //public UndirectedGraph g_;

        public List<HashSet<int>> g_;
        public int start; // vertex from which search starts
        public List<bool> visited;
        public List<int> distance; // distance from search origin
        public readonly int edgeWeight = 6;
        public int totalVertices;

        public BFSearch(int n, int edgeWeight)
        {
            this.totalVertices = n;
            this.visited = new List<bool>(new bool[n]);
            this.distance = new List<int>(new int[n]);
            for (int i = 0; i < n; ++i)
                this.distance[i] = -1;
            this.g_ = new List<HashSet<int>>();
            for (int i = 0; i < n; ++i)
                this.g_.Add(new HashSet<int>());
        }

        public void ShortestReach(int start)
        {
            this.start = start;
            LinkedList<int> que = new LinkedList<int>();
            que.AddLast(start);
            visited[start] = true;
            distance[start] = 0;
            while(que.Count > 0)
            {
                int u = que.Last.Value;
                que.RemoveLast();
                foreach(int v in g_[u])
                {
                    if(!visited[v])
                    {
                        que.AddLast(v);
                        visited[v] = true;
                        distance[v] = distance[u] + edgeWeight;
                    }
                }
            }

            foreach(int i in distance)
            {
                if (i != 0)
                    Console.WriteLine(i + " ");
            }

            Console.Write("\n");
            this.distance = new List<int>(new int[this.totalVertices]);
            this.visited.ForEach(i => i = false);
        }
    }
}
