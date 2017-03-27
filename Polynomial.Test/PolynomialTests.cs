using System;
using NUnit.Framework;

namespace Polynomial.Test
{
    [TestFixture]
    public class PolynomialTests
    {
        [TestCase(new double[] { 2, 4, 0, 12 }, ExpectedResult = "12x^3+4x+2")]
        [TestCase(new double[] { 0, 0, 0, 0 }, ExpectedResult = "")]
        public string ToString_HasCoefficientsEqualsToZero_ReturnsStringWithoutZeroCoefficientMembers(double[] coefficients)
        {
            var polynomial = new Polynomial(coefficients);
            return polynomial.ToString();
        }

        [TestCase(new double[] { 2, 4, 1, 12 }, ExpectedResult = "12x^3+x^2+4x+2")]
        [TestCase(new double[] { 1, 1, 1, 1, 1 }, ExpectedResult = "x^4+x^3+x^2+x+1")]
        public string ToString_HasCoefficientsEqualsToOne_ReturnsStringWithoutZeroCoefficientMembers(double[] coefficients)
        {
            var polynomial = new Polynomial(coefficients);
            return polynomial.ToString();
        }

        [TestCase(new double[] { }, ExpectedResult = "")]
        public string ToString_CoefficiensCountEqualsToZero_ReturnsEmptyString(double[] coefficients)
        {
            var polynomial = new Polynomial(coefficients);
            return polynomial.ToString();
        }

        [TestCase(new double[] {2}, ExpectedResult = "2")]
        public string ToString_CoefficientCountEqualsToOne_ReturnsNumber(double[] coefficients)
        {
            var polynomial = new Polynomial(coefficients);
            return polynomial.ToString();
        }

        [TestCase(new double[] { 2.2, 4.5 }, ExpectedResult = "4,5x+2,2")]
        [TestCase(new double[] { 2, 4.5, 0.33 }, ExpectedResult = "0,33x^2+4,5x+2")]
        public string ToString_CoefficientsAreWithFloatPoint_ReturnsStringWithFloatPoint(double[] coefficients)
        {
            var polynomial = new Polynomial(coefficients);
            return polynomial.ToString();
        }

        [TestCase(new double[] { 2.2, 4.5 }, new double[] {2.2, 4.5})]
        [TestCase(new double[] { 2, 4.5, 0.33 }, new double[] { 2, 4.5, 0.33 })]
        public void GetHashCode_TwoPolynomsAreEqual_HashCodesAreEqual(double[] coefs1, double[] coefs2)
        {
            var polynomial1 = new Polynomial(coefs1);
            var polynomial2 = new Polynomial(coefs2);

            Assert.AreEqual(polynomial1.GetHashCode(), polynomial2.GetHashCode());
        }

        [TestCase(new double[] { 2.2, 4.5 }, new double[] { 2.2, 4.6 })]
        [TestCase(new double[] { 2, 4.5, 0.33 }, new double[] { 2, 4.5 })]
        [TestCase(new double[] { 2, -2, 2 }, new double[] { 2, -1, 2 })]
        public void GetHashCode_TwoPolynomsAreDifferent_HashCodesAreNotEqual(double[] coefs1, double[] coefs2)
        {
            var polynomial1 = new Polynomial(coefs1);
            var polynomial2 = new Polynomial(coefs2);

            Assert.AreNotEqual(polynomial1.GetHashCode(), polynomial2.GetHashCode());
        }

        [TestCase(new double[] { 2.2, 4.5, 8, 8, 8, 7, 7, 7, 6, 6, 6}, new double[] { 2.2, 4.5, 8, 8, 8, 7, 7, 7, 6, 6, 6 })]
        [TestCase(new double[] { 2, 4.5, 0.33, 5, 5, 5, 5, 5, 5, 5, 5, 5}, new double[] { 2, 4.5, 0.33, 5, 5, 5, 5, 5, 5, 5, 5, 5 })]
        public void GetHashCode_ALotOfCoefficients_HashCodesAreEqual(double[] coefs1, double[] coefs2)
        {
            var polynomial1 = new Polynomial(coefs1);
            var polynomial2 = new Polynomial(coefs2);

            Assert.AreEqual(polynomial1.GetHashCode(), polynomial2.GetHashCode());
        }

