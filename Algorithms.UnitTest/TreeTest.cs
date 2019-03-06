using DataStructures.Tree;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Algorithms.UnitTest
{
    [TestClass]
    public class TreeTest
    {
        Tree<int> tree;

        [TestInitialize]
        public void TestInitialize()
        {
            this.tree = new Tree<int>(1);
        }
        [TestMethod]
        public void AddFiveChild ()
        {
            for(int i=1;i<=5;i++)
            this.tree.Insert(this.tree.Root.Value, i);

            Assert.AreEqual(tree.Root.Value, 1, "invalid root element");
            Assert.AreEqual(tree.Count, 6, "invalid count");
            Assert.AreEqual(tree.Root.ChildrenCount, 5, "invalid count");
            Assert.AreEqual(tree.GetHeight(), 1, "invalid tree height");
        }

        [TestMethod]
        public void AddChildOfRootLastNode()
        {
            for (int i = 1; i <= 5; i++)
                this.tree.Insert(this.tree.Root.Value, i);

            this.tree.Insert(5, 7);
            this.tree.Insert(5, 8);
            this.tree.Insert(8, 9);

            Assert.AreEqual(tree.Root.Value, 1, "invalid root element");
            Assert.AreEqual(tree.Count, 9, "invalid count");
            Assert.AreEqual(tree.Root.ChildrenCount, 5, "invalid count");
            Assert.AreEqual(tree.GetHeight(), 3, "invalid tree height");

        }

        [TestMethod]
        public void DeleteTreeNode()
        {
            for (int i = 1; i <= 5; i++)
                this.tree.Insert(this.tree.Root.Value, i);

            this.tree.Insert(5, 7);

            this.tree.Delete(5);
            Assert.AreEqual(tree.Root.Value, 1, "invalid root element");
            Assert.AreEqual(tree.Count, 6, "invalid count");
            Assert.AreEqual(tree.Root.ChildrenCount, 5, "invalid count");
            Assert.AreEqual(tree.GetHeight(), 1, "invalid tree height");

        }
        [TestMethod]
        public void GetTreeLeafNode()
        {
            int last = 0;
            for (int i = 1; i <= 5; i++)
                this.tree.Insert(this.tree.Root.Value, i);

            this.tree.Insert(5, 7);
            foreach (var item in this.tree.Get())
                last = item;

            Assert.AreEqual(tree.Root.Value, 1, "invalid root element");
            Assert.AreEqual(tree.Count, 7, "invalid count");
            Assert.AreEqual(tree.Root.ChildrenCount, 5, "invalid count");
            Assert.AreEqual(tree.GetHeight(), 2, "invalid tree height");
            Assert.AreEqual(last, 7, "invalid leaf node");
        }
    }
}
