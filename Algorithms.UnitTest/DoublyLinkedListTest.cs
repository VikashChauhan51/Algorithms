using DataStructures.LinkedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.UnitTest
{
    [TestClass]
    public class DoublyLinkedListTest
    {
        public TestContext TestContext { get; set; }
        private static TestContext testContext;

        private DoublyLinkedList<int> doublyLinkedListTest;

        public DoublyLinkedListTest()
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


            this.doublyLinkedListTest = new DoublyLinkedList<int>();
        }

        [TestMethod]
        public void AddFirstNode()
        {
            doublyLinkedListTest.AddFirst(1);
            Assert.IsNotNull(doublyLinkedListTest.GetFirst(), "Linked List is empty");
        }
        [TestMethod]
        public void AddTwoNodesHead()
        {
            doublyLinkedListTest.AddFirst(1);
            doublyLinkedListTest.AddFirst(2);
            Assert.AreEqual(doublyLinkedListTest.GetFirst(), 2, "invalid head element");
            Assert.AreEqual(doublyLinkedListTest.GetLast(), 1, "invalid tail element");
        }
        [TestMethod]
        public void AddTwoNodesToTail()
        {

            doublyLinkedListTest.AddLast(1);
            doublyLinkedListTest.AddLast(2);
            Assert.AreEqual(doublyLinkedListTest.GetFirst(), 1, "invalid head element");
            Assert.AreEqual(doublyLinkedListTest.GetLast(), 2, "invalid tail element");
        }

        [TestMethod]
        public void AddFiveNodesHead()
        {
            for (int i = 1; i <= 5; i++)
                doublyLinkedListTest.AddFirst(i);

            Assert.AreEqual(doublyLinkedListTest.GetFirst(), 5, "invalid head element");
            Assert.AreEqual(doublyLinkedListTest.GetLast(), 1, "invalid tail element");
            Assert.AreEqual(doublyLinkedListTest.Count(), 5, "invalid count");
        }
        [TestMethod]
        public void AddFiveNodesToTail()
        {
            for (int i = 1; i <= 5; i++)
                doublyLinkedListTest.AddLast(i);

            Assert.AreEqual(doublyLinkedListTest.GetFirst(), 1, "invalid head element");
            Assert.AreEqual(doublyLinkedListTest.GetLast(), 5, "invalid tail element");
            Assert.AreEqual(doublyLinkedListTest.Count(), 5, "invalid count");
        }
        [DataTestMethod]
        [DoublyLinkedListDataSource]
        public void VerifyAddNodesHead(int item)
        {
            doublyLinkedListTest.AddFirst(item);

            Assert.AreEqual(doublyLinkedListTest.GetFirst(), item, "invalid head element");


        }
        [DataTestMethod]
        [DoublyLinkedListDataSource]
        public void VerifyAddNodesToTail(int item)
        {
            doublyLinkedListTest.AddLast(item);

            Assert.AreEqual(doublyLinkedListTest.GetLast(), item, "invalid tail element");

        }

        [TestMethod]
        public void VerifyAddNodesHeadTime()
        {
            for (int i = 1; i <= 1000; i++)
                doublyLinkedListTest.AddFirst(i);

            Assert.AreEqual(doublyLinkedListTest.GetFirst(), 1000, "invalid head element");
            Assert.AreEqual(doublyLinkedListTest.GetLast(), 1, "invalid tail element");
            Assert.AreEqual(doublyLinkedListTest.Count(), 1000, "invalid count");
        }

        [TestMethod]
        public void VerifyAddNodesToTailTime()
        {
            for (int i = 1; i <= 1000; i++)
                doublyLinkedListTest.AddLast(i);

            Assert.AreEqual(doublyLinkedListTest.GetFirst(), 1, "invalid head element");
            Assert.AreEqual(doublyLinkedListTest.GetLast(), 1000, "invalid tail element");
            Assert.AreEqual(doublyLinkedListTest.Count(), 1000, "invalid count");
        }
        [TestMethod]
        public void AddBulkNodes()
        {
            List<int> source = new List<int>();
            for (int i = 1; i <= 1000; i++)
                source.Add(i);

            var list = new DoublyLinkedList<int>(source);

            Assert.AreEqual(list.GetFirst(), 1000, "invalid head element");
            Assert.AreEqual(list.GetLast(), 1, "invalid tail element");
            Assert.AreEqual(list.Count(), 1000, "invalid count");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Null collection doesn't allow.")]
        public void AddNullCollection()
        {
            var list = new DoublyLinkedList<int>(null);
        }

        [TestMethod]
        [DataRow(true)]
        [DataRow(false)]
        public void GetListItems(bool addFirst)
        {
            int j = 0;
            for (int i = 1; i <= 5; i++)
                if (addFirst)
                    doublyLinkedListTest.AddFirst(i);
                else
                    doublyLinkedListTest.AddLast(i);

            foreach (var item in doublyLinkedListTest.Get())
                j++;

            Assert.AreEqual(j, 5, "invalid count");
        }

        [TestMethod]
        public void RemoveItem()
        {
            for (int i = 1; i <= 5; i++)
                doublyLinkedListTest.AddLast(i);

            doublyLinkedListTest.Remove(5);

            Assert.AreEqual(doublyLinkedListTest.Count(), 4, "invalid count");
            Assert.AreEqual(doublyLinkedListTest.GetLast(), 4, "invalid tail element");

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
                doublyLinkedListTest.AddLast(i);

            doublyLinkedListTest.Remove(item);

            Assert.AreEqual(doublyLinkedListTest.Count(), 4, "invalid count");
            Assert.IsFalse(doublyLinkedListTest.Contains(item), "invalid list");

        }
        [TestMethod]
        public void RemovedFirst()
        {
            for (int i = 1; i <= 1000; i++)
                doublyLinkedListTest.AddFirst(i);

            doublyLinkedListTest.RemoveFirst();

            Assert.AreEqual(doublyLinkedListTest.Count(), 999, "invalid count");
            Assert.AreEqual(doublyLinkedListTest.GetFirst(), 999, "invalid head element");
            Assert.AreEqual(doublyLinkedListTest.GetLast(), 1, "invalid tail element");

        }

        [TestMethod]
        public void RemovedLast()
        {
            for (int i = 1; i <= 1000; i++)
                doublyLinkedListTest.AddLast(i);

            doublyLinkedListTest.RemoveLast();

            Assert.AreEqual(doublyLinkedListTest.Count(), 999, "invalid count");
            Assert.AreEqual(doublyLinkedListTest.GetFirst(), 1, "invalid head element");
            Assert.AreEqual(doublyLinkedListTest.GetLast(), 999, "invalid tail element");

        }


        [TestMethod]
        [DataRow(1, 7)]
        [DataRow(3, 7)]
        [DataRow(5, 7)]
        public void AddAfter(int oldItem, int item)
        {
            for (int i = 1; i <= 5; i++)
                doublyLinkedListTest.AddLast(i);

            doublyLinkedListTest.AddAfter(oldItem, item);

            Assert.AreEqual(doublyLinkedListTest.Count(), 6, "invalid count");
            Assert.IsTrue(doublyLinkedListTest.Contains(item), "Item doesn't exists.");
        }
        [TestMethod]
        [DataRow(1, 7)]
        [DataRow(3, 7)]
        [DataRow(5, 7)]
        public void AddBefore(int oldItem, int item)
        {
            for (int i = 1; i <= 5; i++)
                doublyLinkedListTest.AddLast(i);

            doublyLinkedListTest.AddBefore(oldItem, item);

            Assert.AreEqual(doublyLinkedListTest.Count(), 6, "invalid count");
            Assert.IsTrue(doublyLinkedListTest.Contains(item), "Item doesn't exists.");
        }
        [TestMethod]
        public void AddNullItem()
        {
            var list = new DoublyLinkedList<string>();
            list.AddFirst(null);
            list.AddLast(null);
            list.AddAfter(null, null);
            list.AddBefore(null, null);
            Assert.AreEqual(list.Count(), 4, "invalid count");
            list.Remove(null);
            list.RemoveFirst();
            list.RemoveLast();
            Assert.AreEqual(list.Count(), 1, "invalid count");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.doublyLinkedListTest = null;
        }
    }

    public class DoublyLinkedListDataSourceAttribute : Attribute, ITestDataSource
    {
        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            yield return new object[] { 1 };
            yield return new object[] { 2 };
            yield return new object[] { 3 };
            yield return new object[] { 4 };
            yield return new object[] { 5 };
            yield return new object[] { 6 };
            yield return new object[] { 7 };
            yield return new object[] { 8 };
            yield return new object[] { 9 };
            yield return new object[] { 10 };
            yield return new object[] { 11 };
            yield return new object[] { 12 };
            yield return new object[] { 13 };
            yield return new object[] { 14 };
            yield return new object[] { 3 };
            yield return new object[] { 15 };
            yield return new object[] { 16 };
            yield return new object[] { 17 };
            yield return new object[] { 18 };
            yield return new object[] { 19 };
            yield return new object[] { 20 };
        }

        public string GetDisplayName(MethodInfo methodInfo, object[] data)
        {
            if (data != null)
                return string.Format(CultureInfo.CurrentCulture, "Custom - {0} ({1})", methodInfo.Name, string.Join(",", data));

            return null;
        }
    }
}
