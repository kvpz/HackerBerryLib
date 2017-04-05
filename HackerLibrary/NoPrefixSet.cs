using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HackerLibrary
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/no-prefix-set
    /// This code can process a file and determine when a full string is a
    /// substring of another string. If such a string is encountered, that string
    /// will be returned.
    /// </summary>
    public class NoPrefixSet
    {
        public NoPrefixSet()
        {

        }

        public NoPrefixSet(string inputFile, string outputFile)
        {
            InputFile = inputFile;
            OutputFile = outputFile;
        }

        private Dictionary<string, int> _dictionary;

        public string InputFile { get; set; }
        public string OutputFile { get; set; }

        public void Process()
        {
            StreamReader fstream = new StreamReader(File.OpenRead(InputFile));
            int totalLines = Int32.Parse(fstream.ReadLine());

            // Processing file
            string badString = null;
            int i = 0;
            for(; i < totalLines; ++i) 
            {
                string inputString = fstream.ReadLine();
                int inputStringLength = inputString.Length;
                for(int j = 1; j < inputStringLength; ++j)
                {
                    string substring = inputString.Substring(0, j);
                    if(!_dictionary.ContainsKey(substring))
                    {
                        _dictionary.Add(substring, 0);
                        // if substring is the input string, mark it as so in the dictionary
                        if (substring.Length == inputStringLength)
                            _dictionary[substring] = 1;
                    }
                    else
                    {
                        if (_dictionary[substring] == 0 && substring.Length == inputStringLength)
                            _dictionary[substring] = 1;
                        if(_dictionary[substring] == 1)
                        {
                            badString = inputString;
                            i = totalLines;
                            break;
                        }
                    }
                }
            }

            if(i == totalLines + 1 && badString != null)
            {
                Console.WriteLine("BAD SET");
                Console.WriteLine(badString);
            }
            else
            {
                Console.WriteLine("GOOD SET");
            }
        }
    }
}
