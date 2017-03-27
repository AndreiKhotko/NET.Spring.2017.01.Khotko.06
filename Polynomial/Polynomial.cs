using System;
using System.Linq;
using System.Text;

namespace Polynomial
{
    /// <summary>
    /// Class that implements polynom and operations with it 
    /// </summary>
    public class Polynomial
    {
        /// <summary>
        /// Contains polynom coefficients 
        /// </summary>
        /// <remarks> 
        /// Coefficients are stored in int array as follows: the index of the array
        /// is the same as the degree of the member at which coefficient stays
        /// </remarks>
        public double[] Coefficients { get; }

        /// <summary>
        /// The symbol that determines a text display of polynom variable
        /// </summary>
        public char VariableSybmol { get; }

        /// <summary>
        /// The Degree of polynom
        /// </summary>
        public int Degree => Coefficients.Length;

        private enum Operation
        {
            Addition,
            Subtraction,
            Multiplication
        };

        /// <summary>
        /// Constructor that gets params
        /// </summary>
        /// <param name="coefficients">Coefficients of polynom</param>
        /// <param name="variableSymbol">The symbol that determines a text display of polynom variable</param>
        public Polynomial(params double[] coefficients)
        {
            if (coefficients.Any(value =>
                double.IsNaN(value) ||
                double.IsInfinity(value)))
                throw new ArgumentException("One of the element is NaN or Infinity");
            Coefficients = coefficients;
            VariableSybmol = 'x';
        }

        /// <summary>
        /// Constructor that gets params and variable symbol 
        /// </summary>
        /// <param name="coefficients">Coefficients of polynom</param>
        /// <param name="variableSymbol">The symbol that determines a text display of polynom variable</param>
        public Polynomial(char variableSymbol, params double[] coefficients)
        {
            if (coefficients.Any(value => 
                double.IsNaN(value) || 
                double.IsInfinity(value)))
                throw new ArgumentException("One of the element is NaN or Infinity");
            Coefficients = coefficients;

            if (variableSymbol < 'a' || variableSymbol > 'z')
                throw new ArgumentException("variableSymbol is not correct");

            VariableSybmol = variableSymbol;
        }

        /// <summary>
        /// Overloaded method ToString for polynom
        /// </summary>
        /// <returns>String representation of polynom</returns>
        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            bool isFirst = true;

