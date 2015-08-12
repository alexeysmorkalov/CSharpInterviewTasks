using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpInterviewTask
{
    /// <summary>
    /// You have an array of integers, and for each index you want to find the product of every integer except the integer at that index.
    /// Write a function get_products_of_all_ints_except_at_index() that takes an array of integers and returns an array of the products.
    ///
    /// For example, given:
    /// 
    /// [1, 7, 3, 4]
    ///   your function would return:
    ///
    /// [84, 12, 28, 21]
    /// by calculating:
    ///
    /// [7*3*4, 1*3*4, 1*7*4, 1*7*3]
    /// 
    /// Do not use division in your solution.
    /// https://www.interviewcake.com/question/product-of-other-numbers
    /// </summary>
    /// <remarks>
    /// Gotchas
    /// 1. Does your function work if the input array contains zeroes? Remember—no division.
    /// </remarks>
    [TestClass]
    public class ProductOfOtherNumbers
    {
        [TestMethod]
        public void Example1()
        {
            var res = get_products_of_all_ints_except_at_index(new int[] { 1, 7, 3, 4 });
            Assert.AreEqual(4, res.Length);
            Assert.AreEqual(84, res[0]);
            Assert.AreEqual(12, res[1]);
            Assert.AreEqual(28, res[2]);
            Assert.AreEqual(21, res[3]);
        }

        [TestMethod]
        public void EmptyInput()
        {
            var res = get_products_of_all_ints_except_at_index(new int[] { });
            Assert.AreEqual(0, res.Length);
        }

        [TestMethod]
        public void NullInput()
        {
            var res = get_products_of_all_ints_except_at_index(null);
            Assert.AreEqual(0, res.Length);
        }

        /// <summary>
        /// What to return is only 1 integer was in input
        /// I guess "0"
        /// </summary>
        [TestMethod]
        public void SingleInput()
        {
            var res = get_products_of_all_ints_except_at_index(new int[] {1});
            Assert.AreEqual(1, res.Length);
            Assert.AreEqual(0, res[0]);
        }

        /// <summary>
        /// What to return if only 2 integers were in input?
        /// </summary>
        [TestMethod]
        public void DoubleInput()
        {
            var res = get_products_of_all_ints_except_at_index(new int[] { 1, 5 });
            Assert.AreEqual(2, res.Length);
            Assert.AreEqual(5, res[0]);
            Assert.AreEqual(1, res[1]);
        }

        /// <summary>
        /// Does your function work if the input array contains zeroes?
        /// </summary>
        [TestMethod]
        public void ZerosInInput()
        {
            var res = get_products_of_all_ints_except_at_index(new int[] { 1, 3, 0, 1 });
            Assert.AreEqual(4, res.Length);
            Assert.AreEqual(0, res[0]);
            Assert.AreEqual(0, res[1]);
            Assert.AreEqual(3, res[2]);
            Assert.AreEqual(0, res[0]);
        }
        /// <summary>
        /// takes an array of integers and returns an array of the products.
        /// </summary>
        /// <param name="integers">array of integers</param>
        /// <returns>array of the products</returns>
        /// <remarks>
        /// We are returning decimal because the biggest result maybe int.MaxValue^n
        /// n - array length
        /// 
        /// This would give us a runtime of O(n^2), we need a better solution
        /// </remarks>
        public decimal[] get_products_of_all_ints_except_at_index0(int[] integers)
        {
            if (integers == null) return new decimal[] { };
            if (integers.Length == 0) return new decimal[] { };
            if (integers.Length == 1) return new decimal[] { 0 };
            decimal[] result = new decimal[integers.Length];
            // Init
            for (int i = 0; i < integers.Length; i++)
            {
                result[i] = 1;
            }
            for (int i = 0; i < integers.Length; i++)
            {
                for (int j = 0; j < integers.Length; j++)
                {
                    if (i != j)
                        result[i] = result[i] * integers[j];
                }
            }
            return result;
        }

        public decimal[] get_products_of_all_ints_except_at_index(int[] integers)
        {
            if (integers == null) return new decimal[] { };
            if (integers.Length == 0) return new decimal[] { };
            if (integers.Length == 1) return new decimal[] { 0 };
            decimal[] result = new decimal[integers.Length];

            // for each integer, we find the product of all the integers
            // before it, storing the total product so far each time
            decimal product = 1;
            for (int i = 0; i < integers.Length; i++)
            {
                result[i] = product;
                product = product * integers[i];
            }
            // for each integer, we find the product of all the integers
            // after it. since each index in products already has the
            // product of all the integers before it, now we're storing
            // the total product of all other integers
            product = 1;
            for (int i = integers.Length - 1; i >= 0; i--)
            {
                result[i] = result[i] * product;
                product = product * integers[i];
            }
            return result;
        }
    }
}
