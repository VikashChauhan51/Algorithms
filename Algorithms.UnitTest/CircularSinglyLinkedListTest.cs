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
    public class CircularSinglyLinkedListTest
    {
        public TestContext TestContext { get; set; }
        private static TestContext testContext;

        private CircularSinglyLinkedList<int> circularSinglyLinkedList;

        public CircularSinglyLinkedListTest()
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


            this.circularSinglyLinkedList = new CircularSinglyLinkedList<int>();
        }


        [TestMethod]
        public void AddFirstNode()
        {
            circularSinglyLinkedList.AddFirst(1);
            Assert.IsNotNull(circularSinglyLinkedList.GetFirst(), "Linked List is empty");
        }
        [TestMethod]
        public void AddTwoNodesHead()
        {
            circularSinglyLinkedList.AddFirst(1);
            circularSinglyLinkedList.AddFirst(2);
            Assert.AreEqual(circularSinglyLinkedList.GetFirst(), 2, "invalid head element");
            Assert.AreEqual(circularSinglyLinkedList.GetLast(), 1, "invalid tail element");
        }
          
        [TestMethod]
        public void AddFiveNodesHead()
        {
            for (int i = 1; i <= 5; i++)
                circularSinglyLinkedList.AddFirst(i);

            Assert.AreEqual(circularSinglyLinkedList.GetFirst(), 5, "invalid head element");
            Assert.AreEqual(circularSinglyLinkedList.GetLast(), 1, "invalid tail element");
            Assert.AreEqual(circularSinglyLinkedList.Count(), 5, "invalid count");
        }

        [TestMethod]
        public void AddTwoNodesToTail()
        {

            circularSinglyLinkedList.AddLast(1);
            circularSinglyLinkedList.AddLast(2);
            Assert.AreEqual(circularSinglyLinkedList.GetFirst(), 1, "invalid head element");
            Assert.AreEqual(circularSinglyLinkedList.GetLast(), 2, "invalid tail element");
        }


        [TestMethod]
        public void AddFiveNodesToTail()
        {
            for (int i = 1; i <= 5; i++)
                circularSinglyLinkedList.AddLast(i);

            Assert.AreEqual(circularSinglyLinkedList.GetFirst(), 1, "invalid head element");
            Assert.AreEqual(circularSinglyLinkedList.GetLast(), 5, "invalid tail element");
            Assert.AreEqual(circularSinglyLinkedList.Count(), 5, "invalid count");
        }
        [DataTestMethod]
        [CircularLinkedListDataSourceAttribute]
        public void VerifyAddNodesHead(int item)
        {
            circularSinglyLinkedList.AddFirst(item);

            Assert.AreEqual(circularSinglyLinkedList.GetFirst(), item, "invalid head element");


        }
        [DataTestMethod]
        [CircularLinkedListDataSourceAttribute]
        public void VerifyAddNodesToTail(int item)
        {
            circularSinglyLinkedList.AddLast(item);

            Assert.AreEqual(circularSinglyLinkedList.GetLast(), item, "invalid tail element");

        }

        [TestMethod]
        public void VerifyAddNodesHeadTime()
        {
            for (int i = 1; i <= 1000; i++)
                circularSinglyLinkedList.AddFirst(i);

            Assert.AreEqual(circularSinglyLinkedList.GetFirst(), 1000, "invalid head element");
            Assert.AreEqual(circularSinglyLinkedList.GetLast(), 1, "invalid tail element");
            Assert.AreEqual(circularSinglyLinkedList.Count(), 1000, "invalid count");
        }

        [TestMethod]
        public void VerifyAddNodesToTailTime()
        {
            for (int i = 1; i <= 1000; i++)
                circularSinglyLinkedList.AddLast(i);

            Assert.AreEqual(circularSinglyLinkedList.GetFirst(), 1, "invalid head element");
            Assert.AreEqual(circularSinglyLinkedList.GetLast(), 1000, "invalid tail element");
            Assert.AreEqual(circularSinglyLinkedList.Count(), 1000, "invalid count");
        }
        [TestMethod]
        public void AddBulkNodes()
        {
            List<int> source = new List<int>();
            for (int i = 1; i <= 1000; i++)
                source.Add(i);

            var list = new CircularSinglyLinkedList<int>(source);

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
                    circularSinglyLinkedList.AddFirst(i);
                else
                    circularSinglyLinkedList.AddLast(i);

            foreach (var item in circularSinglyLinkedList.Get())
                j++;

            Assert.AreEqual(j, 5, "invalid count");
        }

        [TestMethod]
        public void RemovedFirst()
        {
            for (int i = 1; i <= 1000; i++)
                circularSinglyLinkedList.AddFirst(i);

            circularSinglyLinkedList.RemoveFirst();

            Assert.AreEqual(circularSinglyLinkedList.Count(), 999, "invalid count");
            Assert.AreEqual(circularSinglyLinkedList.GetFirst(), 999, "invalid head element");
            Assert.AreEqual(circularSinglyLinkedList.GetLast(), 1, "invalid tail element");

        }

        [TestMethod]
        public void RemovedLast()
        {
            for (int i = 1; i <= 1000; i++)
                circularSinglyLinkedList.AddLast(i);

            circularSinglyLinkedList.RemoveLast();

            Assert.AreEqual(circularSinglyLinkedList.Count(), 999, "invalid count");
            Assert.AreEqual(circularSinglyLinkedList.GetFirst(), 1, "invalid head element");
            Assert.AreEqual(circularSinglyLinkedList.GetLast(), 999, "invalid tail element");

        }

        [TestMethod]
        public void RemoveFirstItemOnly()
        {
            circularSinglyLinkedList.AddFirst(1);

            circularSinglyLinkedList.RemoveFirst();

            Assert.AreEqual(circularSinglyLinkedList.Count(), 0, "invalid count");
            Assert.AreEqual(circularSinglyLinkedList.GetLast(), 0, "invalid tail element");
            Assert.IsFalse(circularSinglyLinkedList.Contains(1), "invalid list");

        }
        [TestMethod]
        public void RemoveLastItemOnly()
        {
            circularSinglyLinkedList.AddLast(1);

            circularSinglyLinkedList.RemoveLast();

            Assert.AreEqual(circularSinglyLinkedList.Count(), 0, "invalid count");
            Assert.AreEqual(circularSinglyLinkedList.GetLast(), 0, "invalid tail element");
            Assert.IsFalse(circularSinglyLinkedList.Contains(1), "invalid list");

        }

        [TestMethod]
        public void RemoveFromSingleItemList()
        {
            circularSinglyLinkedList.AddFirst(1);
            circularSinglyLinkedList.Remove(1);
            Assert.AreEqual(circularSinglyLinkedList.Count(), 0, "invalid item");
            Assert.IsFalse(circularSinglyLinkedList.Contains(1), "Item exists.");
        }

        [TestMethod]
        public void RemoveOnlyOneItem()
        {
            for (int i = 1; i <= 5; i++)
                circularSinglyLinkedList.AddLast(i);

            circularSinglyLinkedList.Remove(5);

            Assert.AreEqual(circularSinglyLinkedList.Count(), 4, "invalid count");
            Assert.AreEqual(circularSinglyLinkedList.GetLast(), 4, "invalid tail element");

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
                circularSinglyLinkedList.AddLast(i);

            circularSinglyLinkedList.Remove(item);

            if (item != 7)
                Assert.AreEqual(circularSinglyLinkedList.Count(), 4, "invalid count");
            else
                Assert.AreEqual(circularSinglyLinkedList.Count(), 5, "invalid count");

            Assert.IsFalse(circularSinglyLinkedList.Contains(item), "invalid list");

        }

        [TestMethod]
        [DataRow(1, 7)]
        [DataRow(3, 7)]
        [DataRow(5, 7)]
        public void AddAfter(int oldItem, int item)
        {
            for (int i = 1; i <= 5; i++)
                circularSinglyLinkedList.AddLast(i);

            circularSinglyLinkedList.AddAfter(oldItem, item);

            Assert.AreEqual(circularSinglyLinkedList.Count(), 6, "invalid count");
            Assert.IsTrue(circularSinglyLinkedList.Contains(item), "Item doesn't exists.");
        }
        [TestMethod]
        [DataRow(1, 7)]
        [DataRow(3, 7)]
        [DataRow(5, 7)]
        public void AddBefore(int oldItem, int item)
        {
            for (int i = 1; i <= 5; i++)
                circularSinglyLinkedList.AddLast(i);

            circularSinglyLinkedList.AddBefore(oldItem, item);

            Assert.AreEqual(circularSinglyLinkedList.Count(), 6, "invalid count");
            Assert.IsTrue(circularSinglyLinkedList.Contains(item), "Item doesn't exists.");
        }

        [TestMethod]
        public void AddBeforeInSingleItemList()
        {
            circularSinglyLinkedList.AddFirst(1);
            circularSinglyLinkedList.AddBefore(1, 4);

            Assert.AreEqual(circularSinglyLinkedList.Count(), 2, "invalid count");
            Assert.IsTrue(circularSinglyLinkedList.Contains(4), "Item doesn't exists.");
        }

        [TestMethod]
        public void AddAfterInSingleItemList()
        {
            circularSinglyLinkedList.AddLast(1);
            circularSinglyLinkedList.AddAfter(1, 4);

            Assert.AreEqual(circularSinglyLinkedList.Count(), 2, "invalid count");
            Assert.IsTrue(circularSinglyLinkedList.Contains(4), "Item doesn't exists.");
        }

        [TestMethod]
        public void AddBeforeInEmptyList()
        {
            circularSinglyLinkedList.AddBefore(2, 4);

            Assert.AreEqual(circularSinglyLinkedList.Count(), 0, "invalid count");
            Assert.IsFalse(circularSinglyLinkedList.Contains(4), "Item exists.");
        }

        [TestMethod]
        public void AddAfterInEmptyList()
        {
            circularSinglyLinkedList.AddAfter(2, 4);

            Assert.AreEqual(circularSinglyLinkedList.Count(), 0, "invalid count");
            Assert.IsFalse(circularSinglyLinkedList.Contains(4), "Item exists.");
        }

        [TestMethod]
        public void AddNullItem()
        {
            var list = new SinglyLinkedList<string>();
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
        public void CheckListEmpty()
        {
            int j = 0;
            foreach (var item in circularSinglyLinkedList.Get())
                j++;

            Assert.AreEqual(0, j, "Invalid count.");
            Assert.IsFalse(circularSinglyLinkedList.Contains(2), "list contains some item(s)");
        }
        [TestMethod]
        public void CheckListLastItem()
        {
            for (int i = 1; i <= 5; i++)
                circularSinglyLinkedList.AddLast(i);

            Assert.AreEqual(circularSinglyLinkedList.GetLast(), 5, "invalid tail element");
            Assert.IsTrue(circularSinglyLinkedList.Contains(5), "list doesn't contains element");

        }
        [TestMethod]
        public void CopyToArray()
        {
            var arr = new int[5];
            for (int i = 1; i <= 5; i++)
                circularSinglyLinkedList.AddLast(i);

            circularSinglyLinkedList.CopyTo(arr, 0);
            Assert.AreEqual(arr[0], 1, "invalid first item");
            Assert.AreEqual(arr[4], 5, "invalid last item");
        }
        [TestMethod]
        public void CopyEmptyListToArray()
        {
            var arr = new int[1];
            circularSinglyLinkedList.CopyTo(arr, 0);

            Assert.AreEqual(arr[0], 0, "invalid item");
        }

        [TestMethod]
        public void RemoveFromEmptyList()
        {
            circularSinglyLinkedList.Remove(5);
            Assert.AreEqual(circularSinglyLinkedList.Count(), 0, "invalid item");
        }

        [TestMethod]
        public void CheckLastItemFromEmptyList()
        {
            var item = circularSinglyLinkedList.GetLast();

            Assert.AreEqual(item, 0, "invalid item");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.circularSinglyLinkedList = null;
        }
    }

    public class CircularLinkedListDataSourceAttribute : Attribute, ITestDataSource
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