            for (int i = Coefficients.Length - 1; i >= 0; i--)
            {
                // We don't need a member that has coefficient = 0
                if (Math.Abs(Coefficients[i]) < double.Epsilon)
                    continue;

                // Add plus symbol if coefficient is positive and if tha coefficient is not first in our polynom 
                if (Coefficients[i] > 0 && !isFirst)
                    stringBuilder.Append('+');

                // Add coefficient
                if (Math.Abs(Coefficients[i] - 1) > double.Epsilon && i != 0)
                    stringBuilder.Append(Coefficients[i]);
                else if (i == 0)
                    stringBuilder.Append(Coefficients[i]);

                isFirst = false;

                // We don't need a variable symbol if it's a zero-degree member
                if (i != 0)
                    stringBuilder.Append(VariableSybmol);

                // We don't need a degree if it's a zero- or one-degree member
                if (i == 1 || i == 0)
                    continue;
                
                stringBuilder.Append('^');
                stringBuilder.Append(i);
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Overloaded method GetHashCoed
        /// </summary>
        /// <returns>Hash code of instance</returns>
        public override int GetHashCode()
        {
            int result = VariableSybmol.GetHashCode();
            int hashCoef = 33;

            for (int i = 0; i < Coefficients.Length; i++)
                result +=  (int)(Coefficients[i] * Math.Pow(hashCoef, Degree - i));
            
            return result;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Polynomial p = obj as Polynomial;
            if ((object) p == null)
                return false;

            double[] minArr = p.Coefficients.Length > this.Coefficients.Length
                ? this.Coefficients
                : p.Coefficients;
            double[] maxArr = p.Coefficients.Length > this.Coefficients.Length
                ? p.Coefficients
                : this.Coefficients;
            for (int i = 0; i < minArr.Length; i++)
            {
                if (Math.Abs(this.Coefficients[i] - p.Coefficients[i]) > 0.00000001)
                    return false;
            }

            for (int i = minArr.Length; i < maxArr.Length; i++)
            {
                if (Math.Abs(maxArr[i]) > double.Epsilon)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Method that summarize two polynoms
        /// </summary>
        /// <param name="a">First polynom</param>
        /// <param name="b">Second polynom</param>
        /// <returns>New Polynom of sum of two polynoms</returns>
        public static Polynomial Addition(Polynomial a, Polynomial b)
        {
            double[] coefficients = OperationWithDoubleArrays(a.Coefficients, b.Coefficients, Operation.Addition);

            return new Polynomial(coefficients);
        }

        /// <summary>
        /// Method that calculate substraction of two polynoms
        /// </summary>
        /// <param name="minuend">Minuend</param>
        /// <param name="subtrahend">Subtrahend</param>
        /// <returns>New Polynom of difference of two polynoms</returns>
        public static Polynomial Subtraction(Polynomial minuend, Polynomial subtrahend)
        {
            double[] coefficients = OperationWithDoubleArrays(minuend.Coefficients, subtrahend.Coefficients,
                Operation.Subtraction);

            return new Polynomial(coefficients);
        }

        /// <summary>
        /// Method that multiply two polynoms
        /// </summary>
        /// <param name="a">First polynom</param>
        /// <param name="b">Second polynom</param>
        /// <returns>New Polynom of multiplication of two polynoms</returns>
        public static Polynomial Multiplication(Polynomial a, Polynomial b)
        {
            double[] coefficients = OperationWithDoubleArrays(a.Coefficients, b.Coefficients, Operation.Multiplication);

            return  new Polynomial(coefficients);
        }

        /// <summary>
        /// Method thad add polynom to this instance 
        /// </summary>
        /// <param name="polynom">Added polynom</param>
        /// <returns>New Polynom of sum of two polynoms</returns>
        public Polynomial Add(Polynomial polynom)
        {
            return Addition(this, polynom);
        }

        /// <summary>
        /// Method thad subtract polynom from this instance 
        /// </summary>
        /// <param name="polynom">Subtrahended polynom</param>
        /// <returns>New Polynom of difference of two polynoms</returns>
        public Polynomial Subtract(Polynomial polynom)
        {
            return Subtraction(this, polynom);
        }

        /// <summary>
        /// Method that multiply polynom with this instance
        /// </summary>
        /// <param name="polynom">multiplied polynom</param>
        /// <returns>New Polynom of multiplication of two polynoms</returns>
        public Polynomial Multiply(Polynomial polynom)
        {
            return Multiplication(this, polynom);
        }


        public static Polynomial operator +(Polynomial a, Polynomial b)
        {
            return Polynomial.Addition(a, b);
        }

        public static Polynomial operator -(Polynomial a, Polynomial b)
        {
            return Polynomial.Subtraction(a, b);
        }

        public static Polynomial operator *(Polynomial a, Polynomial b)
        {
            return Polynomial.Multiplication(a, b);
        }

        /// <summary>
        /// Construct a new double array by doing the operation with elements of two double arrays
        /// </summary>
        /// <param name="a">First double array</param>
        /// <param name="b">Second double array</param>
        /// <param name="operation">Operation</param>
        /// <returns>New double array</returns>
        private static double[] OperationWithDoubleArrays(double[] a, double[] b, Operation operation)
        {
            double[] maxArr = a.Length > b.Length ? a : b;
            double[] minArr = a.Length <= b.Length ? a : b;
            double[] result = new double[maxArr.Length];

            switch (operation)
            {
                case Operation.Addition:
                    for (int i = 0; i < minArr.Length; i++)
                        result[i] = a[i] + b[i];

                    for (int i = minArr.Length; i < maxArr.Length; i++)
                        result[i] = maxArr[i];
                    break;
                
                case Operation.Multiplication:
                    for (int i = 0; i < minArr.Length; i++)
                        result[i] = a[i] * b[i];

                    for (int i = minArr.Length; i < maxArr.Length; i++)
                        result[i] = maxArr[i];
                    break;

                case Operation.Subtraction:
                    for (int i = 0; i < minArr.Length; i++)
                        result[i] = a[i] - b[i];

                    for (int i = minArr.Length; i < maxArr.Length; i++)
                        result[i] = maxArr == a ? maxArr[i] : -maxArr[i]; 
                    break;;
            }

            return result;
        }

    }
}