        [TestCase(new double[] { 2.2, 4.5, 8, 8, 8, 7, 6, 7, 6, 6, 6 }, new double[] { 2.2, 4.5, 8, 8, 8, 7, 7, 7, 6, 6, 6 })]
        [TestCase(new double[] { 2, 4.5, 0.33, 5, 5, 5, 4, 4, 5, 5, 5, 5 }, new double[] { 2, 4.5, 0.33, 5, 5, 5, 5, 5, 5, 5, 5, 5 })]
        public void GetHashCode_ALotOfCoefficientsAndPolynomsAreDifferent_HashCodesAreNotEqual(double[] coefs1, double[] coefs2)
        {
            var polynomial1 = new Polynomial(coefs1);
            var polynomial2 = new Polynomial(coefs2);

            Assert.AreNotEqual(polynomial1.GetHashCode(), polynomial2.GetHashCode());
        }

        [TestCase(new double[] { 2000000000, 4.5, 8, 8, 8, 7, 7, 7, 6, 100000, 6 }, new double[] { 2000000000, 4.5, 8, 8, 8, 7, 7, 7, 6, 100000, 6 })]
        public void GetHashCode_BigNumbersAndPolynomsAreDifferent_HashCodesAreEqual(double[] coefs1, double[] coefs2)
        {
            var polynomial1 = new Polynomial(coefs1);
            var polynomial2 = new Polynomial(coefs2);

            Assert.AreEqual(polynomial1.GetHashCode(), polynomial2.GetHashCode());
        }

        [TestCase(new double[] {2, 6, 3}, new double[] {2, 6, 3}, ExpectedResult = true)]
        public bool Equals_PolynomsAreEqual_ReturnsTrue(double[] a, double[] b)
        {
            var polynomialA = new Polynomial(a);
            var polynomialB = new Polynomial(b);

            return polynomialA.Equals(polynomialB);
        }

        [TestCase(new double[] { 2, 3, 4 }, new double[] { -2, -3, -4 }, ExpectedResult = false)]
        public bool Equal_AllMembersAreDifferent_ReturnsFalse(double[] a, double[] b)
        {
            var polynomialA = new Polynomial(a);
            var polynomialB = new Polynomial(b);

            return polynomialA.Equals(polynomialB);
        }

        [TestCase(new double[] { 2, 3, 4 }, new double[] { 2, 3, 4, 1, 1 }, ExpectedResult = false)]
        public bool Equal_DifferentLengthsAndPartsEqualsAndAdditionalPartIncludesNotZeroValue_ReturnsFalse(double[] a, double[] b)
        {
            var polynomialA = new Polynomial(a);
            var polynomialB = new Polynomial(b);

            return polynomialA.Equals(polynomialB);
        }

        [TestCase(new double[] { 2, 3, 4 }, new double[] { 2, 3, 4, 0, 0 }, ExpectedResult = true)]
        public bool Equal_DifferentLengthsAndPartsEqualsAndAdditionalPartIncludesAllZeroValues_ReturnsTrue(double[] a, double[] b)
        {
            var polynomialA = new Polynomial(a);
            var polynomialB = new Polynomial(b);

            return polynomialA.Equals(polynomialB);
        }

