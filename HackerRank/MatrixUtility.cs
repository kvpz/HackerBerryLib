using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackerRank;

namespace HackerRank
{
    public class DataType 
    {
        public enum CurrentType
        {
            Integer = 0,
            Float = 1,
            Double = 2
        }

        private double? data_double;
        private int? data_int;
        private char? data_char;
        public float? data_float;

        public DataType() { }
        
        public DataType(int intVar)
        {
            data_int = intVar;
        }

        public DataType(float floatVar)
        {
            data_float = floatVar;
        }
        
        public DataType(double doubleVar)
        {
            data_double = doubleVar;
        }
        
        public DataType(char charVar)
        {
            data_char = charVar;
        }

        // implicit conversions 
        
        public static implicit operator DataType(char charVar)
        {
            return new DataType(charVar);
        }
        
        public static implicit operator DataType(int intVar)
        {
            return new DataType(intVar);
        }
        
        
        public static implicit operator DataType(float floatVar)
        {
            return new DataType(floatVar);
        }
        
        public static implicit operator DataType(double doubleVar)
        {
            return new DataType(doubleVar);
        }

        public static implicit operator double? (DataType t)
        {
            return t.data_double;
        }

        public static implicit operator int? (DataType t)
        {
            return t.data_int;
        }
        
        
        public static implicit operator float?(DataType t)
        {
            return t.data_float;
        }
        
        public static implicit operator char?(DataType t)
        {
            return t.data_char;
        }
        

        public override string ToString()
        {
            if (data_double != null)
                return data_double.ToString();
            if (data_char != null)
                return data_char.ToString();
            if (data_int != null)
                return data_int.ToString();
            if (data_float != null)
                return data_float.ToString();
            return null;
        }

        public static DataType operator*(DataType a, DataType b)
        {
            if (a.data_int != null && b.data_int != null)
                return a.data_int * b.data_int;
            if (a.data_double != null && b.data_double != null)
                return a.data_double * b.data_double;
            if (a.data_float != null && b.data_float != null)
                return a.data_float * b.data_float;
            return 0;
        }

        public static DataType operator /(DataType a, DataType b)
        {
            if (a.data_int != null && b.data_int != null && b.data_int > 0)
                return a.data_int / b.data_int;
            if (a.data_double != null && b.data_double != null && b.data_double > 0)
                return a.data_double / b.data_double;
            if (a.data_float != null && b.data_float != null && b.data_float > 0)
                return a.data_float / b.data_float;
            return 0;
        }

        public static DataType operator+(DataType a, DataType b)
        {
            if (a.data_int != null && b.data_int != null)
                return a.data_int + b.data_int;
            if (a.data_double != null && b.data_double != null)
                return a.data_double + b.data_double;
            if (a.data_float != null && b.data_float != null)
                return a.data_float + b.data_float;
            return 0;
        }

        public static DataType operator -(DataType a, DataType b)
        {
            if (a.data_int != null && b.data_int != null)
                return a.data_int - b.data_int;
            if (a.data_double != null && b.data_double != null)
                return a.data_double - b.data_double;
            if (a.data_float != null && b.data_float != null)
                return a.data_float - b.data_float;
            return 0;
        }

        /*
            Error handling?
        */

    }

    /// <summary>
    ///     This class could be used to handle other things that may be program
    ///    dependent, or not type dependent.Maybe error handling?
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MyGenericType<T> where T : new()//: MyGenericTypeConversions
    {
        //public T data;
        public dynamic _data;

        public MyGenericType(T t)
        {
            _data = t;
        }

        public static implicit operator DataType(MyGenericType<T> t)
        {
            return new DataType(t._data);
        }

        public static implicit operator T(MyGenericType<T> t) 
        {
            return t._data; 
        }

        public DataType ToDataType()
        {
            return _data;
        }

    }

}
