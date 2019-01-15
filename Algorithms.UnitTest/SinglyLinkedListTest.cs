using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using DataStructures.LinkedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.UnitTest
{
    [TestClass]
    public class SinglyLinkedListTest
    {
        public TestContext TestContext { get; set; }
        private static TestContext testContext;

        private SinglyLinkedList<int> singlyLinkedList;

        public SinglyLinkedListTest()
        {

        }


        [ClassInitialize]
        public static void SetupTests(TestContext context)
        {
            testContext = context;
        }

        [TestInitialize]
        public void TestInitialize()
        {


            this.singlyLinkedList = new SinglyLinkedList<int>();
        }

        [TestMethod]
        public void AddFirstNode()
        {
            var dds = TestContext.CurrentTestOutcome;
            var node = new Node<int>(1);
            singlyLinkedList.AddFirst(node);
            Assert.IsNotNull(singlyLinkedList.First(), "Linked List is empty");
        }
        [TestMethod]
        public void AddTwoNodesHead()
        {
            var firstNode = new Node<int>(1);
            var SecondNode = new Node<int>(2);
            singlyLinkedList.AddFirst(firstNode);
            singlyLinkedList.AddFirst(SecondNode);
            Assert.AreEqual(singlyLinkedList.First().Data, SecondNode.Data, "invalid head element");
            Assert.AreEqual(singlyLinkedList.Last().Data, firstNode.Data, "invalid tail element");
        }
        [TestMethod]
        public void AddTwoNodesToTail()
        {
            var firstNode = new Node<int>(1);
            var SecondNode = new Node<int>(2);
            singlyLinkedList.AddLast(firstNode);
            singlyLinkedList.AddLast(SecondNode);
            Assert.AreEqual(singlyLinkedList.First().Data, firstNode.Data, "invalid head element");
            Assert.AreEqual(singlyLinkedList.Last().Data, SecondNode.Data, "invalid tail element");
        }
        [TestMethod]
        public void AddFiveNodesHead()
        {
            for (int i = 1; i <= 5; i++)
                singlyLinkedList.AddFirst(new Node<int>(i));

            Assert.AreEqual(singlyLinkedList.First().Data, 5, "invalid head element");
            Assert.AreEqual(singlyLinkedList.Last().Data, 1, "invalid tail element");
            Assert.AreEqual(singlyLinkedList.Count(), 5, "invalid count");
        }
        [TestMethod]
        public void AddFiveNodesToTail()
        {
            for (int i = 1; i <= 5; i++)
                singlyLinkedList.AddLast(new Node<int>(i));

            Assert.AreEqual(singlyLinkedList.First().Data, 1, "invalid head element");
            Assert.AreEqual(singlyLinkedList.Last().Data, 5, "invalid tail element");
            Assert.AreEqual(singlyLinkedList.Count(), 5, "invalid count");
        }
        [DataTestMethod]
        [SinglyLinkedListDataSource]
        public void VerifyAddNodesHead(Node<int> node)
        {
            singlyLinkedList.AddFirst(node);

            Assert.AreEqual(singlyLinkedList.First().Data, node.Data, "invalid head element");


        }
        [DataTestMethod]
        [SinglyLinkedListDataSource]
        public void VerifyAddNodesToTail(Node<int> node)
        {
            singlyLinkedList.AddLast(node);

            Assert.AreEqual(singlyLinkedList.Last().Data, node.Data, "invalid tail element");

        }

        [TestMethod]
        public void VerifyAddNodesHeadTime()
        {
            for (int i = 1; i <= 1000; i++)
                singlyLinkedList.AddFirst(new Node<int>(i));

            Assert.AreEqual(singlyLinkedList.First().Data, 1000, "invalid head element");
            Assert.AreEqual(singlyLinkedList.Last().Data, 1, "invalid tail element");
            Assert.AreEqual(singlyLinkedList.Count(), 1000, "invalid count");
        }

        [TestMethod]
        public void VerifyAddNodesToTailTime()
        {
            for (int i = 1; i <= 1000; i++)
                singlyLinkedList.AddLast(new Node<int>(i));

            Assert.AreEqual(singlyLinkedList.First().Data, 1, "invalid head element");
            Assert.AreEqual(singlyLinkedList.Last().Data, 1000, "invalid tail element");
            Assert.AreEqual(singlyLinkedList.Count(), 1000, "invalid count");
        }
        [TestMethod]
        public void AddBulkNodes()
        {
            List<Node<int>> source = new List<Node<int>>();
            for (int i = 1; i <= 1000; i++)
                source.Add(new Node<int>(i));

            var list = new SinglyLinkedList<int>(source);

            Assert.AreEqual(list.First().Data, 1000, "invalid head element");
            Assert.AreEqual(list.Last().Data, 1, "invalid tail element");
            Assert.AreEqual(list.Count(), 1000, "invalid count");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Null collection doesn't allow.")]
        public void AddNullCollection()
        {
            var list = new SinglyLinkedList<int>((List<Node<int>>)null);
        }

        [TestMethod]
        public void GetListItems()
        {
            int j = 0;
            for (int i = 1; i <= 5; i++)
                singlyLinkedList.AddLast(new Node<int>(i));

            foreach (var item in singlyLinkedList.Get())
                j++;

            Assert.AreEqual(j, 5, "invalid count");
        }

        [TestMethod]
        public void RemoveItem()
        {
            for (int i = 1; i <= 5; i++)
                singlyLinkedList.AddLast(new Node<int>(i));

            singlyLinkedList.Remove(5);

            Assert.AreEqual(singlyLinkedList.Count(), 4, "invalid count");
            Assert.AreEqual(singlyLinkedList.Last().Data, 4, "invalid tail element");

        }
        [TestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(5)]
        public void RemoveItem(int item)
        {
            for (int i = 1; i <= 5; i++)
                singlyLinkedList.AddLast(new Node<int>(i));

            singlyLinkedList.Remove(item);

            Assert.AreEqual(singlyLinkedList.Count(), 4, "invalid count");
            Assert.IsFalse(singlyLinkedList.Contains(item), "invalid list");

        }
        [TestMethod]
        public void RemovedFirst()
        {
            for (int i = 1; i <= 1000; i++)
                singlyLinkedList.AddFirst(new Node<int>(i));

            singlyLinkedList.RemoveFirst();

            Assert.AreEqual(singlyLinkedList.Count(), 999, "invalid count");
            Assert.AreEqual(singlyLinkedList.First().Data, 999, "invalid head element");
            Assert.AreEqual(singlyLinkedList.Last().Data, 1, "invalid tail element");

        }

        [TestMethod]
        public void RemovedLast()
        {
            for (int i = 1; i <= 1000; i++)
                singlyLinkedList.AddLast(new Node<int>(i));

            singlyLinkedList.RemoveLast();

            Assert.AreEqual(singlyLinkedList.Count(), 999, "invalid count");
            Assert.AreEqual(singlyLinkedList.First().Data, 1, "invalid head element");
            Assert.AreEqual(singlyLinkedList.Last().Data, 999, "invalid tail element");

        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.singlyLinkedList = null;
        }
    }
    public class SinglyLinkedListDataSourceAttribute : Attribute, ITestDataSource
    {
        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            yield return new object[] { new Node<int>(1) };
            yield return new object[] { new Node<int>(2) };
            yield return new object[] { new Node<int>(3) };
            yield return new object[] { new Node<int>(4) };
            yield return new object[] { new Node<int>(5) };
            yield return new object[] { new Node<int>(6) };
            yield return new object[] { new Node<int>(7) };
            yield return new object[] { new Node<int>(8) };
            yield return new object[] { new Node<int>(9) };
            yield return new object[] { new Node<int>(10) };
            yield return new object[] { new Node<int>(11) };
            yield return new object[] { new Node<int>(12) };
            yield return new object[] { new Node<int>(13) };
            yield return new object[] { new Node<int>(14) };
            yield return new object[] { new Node<int>(3) };
            yield return new object[] { new Node<int>(15) };
            yield return new object[] { new Node<int>(16) };
            yield return new object[] { new Node<int>(17) };
            yield return new object[] { new Node<int>(18) };
            yield return new object[] { new Node<int>(19) };
            yield return new object[] { new Node<int>(20) };
        }

        public string GetDisplayName(MethodInfo methodInfo, object[] data)
        {
            if (data != null)
                return string.Format(CultureInfo.CurrentCulture, "Custom - {0} ({1})", methodInfo.Name, string.Join(",", data));

            return null;
        }
    }
}

