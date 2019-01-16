﻿using System;
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
            Assert.IsNotNull(singlyLinkedList.First(), "Linked List is empty");
        }
        [TestMethod]
        public void AddTwoNodesHead()
        {
            singlyLinkedList.AddFirst(1);
            singlyLinkedList.AddFirst(2);
            Assert.AreEqual(singlyLinkedList.First(), 2, "invalid head element");
            Assert.AreEqual(singlyLinkedList.Last(), 1, "invalid tail element");
        }
        [TestMethod]
        public void AddTwoNodesToTail()
        {

            singlyLinkedList.AddLast(1);
            singlyLinkedList.AddLast(2);
            Assert.AreEqual(singlyLinkedList.First(), 1, "invalid head element");
            Assert.AreEqual(singlyLinkedList.Last(), 2, "invalid tail element");
        }
        [TestMethod]
        public void AddFiveNodesHead()
        {
            for (int i = 1; i <= 5; i++)
                singlyLinkedList.AddFirst(i);

            Assert.AreEqual(singlyLinkedList.First(), 5, "invalid head element");
            Assert.AreEqual(singlyLinkedList.Last(), 1, "invalid tail element");
            Assert.AreEqual(singlyLinkedList.Count(), 5, "invalid count");
        }
        [TestMethod]
        public void AddFiveNodesToTail()
        {
            for (int i = 1; i <= 5; i++)
                singlyLinkedList.AddLast(i);

            Assert.AreEqual(singlyLinkedList.First(), 1, "invalid head element");
            Assert.AreEqual(singlyLinkedList.Last(), 5, "invalid tail element");
            Assert.AreEqual(singlyLinkedList.Count(), 5, "invalid count");
        }
        [DataTestMethod]
        [SinglyLinkedListDataSource]
        public void VerifyAddNodesHead(int item)
        {
            singlyLinkedList.AddFirst(item);

            Assert.AreEqual(singlyLinkedList.First(), item, "invalid head element");


        }
        [DataTestMethod]
        [SinglyLinkedListDataSource]
        public void VerifyAddNodesToTail(int item)
        {
            singlyLinkedList.AddLast(item);

            Assert.AreEqual(singlyLinkedList.Last(), item, "invalid tail element");

        }

        [TestMethod]
        public void VerifyAddNodesHeadTime()
        {
            for (int i = 1; i <= 1000; i++)
                singlyLinkedList.AddFirst(i);

            Assert.AreEqual(singlyLinkedList.First(), 1000, "invalid head element");
            Assert.AreEqual(singlyLinkedList.Last(), 1, "invalid tail element");
            Assert.AreEqual(singlyLinkedList.Count(), 1000, "invalid count");
        }

        [TestMethod]
        public void VerifyAddNodesToTailTime()
        {
            for (int i = 1; i <= 1000; i++)
                singlyLinkedList.AddLast(i);

            Assert.AreEqual(singlyLinkedList.First(), 1, "invalid head element");
            Assert.AreEqual(singlyLinkedList.Last(), 1000, "invalid tail element");
            Assert.AreEqual(singlyLinkedList.Count(), 1000, "invalid count");
        }
        [TestMethod]
        public void AddBulkNodes()
        {
            List<int> source = new List<int>();
            for (int i = 1; i <= 1000; i++)
                source.Add(i);

            var list = new SinglyLinkedList<int>(source);

            Assert.AreEqual(list.First(), 1000, "invalid head element");
            Assert.AreEqual(list.Last(), 1, "invalid tail element");
            Assert.AreEqual(list.Count(), 1000, "invalid count");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Null collection doesn't allow.")]
        public void AddNullCollection()
        {
            var list = new SinglyLinkedList<int>(null);
        }

        [TestMethod]
        public void GetListItems()
        {
            int j = 0;
            for (int i = 1; i <= 5; i++)
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
            Assert.AreEqual(singlyLinkedList.Last(), 4, "invalid tail element");

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
            Assert.AreEqual(singlyLinkedList.First(), 999, "invalid head element");
            Assert.AreEqual(singlyLinkedList.Last(), 1, "invalid tail element");

        }

        [TestMethod]
        public void RemovedLast()
        {
            for (int i = 1; i <= 1000; i++)
                singlyLinkedList.AddLast(i);

            singlyLinkedList.RemoveLast();

            Assert.AreEqual(singlyLinkedList.Count(), 999, "invalid count");
            Assert.AreEqual(singlyLinkedList.First(), 1, "invalid head element");
            Assert.AreEqual(singlyLinkedList.Last(), 999, "invalid tail element");

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

