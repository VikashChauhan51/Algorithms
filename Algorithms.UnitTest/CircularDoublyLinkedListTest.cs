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
    public class CircularDoublyLinkedListTest
    {
        public TestContext TestContext { get; set; }
        private static TestContext testContext;

        private CircularDoublyLinkedList<int> circularDoublyLinkedList;

        public CircularDoublyLinkedListTest()
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


            this.circularDoublyLinkedList = new CircularDoublyLinkedList<int>();
        }

        [TestMethod]
        public void AddFirstNode()
        {
            circularDoublyLinkedList.AddFirst(1);
            Assert.IsNotNull(circularDoublyLinkedList.GetFirst(), "Linked List is empty");
        }
        [TestMethod]
        public void AddTwoNodesHead()
        {
            circularDoublyLinkedList.AddFirst(1);
            circularDoublyLinkedList.AddFirst(2);
            Assert.AreEqual(circularDoublyLinkedList.GetFirst(), 2, "invalid head element");
            Assert.AreEqual(circularDoublyLinkedList.GetLast(), 1, "invalid tail element");
        }

        [TestMethod]
        public void AddFiveNodesHead()
        {
            for (int i = 1; i <= 5; i++)
                circularDoublyLinkedList.AddFirst(i);

            Assert.AreEqual(circularDoublyLinkedList.GetFirst(), 5, "invalid head element");
            Assert.AreEqual(circularDoublyLinkedList.GetLast(), 1, "invalid tail element");
            Assert.AreEqual(circularDoublyLinkedList.Count(), 5, "invalid count");
        }

        [TestMethod]
        public void AddTwoNodesToTail()
        {

            circularDoublyLinkedList.AddLast(1);
            circularDoublyLinkedList.AddLast(2);
            Assert.AreEqual(circularDoublyLinkedList.GetFirst(), 1, "invalid head element");
            Assert.AreEqual(circularDoublyLinkedList.GetLast(), 2, "invalid tail element");
        }


        [TestMethod]
        public void AddFiveNodesToTail()
        {
            for (int i = 1; i <= 5; i++)
                circularDoublyLinkedList.AddLast(i);

            Assert.AreEqual(circularDoublyLinkedList.GetFirst(), 1, "invalid head element");
            Assert.AreEqual(circularDoublyLinkedList.GetLast(), 5, "invalid tail element");
            Assert.AreEqual(circularDoublyLinkedList.Count(), 5, "invalid count");
        }

        [DataTestMethod]
        [CircularDoublyLinkedListDataSource]
        public void VerifyAddNodesHead(int item)
        {
            circularDoublyLinkedList.AddFirst(item);

            Assert.AreEqual(circularDoublyLinkedList.GetFirst(), item, "invalid head element");


        }
        [DataTestMethod]
        [CircularDoublyLinkedListDataSource]
        public void VerifyAddNodesToTail(int item)
        {
            circularDoublyLinkedList.AddLast(item);

            Assert.AreEqual(circularDoublyLinkedList.GetLast(), item, "invalid tail element");

        }

        [TestMethod]
        public void VerifyAddNodesHeadTime()
        {
            for (int i = 1; i <= 1000; i++)
                circularDoublyLinkedList.AddFirst(i);

            Assert.AreEqual(circularDoublyLinkedList.GetFirst(), 1000, "invalid head element");
            Assert.AreEqual(circularDoublyLinkedList.GetLast(), 1, "invalid tail element");
            Assert.AreEqual(circularDoublyLinkedList.Count(), 1000, "invalid count");
        }

        [TestMethod]
        public void VerifyAddNodesToTailTime()
        {
            for (int i = 1; i <= 1000; i++)
                circularDoublyLinkedList.AddLast(i);

            Assert.AreEqual(circularDoublyLinkedList.GetFirst(), 1, "invalid head element");
            Assert.AreEqual(circularDoublyLinkedList.GetLast(), 1000, "invalid tail element");
            Assert.AreEqual(circularDoublyLinkedList.Count(), 1000, "invalid count");
        }
        [TestMethod]
        public void AddBulkNodes()
        {
            List<int> source = new List<int>();
            for (int i = 1; i <= 1000; i++)
                source.Add(i);

            var list = new CircularSinglyLinkedList<int>(source);

            Assert.AreEqual(list.GetFirst(), 1, "invalid head element");
            Assert.AreEqual(list.GetLast(), 1000, "invalid tail element");
            Assert.AreEqual(list.Count(), 1000, "invalid count");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Null collection doesn't allow.")]
        public void AddNullCollection()
        {
            var list = new CircularDoublyLinkedList<int>(null);
        }

        [TestMethod]
        [DataRow(true)]
        [DataRow(false)]
        public void GetListItems(bool addFirst)
        {
            int j = 0;
            for (int i = 1; i <= 5; i++)
                if (addFirst)
                    circularDoublyLinkedList.AddFirst(i);
                else
                    circularDoublyLinkedList.AddLast(i);

            foreach (var item in circularDoublyLinkedList.Get())
                j++;

            Assert.AreEqual(j, 5, "invalid count");
        }

        [TestMethod]
        [DataRow(1, 7)]
        [DataRow(3, 7)]
        [DataRow(5, 7)]
        public void AddAfter(int oldItem, int item)
        {
            for (int i = 1; i <= 5; i++)
                circularDoublyLinkedList.AddLast(i);

            circularDoublyLinkedList.AddAfter(oldItem, item);

            Assert.AreEqual(circularDoublyLinkedList.Count(), 6, "invalid count");
            Assert.IsTrue(circularDoublyLinkedList.Contains(item), "Item doesn't exists.");
        }
        [TestMethod]
        [DataRow(1, 7)]
        [DataRow(3, 7)]
        [DataRow(5, 7)]
        public void AddBefore(int oldItem, int item)
        {
            for (int i = 1; i <= 5; i++)
                circularDoublyLinkedList.AddLast(i);

            circularDoublyLinkedList.AddBefore(oldItem, item);

            Assert.AreEqual(circularDoublyLinkedList.Count(), 6, "invalid count");
            Assert.IsTrue(circularDoublyLinkedList.Contains(item), "Item doesn't exists.");
        }

        [TestMethod]
        public void AddBeforeInSingleItemList()
        {
            circularDoublyLinkedList.AddFirst(1);
            circularDoublyLinkedList.AddBefore(1, 4);

            Assert.AreEqual(circularDoublyLinkedList.Count(), 2, "invalid count");
            Assert.IsTrue(circularDoublyLinkedList.Contains(4), "Item doesn't exists.");
        }

        [TestMethod]
        public void AddAfterInSingleItemList()
        {
            circularDoublyLinkedList.AddLast(1);
            circularDoublyLinkedList.AddAfter(1, 4);

            Assert.AreEqual(circularDoublyLinkedList.Count(), 2, "invalid count");
            Assert.IsTrue(circularDoublyLinkedList.Contains(4), "Item doesn't exists.");
        }

        [TestMethod]
        public void AddBeforeInEmptyList()
        {
            circularDoublyLinkedList.AddBefore(2, 4);

            Assert.AreEqual(circularDoublyLinkedList.Count(), 0, "invalid count");
            Assert.IsFalse(circularDoublyLinkedList.Contains(4), "Item exists.");
        }

        [TestMethod]
        public void AddAfterInEmptyList()
        {
            circularDoublyLinkedList.AddAfter(2, 4);

            Assert.AreEqual(circularDoublyLinkedList.Count(), 0, "invalid count");
            Assert.IsFalse(circularDoublyLinkedList.Contains(4), "Item exists.");
        }

        [TestMethod]
        public void CheckListEmpty()
        {
            int j = 0;
            foreach (var item in circularDoublyLinkedList.Get())
                j++;

            Assert.AreEqual(0, j, "Invalid count.");
            Assert.IsFalse(circularDoublyLinkedList.Contains(2), "list contains some item(s)");
        }
        [TestMethod]
        public void CheckListLastItem()
        {
            for (int i = 1; i <= 5; i++)
                circularDoublyLinkedList.AddLast(i);

            Assert.AreEqual(circularDoublyLinkedList.GetLast(), 5, "invalid tail element");
            Assert.IsTrue(circularDoublyLinkedList.Contains(5), "list doesn't contains element");

        }
        [TestMethod]
        public void CopyToArray()
        {
            var arr = new int[5];
            for (int i = 1; i <= 5; i++)
                circularDoublyLinkedList.AddLast(i);

            circularDoublyLinkedList.CopyTo(arr, 0);
            Assert.AreEqual(arr[0], 1, "invalid first item");
            Assert.AreEqual(arr[4], 5, "invalid last item");
        }
        [TestMethod]
        public void CopyEmptyListToArray()
        {
            var arr = new int[1];
            circularDoublyLinkedList.CopyTo(arr, 0);

            Assert.AreEqual(arr[0], 0, "invalid item");
        }
        [TestMethod]
        public void CheckLastItemFromEmptyList()
        {
            var item = circularDoublyLinkedList.GetLast();

            Assert.AreEqual(item, 0, "invalid item");
        }

        [TestMethod]
        public void RemoveFromEmptyList()
        {
            circularDoublyLinkedList.Remove(5);
            Assert.AreEqual(circularDoublyLinkedList.Count(), 0, "invalid item");
        }

        [TestMethod]
        public void AddNullItem()
        {
            var list = new CircularDoublyLinkedList<string>();
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

        [TestMethod]
        public void RemovedFirst()
        {
            for (int i = 1; i <= 1000; i++)
                circularDoublyLinkedList.AddFirst(i);

            circularDoublyLinkedList.RemoveFirst();

            Assert.AreEqual(circularDoublyLinkedList.Count(), 999, "invalid count");
            Assert.AreEqual(circularDoublyLinkedList.GetFirst(), 999, "invalid head element");
            Assert.AreEqual(circularDoublyLinkedList.GetLast(), 1, "invalid tail element");

        }

        [TestMethod]
        public void RemovedLast()
        {
            for (int i = 1; i <= 1000; i++)
                circularDoublyLinkedList.AddLast(i);

            circularDoublyLinkedList.RemoveLast();

            Assert.AreEqual(circularDoublyLinkedList.Count(), 999, "invalid count");
            Assert.AreEqual(circularDoublyLinkedList.GetFirst(), 1, "invalid head element");
            Assert.AreEqual(circularDoublyLinkedList.GetLast(), 999, "invalid tail element");

        }

        [TestMethod]
        public void RemoveFirstItemOnly()
        {
            circularDoublyLinkedList.AddFirst(1);

            circularDoublyLinkedList.RemoveFirst();

            Assert.AreEqual(circularDoublyLinkedList.Count(), 0, "invalid count");
            Assert.AreEqual(circularDoublyLinkedList.GetLast(), 0, "invalid tail element");
            Assert.IsFalse(circularDoublyLinkedList.Contains(1), "invalid list");

        }
        [TestMethod]
        public void RemoveLastItemOnly()
        {
            circularDoublyLinkedList.AddLast(1);

            circularDoublyLinkedList.RemoveLast();

            Assert.AreEqual(circularDoublyLinkedList.Count(), 0, "invalid count");
            Assert.AreEqual(circularDoublyLinkedList.GetLast(), 0, "invalid tail element");
            Assert.IsFalse(circularDoublyLinkedList.Contains(1), "invalid list");

        }

        [TestMethod]
        public void RemoveFromSingleItemList()
        {
            circularDoublyLinkedList.AddFirst(1);
            circularDoublyLinkedList.Remove(1);
            Assert.AreEqual(circularDoublyLinkedList.Count(), 0, "invalid item");
            Assert.IsFalse(circularDoublyLinkedList.Contains(1), "Item exists.");
        }

        [TestMethod]
        public void RemoveOnlyOneItem()
        {
            for (int i = 1; i <= 5; i++)
                circularDoublyLinkedList.AddLast(i);

            circularDoublyLinkedList.Remove(5);

            Assert.AreEqual(circularDoublyLinkedList.Count(), 4, "invalid count");
            Assert.AreEqual(circularDoublyLinkedList.GetLast(), 4, "invalid tail element");

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
                circularDoublyLinkedList.AddLast(i);

            circularDoublyLinkedList.Remove(item);

            if (item != 7)
                Assert.AreEqual(circularDoublyLinkedList.Count(), 4, "invalid count");
            else
                Assert.AreEqual(circularDoublyLinkedList.Count(), 5, "invalid count");

            Assert.IsFalse(circularDoublyLinkedList.Contains(item), "invalid list");

        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.circularDoublyLinkedList = null;
        }

    }

    public class CircularDoublyLinkedListDataSourceAttribute : Attribute, ITestDataSource
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
