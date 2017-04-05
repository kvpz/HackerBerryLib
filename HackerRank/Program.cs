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

            Console.WriteLine("Testing MatrixUtility.MyType:\n");
            MyType myTypeTest = null;
            Console.WriteLine(myTypeTest.data_float ?? 23425);

            stopwatch.Stop();
            Console.WriteLine($"Time: {stopwatch.Elapsed}");
        }
    }
}
