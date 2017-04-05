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

    public class Matrix<T>  //TypeOperators<T> // as struct (requires non-nullable type)
    {
        // properties and member data
        private List<List<T>> row_;   
        public List<T> this[int rowIndex]
        {
            get { return row_[rowIndex]; }
            private set { row_[rowIndex] = value; }
        }

        public Matrix() { }
        public Matrix(int numrows, int numcols) { }
        public Matrix(int numrows, int numcols, T t) { }
        public Matrix(Matrix<T> m){}

        // iterator methods
        public List<T>.Enumerator Begin(int row)
        {
            return (row_[row]).GetEnumerator();
        }

        public List<T>.Enumerator End(int row)
        {
            return (List<T>.Enumerator)(row_[row] as IEnumerable<T>).Reverse().GetEnumerator();
        }

        public T ValueAt(int i, int j)
        {
            return row_[i][j];
        }

        public int NumberOfRows()
        {
            return row_.Count();
        }

        public int NumberOfColumns()
        {
            return row_[0].Count();
        }

        public void Clear()
        {
            for(int i = 0; i < row_.Count(); ++i)
            {
                row_[i].Clear();
            }
            row_.Clear();
        }


        // Dot product for integer data type
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
            //List<T> V_result = new List<T>(columns);
            for (int row_i = 0; row_i < rows; ++row_i)
            {
                for (int column_j = 0; column_j < columns; ++column_j)
                {
                    V_result[column_j] += (M.ValueAt(row_i, column_j) as MyType) * (X[column_j] as MyGenericType<T>); //[row_i][column_j] * X[column_j];
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