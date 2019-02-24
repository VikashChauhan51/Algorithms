using DataStructures.Tree;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.UnitTest
{
    [TestClass]
    public class BinaryTreeTest
    {
        BinaryTree<int> binaryTree;

        [TestInitialize]
        public void TestInitialize()
        {
            this.binaryTree = new BinaryTree<int>();
        }

        [TestMethod]
        public void AddSomeAssendingItems()
        {
            for (int i = 1; i <= 20; i++)
                binaryTree.Add(i);

            Assert.AreEqual(binaryTree.GetHeight(), 19, "invalid tree height");
            Assert.AreEqual(binaryTree.Count(), 20, "invalid count");
            Assert.IsFalse(binaryTree.Root.IsFull, "invalid root Children");
            Assert.IsTrue(binaryTree.Contains(9), "item not found.");
            Assert.IsTrue(binaryTree.Contains(4), "item not found.");
            Assert.IsFalse(binaryTree.Contains(21), "invalid tree item.");
        }
        [TestMethod]
        public void AddSomeDesendingItems()
        {
            for (int i = 20; i > 0; i--)
                binaryTree.Add(i);

            Assert.AreEqual(binaryTree.GetHeight(), 19, "invalid tree height");
            Assert.AreEqual(binaryTree.Count(), 20, "invalid count");
            Assert.IsFalse(binaryTree.Root.IsFull, "invalid root Children");
            Assert.IsTrue(binaryTree.Contains(9), "item not found.");
            Assert.IsTrue(binaryTree.Contains(4), "item not found.");
            Assert.IsFalse(binaryTree.Contains(21), "invalid tree item.");
        }
        [TestMethod]
        public void AddItemsAndCheckThatExists()
        {
            int inOrderLast = -1;
            int preorderLast = -1;
            int postorderLast = -1;
            binaryTree.Add(6);
            binaryTree.Add(4);
            binaryTree.Add(8);
            binaryTree.Add(3);
            binaryTree.Add(5);
            binaryTree.Add(7);
            binaryTree.Add(9);

            foreach (var item in binaryTree.Inorder())
                inOrderLast = item;
            foreach (var item in binaryTree.Preorder())
                preorderLast = item;
            foreach (var item in binaryTree.Postorder())
                postorderLast = item;

            Assert.AreEqual(inOrderLast, 9, "invalid Inorder element");
            Assert.AreEqual(preorderLast, 9, "invalid Preorder element");
            Assert.AreEqual(postorderLast, 6, "invalid Postorder element");
            Assert.AreEqual(binaryTree.Root.Value, 6, "invalid root element");
            Assert.AreEqual(binaryTree.Count(), 7, "invalid count");
            Assert.IsTrue(binaryTree.Root.IsFull, "invalid root Children");
            Assert.AreEqual(binaryTree.GetHeight(), 2, "invalid tree height");
            Assert.IsTrue(binaryTree.Contains(9), "item not found.");
            Assert.IsTrue(binaryTree.Contains(4), "item not found.");
            Assert.IsFalse(binaryTree.Contains(1), "invalid tree item.");
        }
        [TestMethod]
        public void DeleteFromEmptyTree()
        {
            binaryTree.Delete(1);
            Assert.AreEqual(binaryTree.Count(), 0, "invalid count");
        }

        [TestMethod]
        public void DeleteItemAndCheckThatExists()
        {
            binaryTree.Add(6);
            binaryTree.Add(4);
            binaryTree.Add(8);
            binaryTree.Add(3);
            binaryTree.Add(5);
            binaryTree.Add(7);
            binaryTree.Add(9);

            binaryTree.Delete(6);
            binaryTree.Delete(4);
            binaryTree.Delete(9);

            Assert.AreEqual(binaryTree.Root.Value, 7, "invalid root element");
            Assert.AreEqual(binaryTree.Count(), 4, "invalid count");
            Assert.IsTrue(binaryTree.Root.IsFull, "invalid root Children");
            Assert.AreEqual(binaryTree.GetHeight(), 2, "invalid tree height");
            Assert.IsTrue(binaryTree.Contains(8), "item not found.");
            Assert.IsTrue(binaryTree.Contains(3), "item not found.");
            Assert.IsFalse(binaryTree.Contains(9), "invalid tree item.");
            Assert.IsFalse(binaryTree.Contains(6), "invalid tree item.");
        }

    }
}
