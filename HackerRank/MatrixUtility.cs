using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackerRank;

namespace HackerRank
{
    public class TypeOperators<T> where T : MyType
    {
        public T data_;
        public int data_int;

        //public static TypeOperators<int> operator * (TypeOperators<T> a, TypeOperators<T> b)
        public static MyType operator *(TypeOperators<T> a, TypeOperators<T> b)
        {
            return a.data_ * b.data_;
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
        private readonly double? data_double;
        private readonly char? data_char;
        public readonly float? data_float;

        public MyType() { }
        /*
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
        *
        public MyType(MyGenericType<int> g)
        {
            data_int = g.data;
        }
        // implicit conversions to MyType because C# doesn't provide assignment constructors
        /*
        public static implicit operator MyType(char charVar)
        {
            return new MyType(charVar);
        }
        */
        public static implicit operator MyType(int intVar)
        {
            MyType temp = new MyType();
            temp.data_int = intVar;
            return temp;
            //return new MyType(intVar);
        }
        /*
        public static implicit operator MyType(float floatVar)
        {
            return new MyType(floatVar);
        }

        public static implicit operator MyType(double doubleVar)
        {
            return new MyType(doubleVar);
        }

        public static implicit operator MyType(MyGenericType<int> g)
        {
            return new MyType(g.data);
        }
        */
        public static implicit operator int?(MyType t)
        {
            if(t == null)
            {
                t = new MyType();
                return null;
            }
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

        /*
            Error handling?
        */ 
         
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

    /*
      This class could be used to handle other things that may be program
      dependent, or not type dependent. Maybe error handling?
     */
    public class MyGenericType<T> where T : new()//: MyGenericTypeConversions
    {
        public T data;
        public dynamic intData;

        public MyGenericType(T t)
        {
            data = t;
            if(typeof(T) == typeof(int))
            {
                intData = t;
            }
        }

        public static implicit operator MyType(MyGenericType<T> t)
        {
            Type typeOfT = typeof(T);
            if(typeOfT == typeof(int))
            {
                return 0;
                //return new MyType((int)0);
                //return t.data as MyType;
            }
            return new MyType();
        }

        public static implicit operator T(MyGenericType<T> t) 
        {
            return t.data;
        }
        
        public static implicit operator int(MyGenericType<T> t)
        {
            return 0;
        }
        
        public MyType ToMyType()
        {
            return intData;
        }

    }



}
