using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinarySearchTreeTests
{
    [TestClass]
    public class BSTTests
    {
        public BinarySearchTree BTS { get; set; }
        public int K { get; set; }
        [TestInitialize]
        public void TestSetup()
        {
            int[] array = new int[] { 3, 3, 2, 3, 4, 8, 9, 7 };
            K = 14;
            BTS = new BinarySearchTree();
            for (int i = 0; i < array.Length; i++)
            {
                BTS.Insert(array[i]);
            }

        }
        [TestMethod]
        public void RemoveLastMinimum()
        {
            BTS.Remove(12, K);
            var x = BTS.Find(2);

            Assert.AreEqual(0,x);
        }
        [TestMethod]
        public void RemoveFirstOne()
        {
            BTS.Remove(11, K);
            Assert.AreEqual(4, BTS.Root.Element);
            Assert.AreEqual(3, BTS.Root.Left.Element);
            Assert.AreEqual(2, BTS.Root.Left.Left.Element);
            Assert.AreEqual(3, BTS.Root.Left.Left.Right.Element);
        }

        [TestMethod]
        public void RemoveRepeatedOne()
        {
            BTS.Remove(11, K);
            BTS.Remove(11, K);
            Assert.AreEqual(4, BTS.Root.Element);
            Assert.AreEqual(2, BTS.Root.Left.Element);
            Assert.AreEqual(3, BTS.Root.Left.Right.Element);
        }
        [TestMethod]
        public void RemoveRightChild()
        {
            BTS.Remove(10, K);
            Assert.AreEqual(3, BTS.Root.Element);
            Assert.AreEqual(8, BTS.Root.Right.Element);
        }
        [TestMethod]
        public void RemoveBigSmaller()
        {
            BTS.Remove(7, K);
            Assert.AreEqual(3, BTS.Root.Element);
            Assert.AreEqual(4, BTS.Root.Right.Element);
            Assert.AreEqual(8, BTS.Root.Right.Right.Element);
            Assert.IsNull(BTS.Root.Right.Right.Left);
        }
    }
}
