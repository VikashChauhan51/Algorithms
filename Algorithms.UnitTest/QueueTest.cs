using DataStructures.Queue;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.UnitTest
{
    [TestClass]
    public  class QueueTest
    {
        ArrayQueue<int> arrayQueue;
        LinkedListQueue<int> linkedListQueue;

        [TestInitialize]
        public void TestInitialize()
        {
            this.linkedListQueue = new LinkedListQueue<int>();
            this.arrayQueue = new ArrayQueue<int>();
        }
        [TestMethod]
        public void AddFiveItemsAndVerify()
        {
            int linkedListQueueLast = 0;
            int arrayQueueLast = 0;
            for (int i = 1; i <= 5; i++)
            {
                linkedListQueue.Enqueue(i);
                arrayQueue.Enqueue(i);
            }

            Assert.AreEqual(linkedListQueue.Peek(), 1, "invalid top element");
            Assert.AreEqual(linkedListQueue.Count, 5, "invalid count");

            Assert.AreEqual(arrayQueue.Peek(), 1, "invalid top element");
            Assert.AreEqual(arrayQueue.Count, 5, "invalid count");

            while (linkedListQueue.Count > 0)
            {
                linkedListQueueLast = linkedListQueue.Dequeue();
                arrayQueueLast = arrayQueue.Dequeue();
            }
            Assert.AreEqual(linkedListQueueLast, 5, "invalid last element");
            Assert.AreEqual(arrayQueueLast, 5, "invalid last element");
        }

        [TestMethod]
        public void AddFiveItemsCopyToArray()
        {
            var linkedListQueueArray = new int[5];
            var arrayQueueArray = new int[5];
            int linkedListQueueLast = 0;
            int arrayQueueLast = 0;

            for (int i = 1; i <= 5; i++)
            {
                linkedListQueue.Enqueue(i);
                arrayQueue.Enqueue(i);
            }
            foreach (var item in linkedListQueue.Get())
                linkedListQueueLast = item;

            foreach (var item in arrayQueue.Get())
                arrayQueueLast = item;

            linkedListQueue.CopyTo(linkedListQueueArray, 0);
            arrayQueue.CopyTo(arrayQueueArray, 0);

            Assert.AreEqual(linkedListQueueLast, 5, "invalid last element");
            Assert.AreEqual(arrayQueueLast, 5, "invalid last element");

            Assert.AreEqual(linkedListQueueArray[0], 1, "invalid element");
            Assert.AreEqual(arrayQueueArray[0], 1, "invalid element");

            Assert.AreEqual(linkedListQueueArray[4], 5, "invalid element");
            Assert.AreEqual(arrayQueueArray[4], 5, "invalid element");


        }
    }
}
