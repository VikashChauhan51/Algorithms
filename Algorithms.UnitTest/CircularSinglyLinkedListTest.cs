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
