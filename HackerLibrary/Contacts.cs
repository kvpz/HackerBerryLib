using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace HackerLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class Contacts
    {
        const string SampleInputFile = "..\\..\\Input\\test3.txt";
        private const string SampleOutputFile = "..\\..\\Output\\Output3.txt";

        /// <summary>
        /// Add a string to the dictionary along with the amount of occurences (or, really, the total attempts of adding).
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="input"></param>
        public void Add(Dictionary<string, int> dictionary, string input)
        {
            for(int j = 1; j < input.Length; ++j)
            {
                string substring = input.Substring(0, j);

                if (!dictionary.ContainsKey(substring))
                    dictionary.Add(substring, 1);
                else
                    dictionary[substring] += 1; // increment occurence counter
            }
        }

        /// <summary>
        /// Find a word in the dictionary. Return a KeyValuePair.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="searchWord"></param>
        /// <returns></returns>
        public KeyValuePair<string, int>? Find(Dictionary<string, int> dictionary, string searchWord)
        {
            if(dictionary.ContainsKey(searchWord))
            {
                return new KeyValuePair<string, int>(searchWord, dictionary[searchWord]);
            }

            return null;
        }

        public void Process(string input = SampleInputFile)
        {
            StreamReader stream = new StreamReader(File.OpenRead(input));

            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // The first line of the file denotes the total amount of lines that follow
            int totalLines = Int32.Parse(stream.ReadLine());
            while(!stream.EndOfStream)
            {
                string[] line = stream.ReadLine().Split(' ');
                string action = line[0];
                string word = line[1];
                if(line[0] == "add") // add the item to the dictionary
                {
                    Add(dictionary, word);
                }
                else if(line[0] == "find") // find the item in the dictionary
                {
                    KeyValuePair<string, int>? dictionaryItem = Find(dictionary, word);
                }
            }

            stopwatch.Stop();

        }
    }
}
