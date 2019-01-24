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
            singlyLinkedList.AddFirst(1);
            Assert.IsNotNull(singlyLinkedList.GetFirst(), "Linked List is empty");
        }
        [TestMethod]
        public void AddTwoNodesHead()
        {
            singlyLinkedList.AddFirst(1);
            singlyLinkedList.AddFirst(2);
            Assert.AreEqual(singlyLinkedList.GetFirst(), 2, "invalid head element");
            Assert.AreEqual(singlyLinkedList.GetLast(), 1, "invalid tail element");
        }
        [TestMethod]
        public void AddTwoNodesToTail()
        {

            singlyLinkedList.AddLast(1);
            singlyLinkedList.AddLast(2);
            Assert.AreEqual(singlyLinkedList.GetFirst(), 1, "invalid head element");
            Assert.AreEqual(singlyLinkedList.GetLast(), 2, "invalid tail element");
        }
        [TestMethod]
        public void AddFiveNodesHead()
        {
            for (int i = 1; i <= 5; i++)
                singlyLinkedList.AddFirst(i);

            Assert.AreEqual(singlyLinkedList.GetFirst(), 5, "invalid head element");
            Assert.AreEqual(singlyLinkedList.GetLast(), 1, "invalid tail element");
            Assert.AreEqual(singlyLinkedList.Count(), 5, "invalid count");
        }
        [TestMethod]
        public void AddFiveNodesToTail()
        {
            for (int i = 1; i <= 5; i++)
                singlyLinkedList.AddLast(i);

            Assert.AreEqual(singlyLinkedList.GetFirst(), 1, "invalid head element");
            Assert.AreEqual(singlyLinkedList.GetLast(), 5, "invalid tail element");
            Assert.AreEqual(singlyLinkedList.Count(), 5, "invalid count");
        }
        [DataTestMethod]
        [SinglyLinkedListDataSource]
        public void VerifyAddNodesHead(int item)
        {
            singlyLinkedList.AddFirst(item);

            Assert.AreEqual(singlyLinkedList.GetFirst(), item, "invalid head element");


        }
        [DataTestMethod]
        [SinglyLinkedListDataSource]
        public void VerifyAddNodesToTail(int item)
        {
            singlyLinkedList.AddLast(item);

            Assert.AreEqual(singlyLinkedList.GetLast(), item, "invalid tail element");

        }

        [TestMethod]
        public void VerifyAddNodesHeadTime()
        {
            for (int i = 1; i <= 1000; i++)
                singlyLinkedList.AddFirst(i);

            Assert.AreEqual(singlyLinkedList.GetFirst(), 1000, "invalid head element");
            Assert.AreEqual(singlyLinkedList.GetLast(), 1, "invalid tail element");
            Assert.AreEqual(singlyLinkedList.Count(), 1000, "invalid count");
        }

        [TestMethod]
        public void VerifyAddNodesToTailTime()
        {
            for (int i = 1; i <= 1000; i++)
                singlyLinkedList.AddLast(i);

            Assert.AreEqual(singlyLinkedList.GetFirst(), 1, "invalid head element");
            Assert.AreEqual(singlyLinkedList.GetLast(), 1000, "invalid tail element");
            Assert.AreEqual(singlyLinkedList.Count(), 1000, "invalid count");
        }
        [TestMethod]
        public void AddBulkNodes()
        {
            List<int> source = new List<int>();
            for (int i = 1; i <= 1000; i++)
                source.Add(i);

            var list = new SinglyLinkedList<int>(source);

            Assert.AreEqual(list.GetFirst(), 1000, "invalid head element");
            Assert.AreEqual(list.GetLast(), 1, "invalid tail element");
            Assert.AreEqual(list.Count(), 1000, "invalid count");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Null collection doesn't allow.")]
        public void AddNullCollection()
        {
            var list = new SinglyLinkedList<int>(null);
        }

        [TestMethod]
        [DataRow(true)]
        [DataRow(false)]
        public void GetListItems(bool addFirst)
        {
            int j = 0;
            for (int i = 1; i <= 5; i++)
                if (addFirst)
                    singlyLinkedList.AddFirst(i);
                else
                    singlyLinkedList.AddLast(i);

            foreach (var item in singlyLinkedList.Get())
                j++;

            Assert.AreEqual(j, 5, "invalid count");
        }

        [TestMethod]
        public void RemoveItem()
        {
            for (int i = 1; i <= 5; i++)
                singlyLinkedList.AddLast(i);

            singlyLinkedList.Remove(5);

            Assert.AreEqual(singlyLinkedList.Count(), 4, "invalid count");
            Assert.AreEqual(singlyLinkedList.GetLast(), 4, "invalid tail element");

        }
        [TestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(5)]
        [DataRow(7)]
        public void RemoveItem(int item)
        {
            for (int i = 1; i <= 5; i++)
                singlyLinkedList.AddLast(i);

            singlyLinkedList.Remove(item);

            Assert.AreEqual(singlyLinkedList.Count(), 4, "invalid count");
            Assert.IsFalse(singlyLinkedList.Contains(item), "invalid list");

        }
        [TestMethod]
        public void RemovedFirst()
        {
            for (int i = 1; i <= 1000; i++)
                singlyLinkedList.AddFirst(i);

            singlyLinkedList.RemoveFirst();

            Assert.AreEqual(singlyLinkedList.Count(), 999, "invalid count");
            Assert.AreEqual(singlyLinkedList.GetFirst(), 999, "invalid head element");
            Assert.AreEqual(singlyLinkedList.GetLast(), 1, "invalid tail element");

        }

        [TestMethod]
        public void RemovedLast()
        {
            for (int i = 1; i <= 1000; i++)
                singlyLinkedList.AddLast(i);

            singlyLinkedList.RemoveLast();

            Assert.AreEqual(singlyLinkedList.Count(), 999, "invalid count");
            Assert.AreEqual(singlyLinkedList.GetFirst(), 1, "invalid head element");
            Assert.AreEqual(singlyLinkedList.GetLast(), 999, "invalid tail element");

        }

        [TestMethod]
        [DataRow(1,7)]
        [DataRow(3, 7)]
        [DataRow(5, 7)]
        public void AddAfter(int oldItem,int item)
        {
            for (int i = 1; i <= 5; i++)
                singlyLinkedList.AddLast(i);

            singlyLinkedList.AddAfter(oldItem, item);

            Assert.AreEqual(singlyLinkedList.Count(), 6, "invalid count");
            Assert.IsTrue(singlyLinkedList.Contains(item), "Item doesn't exists.");
        }
        [TestMethod]
        [DataRow(1, 7)]
        [DataRow(3, 7)]
        [DataRow(5, 7)]
        public void AddBefore(int oldItem, int item)
        {
            for (int i = 1; i <= 5; i++)
                singlyLinkedList.AddLast(i);

            singlyLinkedList.AddBefore(oldItem, item);

            Assert.AreEqual(singlyLinkedList.Count(), 6, "invalid count");
            Assert.IsTrue(singlyLinkedList.Contains(item), "Item doesn't exists.");
        }
        [TestMethod]
        public void AddNullItem()
        {
            var list = new SinglyLinkedList<string>();
            list.AddFirst(null);
            list.AddLast(null);
            list.AddAfter(null,null);
            list.AddBefore(null, null);
            Assert.AreEqual(list.Count(), 4, "invalid count");
            list.Remove(null);
            list.RemoveFirst();
            list.RemoveLast();
            Assert.AreEqual(list.Count(), 1, "invalid count");
        }

        [TestMethod]
        public void CheckListEmpty()
        {
            int j = 0;
            foreach (var item in singlyLinkedList.Get())
                j++;

            Assert.AreEqual(0, j, "Invalid count.");
            Assert.IsFalse(singlyLinkedList.Contains(2), "list contains some item(s)");
        }
        [TestMethod]
        public void CheckListLastItem()
        {
            for (int i = 1; i <= 5; i++)
                singlyLinkedList.AddLast(i);

            Assert.AreEqual(singlyLinkedList.GetLast(), 5, "invalid tail element");
            Assert.IsTrue(singlyLinkedList.Contains(5), "list doesn't contains element");

        }
        [TestMethod]
        public void CopyToArray()
        {
            var arr = new int[5];
            for (int i = 1; i <= 5; i++)
                singlyLinkedList.AddLast(i);

            singlyLinkedList.CopyTo(arr, 0);
            Assert.AreEqual(arr[0], 1, "invalid first item");
            Assert.AreEqual(arr[4], 5, "invalid last item");
        }
        [TestMethod]
        public void CopyEmptyListToArray()
        {
            var arr = new int[1];
            singlyLinkedList.CopyTo(arr, 0);

            Assert.AreEqual(arr[0], 0, "invalid item");
        }

        [TestMethod]
        public void AddBeforeInEmptyList()
        {
            singlyLinkedList.AddBefore(2, 4);

            Assert.AreEqual(singlyLinkedList.Count(), 0, "invalid count");
            Assert.IsFalse(singlyLinkedList.Contains(4), "Item exists.");
        }

        [TestMethod]
        public void AddAfterInEmptyList()
        {
            singlyLinkedList.AddAfter(2, 4);

            Assert.AreEqual(singlyLinkedList.Count(), 0, "invalid count");
            Assert.IsFalse(singlyLinkedList.Contains(4), "Item exists.");
        }


        [TestMethod]
        public void RemoveFromEmptyList()
        {
            singlyLinkedList.Remove(5);
            Assert.AreEqual(singlyLinkedList.Count(), 0, "invalid item");
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
            yield return new object[] { 3};
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

