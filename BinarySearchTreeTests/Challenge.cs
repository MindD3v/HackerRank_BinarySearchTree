using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinarySearchTreeTests
{
    [TestClass]
    public class Challenge
    {
        [TestMethod]
        public void Test1()
        {
            int[] arrayA = new int[] { 18, 73, 55, 59, 37, 13, 1, 33 };
            int[] arrayB = new int[] { 81, 11, 77, 49, 65, 26, 29, 49 };

            var result = Comparer.GreaterThanK(arrayA, arrayB, 91);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void Test2()
        {
            int[] arrayA = new int[] { 84, 2, 50, 51, 19, 58, 12, 90, 81, 68, 54, 73, 81, 31, 79, 85, 39, 2 };
            int[] arrayB = new int[] { 53, 102, 40, 17, 33, 92, 18, 79, 66, 23, 84, 25, 38, 43, 27, 55, 8, 19 };

            Assert.AreEqual(arrayA.Length, arrayB.Length);

            //InsertionSort.SortReverse(arrayA);
            //InsertionSort.SortReverse(arrayB);

            var result = Comparer.GreaterThanK(arrayA, arrayB, 94);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Test3()
        {
            int[] arrayA = new int[] { 66, 66, 32, 75, 77, 34, 23, 35 };
            int[] arrayB = new int[] { 61, 17, 52, 20, 48, 11, 50, 5 };

            var result = Comparer.GreaterThanK(arrayA, arrayB, 88);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void Test4()
        {
            int[] arrayA = new int[] { 11, 16, 43, 5, 25, 22, 19, 32, 10, 26, 2, 42, 16, 1 };
            int[] arrayB = new int[] { 33, 1, 1, 20, 26, 7, 17, 39, 23, 34, 10, 11, 38, 20 };

            var result = Comparer.GreaterThanK(arrayA, arrayB, 45);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void Test10()
        {
            int[] arrayA = new int[] { 40 };
            int[] arrayB = new int[] { 38 };

            var result = Comparer.GreaterThanK(arrayA, arrayB, 70);

            Assert.IsTrue(result);
        }
    }
}
