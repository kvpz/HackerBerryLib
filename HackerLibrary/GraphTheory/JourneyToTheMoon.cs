using System;
using System.Collections.Generic;
using System.Text;

namespace HackerLibrary.GraphTheory
{
    public class JourneyToTheMoon
    {
        public LinkedList<int>[] ad;
        public int[] visited;
        public int vertices;

        public void DFS(int u)
        {
            visited[u] = 1;
            ++vertices;

            LinkedList<int>.Enumerator it = ad[u].GetEnumerator();
            while(it.MoveNext())
            {
                if(visited[it.Current] == 0)
                {
                    visited[it.Current] = 1;
                    DFS(it.Current);
                }
            }
        }


    }
}
