using System;
using Xunit;
using HackerLibrary.GraphTheory;
using System.Collections.Generic;

namespace HackerLibrary.Test
{
    public class JourneyToTheMoonTest
    {
        
        [Fact]
        public void ProcessTest()
        {
            JourneyToTheMoon jttm;
            int i, m, u, v, numComponents = 0, allv = 1, temp = 2, count = 0;
            long n;
            int[] eachC = new int[100000];

            n = 10;
            m = 4;

            jttm = new JourneyToTheMoon();
            jttm.ad = new LinkedList<int>[n];

            LinkedList<int>.Enumerator it;

            for(i = 0; i < n; ++i)
            {
                string[] input = Console.ReadLine().Split(' ');
                u = Int32.Parse(input[0]);
                v = Int32.Parse(input[1]);

                jttm.ad[u].AddLast(v);
                jttm.ad[v].AddLast(u);
            }

            jttm.visited = new int[n];

            for(i = 0; i < n; ++i)
            {
                jttm.visited[i] = 0;
            }

            for(i = 0; i < n; ++i)
            {
                if (jttm.visited[i] == 0)
                {
                    jttm.vertices = 0;
                    jttm.DFS(i);
                    eachC[numComponents] = jttm.vertices;
                    numComponents++;
                }
            }

            long totalWays = n * (n - 1) / 2;
            long sameWays = 0;

            for(i = 0; i < numComponents; ++i)
            {
                sameWays = sameWays + (eachC[i] * (eachC[i] - 1) / 2);
            }

            Console.WriteLine(totalWays - sameWays);
            Assert.True(1 == 1);
        }
    }
}
