using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HackerRank
{
    using System.Diagnostics;
    using Vertex = System.Int32;
    public abstract class Graph
    {
        public abstract void SetVertexSize(int n);
        public abstract void AddEdge(Vertex from, Vertex to);
        public virtual bool HasEdge() { return false; }
        public virtual int VertexSize() { return 0; }
        public virtual int EdgeSize() { return 0; }
        public abstract int OutDegree(Vertex v);
        public abstract int InDegree(Vertex v);
    }

    /// <summary>
    /// Adjacency matrix graph representation.
    /// </summary>
    public class GraphMatrixBase : Graph
    {
        // inherited abstract methods
        public override void SetVertexSize(int n)
        {

        }

        public override void AddEdge(Vertex from, Vertex to)
        {
            
        }

        public override int OutDegree(Vertex v)
        {
            return 0;
        }

        public override int InDegree(Vertex v)
        {
            return 0;
        }

        //IEnumerator<> Begin(Vertex x);
        //IEnumerator<> End(Vertex x);

    }

    /// <summary>
    /// Adjacency list graph representation.
    /// </summary>
    public class GraphListBase : Graph
    {
        public List<LinkedList<int>> al_;

        public GraphListBase()
        {
            al_ = new List<LinkedList<int>>();
        }

        public GraphListBase(int size)
        {
            al_ = new List<LinkedList<int>>(size); //new LinkedList<int>[size]);
            for(int i = 0; i < size; ++i)
            {
                al_.Add(new LinkedList<int>());
            }
        }
        // inherited abstract methods
        public override void SetVertexSize(int n)
        {
            al_ = new List<LinkedList<int>>(n);
        }

        /// <summary>
        /// Adds an edge to the graph.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public override void AddEdge(Vertex from, Vertex to)
        {
            al_[from].AddLast(to);
            al_[to].AddLast(from);
        }

        /// <summary>
        /// Adds an empty vertex to the graph. Might be useful..
        /// </summary>
        public void PushVertex()
        {
            al_.Add(new LinkedList<Vertex>());
        }

        public bool HasEdge(Vertex from, Vertex to)
        {
            if(al_[from].Find(to) != null)
            {
                return true;
            }
            return false;
        }

        public override int VertexSize()
        {
            return al_.Count();
        }

        /// <summary>
        /// Amount of edges leaving vertex.
        /// </summary>
        /// <param name="v"></param>
        /// <returns>Vertex</returns>
        public override int OutDegree(Vertex v)
        {
            return al_[v].Count();
        }

        /// <summary>
        /// mount of edges going into vertex
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public override int InDegree(Vertex v)
        {
            return OutDegree(v);
        }


    }

    public class Solution
    {
        

        // The amount of lines read by the program ( <= 10^4 )
        public static int P { get; set; }

        static void Main(string[] args)
        {            
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Matrix<DataType> mat = new Matrix<DataType>(10, 10, 4); //2.323);
            Matrix<int> matint = new Matrix<int>(10, 10, 24);
            //List<DataType>.Enumerator l = mat.Begin(1);

            IEnumerator<DataType> l = mat.Begin(1).GetEnumerator();
            while (l.MoveNext())
            {
                Console.WriteLine(l.Current);
            }

            DataType valueat = mat.ValueAt(34, 23);
            Console.WriteLine(valueat ?? 32422);
            Console.WriteLine("NEXT\n\n");

            // testing multiplication between DataTypes
            DataType m1 = 4;
            DataType m2 = 5;
            Console.WriteLine(m1 * m2);

            // Testing if explicit copy constructor works ( it does )
            Matrix<int> originalMatrix = new Matrix<int>(5, 5, 89);
            Matrix<int> copyMatrix = new Matrix<int>(ref originalMatrix);
            foreach(int v in copyMatrix.Begin(1))
            {
                Console.WriteLine(v);
            }

            
            // testing matrix vector multiplication (integers)
            Matrix<int> MatrixA = new Matrix<int>(3, 3, 2);
            List<int> VectorX = new List<int>() { 1, 2, 3 };
            var VectorAX_result = MatrixA * VectorX;
            foreach(var vertice in VectorAX_result)
            {
                Console.WriteLine(vertice);
            }
            

            // testing matrix vector multiplication (reals)
            Matrix<double> MatrixB_Real = new Matrix<double>(3, 3, 2.1);
            List<double> VectorX_Real = new List<double>() { 1, 2, 3 };
            var VectorAX_result_Real = MatrixB_Real * VectorX_Real;
            foreach (var vertice in VectorAX_result_Real)
            {
                Console.WriteLine(vertice);
            }


            Console.WriteLine("~~~ Graph Material ~~~\n");

            GraphListBase lgraph = new GraphListBase(10);
            lgraph.AddEdge(1, 2);
            Console.WriteLine($"1 -> 2 exist? {lgraph.HasEdge(1, 2)}"); // should return true;

            UndirectedGraph ugraph = new UndirectedGraph(5);
            ugraph.AddEdge(1, 2);
            


            stopwatch.Stop();
            Console.WriteLine($"Time: {stopwatch.Elapsed}");

            
        }
    }
}
