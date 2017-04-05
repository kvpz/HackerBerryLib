using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackerRank;

namespace HackerRank
{
    /*
    public class MatrixUtility
    {
        // Dot product for integer data type
        public static List<int> operator *(Matrix<int> M, List<int> X)
        {
            // The number of columns of M must match number of rows (terms) in X
            if (M.NumberOfColumns() != X.Count())
            {
                return null;
            }

            int rows = M.NumberOfRows();
            int columns = X.Count();
            List<int> V_result = new List<int>(columns);

            for (int row_i = 0; row_i < rows; ++row_i)
            {
                for (int column_j = 0; column_j < columns; ++column_j)
                {
                    V_result[column_j] += M.ValueAt(row_i, column_j) * X[column_j]; //[row_i][column_j] * X[column_j];
                }
            }

            return V_result;
        }
    }
    */

    public class TypeOperators<T> where T : MyType
    {
        public T data_;
        public int data_int;

        //public static TypeOperators<int> operator * (TypeOperators<T> a, TypeOperators<T> b)
        public static MyType operator *(TypeOperators<T> a, TypeOperators<T> b)
        {
            return a.data_ * b.data_;
            /*
            if (typeof(T) == typeof(int))
            {
                //TypeOperators<int> newA = a as TypeOperators<int>;
                //a.data_int = a.data_;
                a.data_int = newA.data_int;
                //return MultiplyThis((int)a.data, (int)b.data);
                //return MultiplyThis(newA.data_, newA.data_);
                return a.data_ * b.data_;
            }
            */
        }

        //public static T MultiplyThis(int a, int b)
        public static int MultiplyThis(int a, int b)
        {
            return a * b;
        }
    }

    public class IntOperator 
    {
        //public virtual int Multiply (int a, int b)
        public static int Multiply (int a, int b)
        {
            return a * b;
        }

    }

    public class TypeConverter
    {
        public static implicit operator int(TypeConverter t)
        {
            return 1;
        }
    }

    public class MyType
    {
        private int? data_int;
        private double? data_double;
        private char? data_char;
        public float? data_float;

        public MyType() { }

        public MyType(int intVar)
        {
            data_int = intVar;
        }

        public MyType(float floatVar)
        {
            data_float = floatVar;
        }

        public MyType(double doubleVar)
        {
            data_double = doubleVar;
        }

        public MyType(char charVar)
        {
            data_char = charVar;
        }

        // implicit conversions to MyType because C# doesn't provide assignment constructors

        public static implicit operator MyType(char charVar)
        {
            return new MyType(charVar);
        }

        public static implicit operator MyType(int intVar)
        {
            return new MyType(intVar);
        }

        public static implicit operator MyType(float floatVar)
        {
            return new MyType(floatVar);
        }

        public static implicit operator MyType(double doubleVar)
        {
            return new MyType(doubleVar);
        }

        public static implicit operator int?(MyType t)
        {
            return t.data_int;
        }

        public static implicit operator float?(MyType t)
        {
            return t.data_float;
        }

        public static implicit operator double?(MyType t)
        {
            return t.data_double;
        }

        public static implicit operator char?(MyType t)
        {
            return t.data_char;
        }
    }

    public class MyGenericTypeConversions
    {
        public static int data_int;
        public static double data_double;
        public static char data_char;

        // assignment constructors
        public static implicit operator double(MyGenericTypeConversions t)
        {
            return data_int;
        }

        public static implicit operator int(MyGenericTypeConversions t)
        {
            return data_int;
        }

        public static implicit operator char(MyGenericTypeConversions t)
        {
            return data_char;
        }

        public static implicit operator MyGenericTypeConversions(int intVar)
        {
            return data_int;
        }

        public static implicit operator MyGenericTypeConversions(double doubleVar)
        {
            return data_double;
        }

        public static implicit operator MyGenericTypeConversions(char t)
        {
            return data_char;
        }
    }

    public class MyGenericType<T> : MyGenericTypeConversions
    {
        public T data;
        public static implicit operator MyType(MyGenericType<T> t)
        {
            Type typeOfT = typeof(T);
            if(typeOfT == typeof(int))
            {
                return t.data as MyType;
            }
            return new MyType();
        }

        
    }

}
