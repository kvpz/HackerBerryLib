using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    /// <summary>
    /// Adjacency list representation for undirected graphs.
    /// </summary>
    public class UndirectedGraph
    {
        public List<LinkedList<int>> adjList { get; set; }
        public int VertexSize { get; set; }


        /// <summary>
        /// Default constructor; underlying values set to null/ default values.
        /// </summary>
        public UndirectedGraph()
        {
            adjList = new List<LinkedList<int>>();
        }

        /// <summary>
        /// Initialize underlying container knowing the total amount of vertices expected.
        /// </summary>
        /// <param name="size"> Total amount of vertices. </param>
        public UndirectedGraph(int size)
        {
            adjList = new List<LinkedList<int>>(size);
            for (int i = 0; i < size; ++i)
                adjList.Add(new LinkedList<int>());
        }

        /* accessors */
        public bool HasEdge(int from, int to)
        {
            return adjList[from].Contains(to);
        }

        /* mutators */
        public void PushVertex()
        {
            adjList.Add(new LinkedList<int>());
        }

        public void AddEdge(int from, int to)
        {
            adjList[from].AddLast(to);
            adjList[to].AddLast(from);
        }

        public int OutDegree(int vertex)
        {
            return adjList[vertex].Count;
        }

        public int InDegree(int vertex)
        {
            return OutDegree(vertex);
        }


    }
}
