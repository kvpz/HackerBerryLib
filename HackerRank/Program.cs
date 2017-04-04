using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HackerRank
{
    using System.Diagnostics;
    class Solution
    {
        static string[] identifier = { "add", "find" }; // add name, find partial

        static System.IO.FileStream GetInput()
        {
            System.IO.FileStream fstream = new System.IO.FileStream("../Output/Output3.txt", FileMode.Open, FileAccess.Read);
            return fstream;
        }

        static string outFileName = "..\\..\\Output\\Output3.txt";
        static string inFileName = "..\\..\\Input\\test3.txt";

        static void Main(string[] args)
        {
            StreamReader sreader = new StreamReader(inFileName);
            
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int totalLines = Int32.Parse(sreader.ReadLine());

            while(!sreader.EndOfStream)
            {
                string[] in_ = sreader.ReadLine().Split(' ');
                if(in_[0][0] == 'a') // add
                {
                    for(int j = 1; j <= in_[1].Length; ++j)
                    {
                        string sub = in_[1].Substring(0, j);

                        if (!dictionary.ContainsKey(sub))
                            dictionary.Add(sub, 1);
                        else
                            dictionary[sub] += 1;
                    }
                }
                else // find
                {
                    if (!dictionary.ContainsKey(in_[1]))
                        Console.WriteLine('0');
                    else
                        Console.WriteLine(dictionary[in_[1]]);

                }
            }

            stopwatch.Stop();
            Console.WriteLine($"Time: {stopwatch.Elapsed}");
        }
    }
}
