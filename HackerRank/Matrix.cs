using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackerRank;

namespace HackerRank
{
    public class systemTypes
    {
        public static System.Int32 returnType() { return new System.Int32(); }
    }

    public class Matrix<T> where T : new()
    {
        // properties and member data
        private List< List<T> > row_;   
        public List<T> this[int rowIndex]
        {
            get { return row_[rowIndex]; }
            private set { row_[rowIndex] = value; }
        }

        /// <summary>
        /// Matrix default constructor. Initializes 
        /// </summary>
        public Matrix()
        {
            row_ = new List<List<T>>();
        }

        public Matrix(int numrows, int numcols)
        {
            row_ = new List<List<T>>(numrows);
            for(int i = 0; i < numrows; ++i)
            {
                row_[i] = new List<T>(new T[numcols]); // compare performance to initializing with just numcols
            }
        }

        public Matrix(int numrows, int numcols, T t)
        {
            row_ = new List<List<T>>(numrows);
            List<T> tempList = new List<T>(Enumerable.Repeat(t, numcols));
            row_.AddRange(Enumerable.Repeat(tempList, numcols));
        }

        /// <summary>
        /// Matrix copy constructor.
        /// </summary>
        /// <param name="m"></param>
        public Matrix(ref Matrix<T> m)
        {
            this.row_ = new List<List<T>>(m.row_);
        }



        /* Iterator methods */

        /// <summary>
        /// Returns a forward list enumerator representing a matrix row
        /// </summary>
        /// <param name="row"></param>
        //public List<T>.Enumerator Begin(int row)
        //public IEnumerator<T> Begin(int row)
        public IEnumerable<T> Begin(int row)
        {
            return (row_[row]); //.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator of a reversed list representing a matrix row
        /// </summary>
        /// <param name="row"></param>
        public List<T>.Enumerator End(int row)
        {
            List<T> reverseRow = new List<T>((row_[row] as IEnumerable<T>).Reverse());
            return reverseRow.GetEnumerator();
        }

        /* Accessor methods */

        /// <summary>
        /// Returns a value type representing the value at the matrix indeces. Provides error handling unlike this[i][j]. 
        /// If the indices are invalid, a null value is returned.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public T ValueAt(int i, int j)
        {
            try
            {
                return row_[i][j];
            }
            catch(Exception)
            {
                Console.WriteLine("Indeces are invalid. Can't touch this.");
            }

            return default(T);
        }

        /// <summary>
        /// Returns the row dimension of the matrix.
        /// </summary>
        /// <returns></returns>
        public int NumberOfRows()
        {
            return row_.Count();
        }

        /// <summary>
        /// Returns the column dimension of the matrix
        /// </summary>
        /// <returns></returns>
        public int NumberOfColumns()
        {
            return row_[0].Count();
        }

        /* Mutators */

        public void Clear()
        {
            for(int i = 0; i < row_.Count(); ++i)
            {
                row_[i].Clear();
            }
            row_.Clear();
        }

        /// <summary>
        /// Dot product calculation.
        /// </summary>
        /// <param name="M"></param>
        /// <param name="X"></param>
        /// <returns></returns>
        public static List<MyType> operator *(Matrix<T> M, List<T> X)
        {
            // The number of columns of M must match number of rows (terms) in X
            if (M.NumberOfColumns() != X.Count())
            {
                return null;
            }

            int rows = M.NumberOfRows();
            int columns = X.Count();
            List<MyType> V_result = new List<MyType>(columns);
            for(int i = 0; i < columns; ++i)
            {
                MyGenericType<T> tempGen = new MyGenericType<T>(default(T));
                V_result.Add(tempGen.ToMyType()); //new MyType(tempGen));
            }

            for (int row_i = 0; row_i < rows; ++row_i)
            {
                for (int column_j = 0; column_j < columns; ++column_j)
                {
                    // T is not a MyType so "as MyType" would return null
                    //V_result[column_j] += (M.ValueAt(row_i, column_j) as MyGenericType<T>) * (X[column_j] as MyGenericType<T>);
                    //MyGenericType<T> mij_generic = new MyGenericType<T>(M.ValueAt(row_i, column_j));
                    //MyType mij = mij_generic.data;
                    
                    MyGenericType<T> forMyType = new MyGenericType<T>(X[column_j]);
                    MyGenericType<T> forMyTypeM = new MyGenericType<T>(M.ValueAt(row_i, column_j));
                    MyType Xi = forMyType.ToMyType();
                    MyType Mij = forMyTypeM.ToMyType();
                    MyType newT = Xi * Mij;

                    V_result[column_j] += newT;
                    //V_result[column_j] += mij * Xi;

                }
            }

            return V_result;
        }

    }


}

/*
 * Notes:
 * Can't overload operator =, ., ?:, ??, ->, =>, etc
 */