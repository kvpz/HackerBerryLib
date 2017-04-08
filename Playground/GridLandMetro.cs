using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridLandMetro
{

    /*
    public class Matrix
    {
        public int rows { get; set; }
        public int columns { get; set; }
        public List<List<int>> matrix;
        public List<int> StartPoint { get; set; }
        public List<int> EndPoint { get; set; }
        public int NumberOfTrainTracks { get; set; }
        
        public Matrix(int rows, int columns, int tracks)
        {
            this.rows = rows;
            this.columns = columns;
            this.NumberOfTrainTracks = tracks;

            matrix = new List<List<int>>(rows);
            // initializing the matrix with 0s
            for(int i = 0; i <= rows; ++i)
            {
                matrix.Add(new List<int>(new int[columns + 1]));
            }

            StartPoint = new List<int>(new int[rows+1]);
            EndPoint = new List<int>(new int[rows+1]);
        }

        public int NumberOfPlacesToPlaceLampposts()
        {
            int total = 0;
            for(int i = 0; i < rows; ++i)
            {
                total += (1 - StartPoint[i]) + (columns - EndPoint[i]); 
            }
            return total;
        }

    }
    */
    public class AboutTrack
    {
        public ulong _start, _end;
        public List<bool> TrackBlocks { get; set; }
    }

    /*
    public class AboutTrackComparer : IComparer<ulong>
    {
        public int Compare(ulong x, ulong y)
        {
            return x < y;
        }
    }
    */
    public class Matrix
    {
        public AboutTrack _aboutTrack { get; set; }
        public SortedDictionary<ulong, AboutTrack> _matrix;
        //public SortedList<ulong, AboutTrack> _matrix;
        //public SortedSet<AboutTrack> _matrix;
        public ulong Rows { get; set; }
        public ulong Columns { get; set; }
        public ulong Tracks { get; set; }
        public Matrix()
        { }

        public Matrix(ulong r, ulong c, ulong t)
        {
            _matrix = new SortedDictionary<ulong, AboutTrack>();
            //_matrix = new SortedList<ulong, AboutTrack>();
            //_matrix = new SortedSet<AboutTrack>()
            Rows = r;
            Columns = c;
            Tracks = t;
            _aboutTrack = new AboutTrack();
            _aboutTrack.TrackBlocks = new List<bool>(new bool[c + 1]);
        }

        public void AddTrack(ulong track, ulong start, ulong end)
        {
            if(_matrix.ContainsKey(track))
            {
                for(int i = (int)start; i <= (int)end; ++i)
                {
                    _matrix[track].TrackBlocks[i] = true;
                }
            }
            else
            {
                AboutTrack _track = new AboutTrack() { _start = start, _end = end };
                _track.TrackBlocks = new List<bool>(new bool[Columns + 1]);

                for(int i = (int)start; i <= (int)end; ++i)
                {
                    _track.TrackBlocks[i] = true;
                }
                _matrix.Add(track, _track);
            }
        }

        public ulong TotalEmptyBlocks()
        {
            ulong total = 0;
            foreach(var m in _matrix)
            {
                for(int i = 1; i <= (int)this.Rows; ++i)
                {
                    if (m.Value.TrackBlocks[i] == false)
                        ++total;
                }
            }

            return total;
        }

    }

    public class GridLandMetro
    {
        public static void Run()
        {
            
            string[] firstInputLine = Console.ReadLine().Split(' '); // n(number of rows) m(number of columns) k(number of train tracks)
            ulong n = UInt64.Parse(firstInputLine[0]);
            ulong m = UInt64.Parse(firstInputLine[1]);
            ulong k = UInt64.Parse(firstInputLine[2]);
            Matrix mat = new Matrix(n, m, k);
            SortedDictionary<ulong, AboutTrack> _dictionary = new SortedDictionary<ulong, AboutTrack>();
            for(ulong i = 0; i < k; ++i) // for each train track
            {
                ulong r, c1, c2; // r(start point of a train track, or row) c1(starting column), c2(ending column)
                string[] inputRCC = Console.ReadLine().Split(' ');
                r = UInt64.Parse(inputRCC[0]);
                c1 = UInt64.Parse(inputRCC[1]);
                c2 = UInt64.Parse(inputRCC[2]);

                mat.AddTrack(r, c1, c2);
            }
            
            //Console.WriteLine(mat.NumberOfPlacesToPlaceLampposts());
        }

    }
}
