using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace CreateVectors
{
    public class Vector
    {
        private readonly double[] _values;

         public Vector(double[] values)
         {
             _values = values;
         }

        public Vector()
        {
        }
        public double this[int index]
        {
            get => _values[index];
            set => _values[index] = value;
        }
        
       public int Length
        {
            get
            {
               return this._values.Length;

            }
        }
        public double[] Values
        {
            get;
            set;
        }

        public Vector Add(Vector vector2)
        {
            int length = vector2.Length;

            Vector result = new Vector(_values);

            for (int i = 0; i < length; i++)
            {
                result[i] = _values[i] + vector2[i];
            }
            return result; 

        }
    }
}
