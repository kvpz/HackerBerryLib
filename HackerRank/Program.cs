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
        public abstract void SetVertexSize(uint n);
        public abstract void AddEdge(Vertex from, Vertex to);
        public virtual bool HasEdge() { return false; }
        public virtual uint VertexSize() { return 0; }
        public virtual uint EdgeSize() { return 0; }
        public abstract uint OutDegree(Vertex v);
        public abstract uint InDegree(Vertex v);
    }

    public class GraphMatrixBase : Graph
    {
        // inherited abstract methods
        public override void SetVertexSize(uint n)
        {

        }

        public override void AddEdge(Vertex from, Vertex to)
        {
            
        }

        public override uint OutDegree(Vertex v)
        {
            return 0;
        }

        public override uint InDegree(Vertex v)
        {
            return 0;
        }

        //IEnumerator<> Begin(Vertex x);
        //IEnumerator<> End(Vertex x);

    }

    public class GraphListBase : Graph
    {
        // inherited abstract methods
        public override void SetVertexSize(uint n)
        {

        }

        public override void AddEdge(Vertex from, Vertex to)
        {

        }

        public override uint OutDegree(Vertex v)
        {
            return 0;
        }

        public override uint InDegree(Vertex v)
        {
            return 0;
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

            stopwatch.Stop();
            Console.WriteLine($"Time: {stopwatch.Elapsed}");
        }
    }
}