        [TestCase(new double[] {}, new double[] {})]
        public void Addition_PolynomsAreEmpty_ReturnsEmptyPolynom(double[] a, double[] b)
        {
            Polynomial expected = new Polynomial(new double[] { });
            Polynomial actual = Polynomial.Addition(new Polynomial(a), new Polynomial(b));
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new double[] {2, 3.4, 7 }, new double[] {1, 5, 1.1}, new double[] {3, 8.4, 8.1})]
        public void Addition_PolynomsLengthsAreEqual_PositiveTest(double[] a, double[] b, double[] forExpected)
        {
            Polynomial expected = new Polynomial(forExpected);
            Polynomial actual = Polynomial.Addition(new Polynomial(a), new Polynomial(b));
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new double[] { 2, 3.4, 7, 0 }, new double[] { 1, 5, 1.1 }, new double[] { 3, 8.4, 8.1, 0 })]
        [TestCase(new double[] { 2, 3.4, 7, 1 }, new double[] { 1, 5, 1.1 }, new double[] { 3, 8.4, 8.1, 1 })]
        [TestCase(new double[] { 2, 3.4, 7}, new double[] { 1, 5, 1.1, 2, 3 }, new double[] { 3, 8.4, 8.1, 2, 3 })]
        public void Addition_PolynomsLengthsAreDifferent_PositiveTest(double[] a, double[] b, double[] forExpected)
        {
            Polynomial expected = new Polynomial(forExpected);
            Polynomial actual = Polynomial.Addition(new Polynomial(a), new Polynomial(b));
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new double[] { 2, 3.4, 7 }, new double[] { 1, 5, 1.1 }, new double[] { 1, -1.6, 5.9 })]
        public void Subtraction_PolynomsLengthsAreEqual_PositiveTest(double[] a, double[] b, double[] forExpected)
        {
            Polynomial expected = new Polynomial(forExpected);
            Polynomial actual = Polynomial.Subtraction(new Polynomial(a), new Polynomial(b));
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new double[] { 2, 3.4, 7, 0 }, new double[] { 1, 5, 1.1 }, new double[] { 1, -1.6, 5.9, 0 })]
        [TestCase(new double[] { 2, 3.4, 7, 1 }, new double[] { 1, 5, 1.1 }, new double[] { 1, -1.6, 5.9, 1 })]
        [TestCase(new double[] { 2, 3.4, 7 }, new double[] { 1, 5, 1.1, 2, 3 }, new double[] { 1, -1.6, 5.9, -2, -3 })]
        public void Subtraction_PolynomsLengthsAreDifferent_PositiveTest(double[] a, double[] b, double[] forExpected)
        {
            Polynomial expected = new Polynomial(forExpected);
            Polynomial actual = Polynomial.Subtraction(new Polynomial(a), new Polynomial(b));
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new double[] { 2, 3.4, 7 }, new double[] { 1, 5, 1.1 }, new double[] { 2, 17, 7.7 })]
        public void Multiplication_PolynomsLengthsAreEqual_PositiveTest(double[] a, double[] b, double[] forExpected)
        {
            Polynomial expected = new Polynomial(forExpected);
            Polynomial actual = Polynomial.Multiplication(new Polynomial(a), new Polynomial(b));
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new double[] { 2, 3.4, 7, 0 }, new double[] { 1, 5, 1.1 }, new double[] { 2, 17, 7.7, 0 })]
        [TestCase(new double[] { 2, -3.33, 7, 1 }, new double[] { 1, 5, 1.1 }, new double[] { 2, -16.65, 7.7, 1 })]
        [TestCase(new double[] { 2, 3.45, -7 }, new double[] { 1, -3.45, -1.1, 2, 3 }, new double[] { 2, -11.9025, 7.7, 2, 3 })]
        public void Multiplication_PolynomsLengthsAreDifferent_PositiveTest(double[] a, double[] b, double[] forExpected)
        {
            Polynomial expected = new Polynomial(forExpected);
            Polynomial actual = Polynomial.Multiplication(new Polynomial(a), new Polynomial(b));
            Assert.AreEqual(expected, actual);
        }
        
        [TestCase(new double[] { double.NaN, 4, 1, 12 })]
        [TestCase(new double[] { 2, double.NegativeInfinity, 1, 12 })]
        [TestCase(new double[] { 2, 4, double.PositiveInfinity, 12 })]
        public void Ctor_HasInfinityOrNaNCoef_ThrowsArgumentException(double[] coefficients)
        {
            Assert.Throws<ArgumentException>(() => new Polynomial(coefficients));
        }
    }
}
