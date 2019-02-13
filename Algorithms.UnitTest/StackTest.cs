using DataStructures.Stack;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.UnitTest
{
    [TestClass]
    public class StackTest
    {
        ArrayStack<int> arrayStack;
        LinkedListStack<int> linkedListStack;
        [TestInitialize]
        public void TestInitialize()
        {
            this.linkedListStack = new LinkedListStack<int>();
            this.arrayStack = new ArrayStack<int>();
        }
        [TestMethod]
        public void AddFiveItemsAndVerify()
        {
            int linkedListStackLast = 0;
            int arrayStackLast = 0;
            for (int i = 1; i <= 5; i++)
            {
                linkedListStack.Push(i);
                arrayStack.Push(i);
            }

            Assert.AreEqual(linkedListStack.Peek(), 5, "invalid top element");
            Assert.AreEqual(linkedListStack.Count, 5, "invalid count");

            Assert.AreEqual(arrayStack.Peek(), 5, "invalid top element");
            Assert.AreEqual(arrayStack.Count, 5, "invalid count");

            while (linkedListStack.Count > 0)
            {
                linkedListStackLast = linkedListStack.Pop();
                arrayStackLast = arrayStack.Pop();
            }
            Assert.AreEqual(linkedListStackLast, 1, "invalid last element");
            Assert.AreEqual(arrayStackLast, 1, "invalid last element");
        }

        [TestMethod]
        public void AddFiveItemsCopyToArray()
        {
            var linkedListStackArray = new int[5];
            var arrayStackArray = new int[5];
            int linkedListStackLast = 0;
            int arrayStackLast = 0;

            for (int i = 1; i <= 5; i++)
            {
                linkedListStack.Push(i);
                arrayStack.Push(i);
            }
            foreach (var item in linkedListStack.Get())
                linkedListStackLast = item;

            foreach (var item in arrayStack.Get())
                arrayStackLast = item;

            linkedListStack.CopyTo(linkedListStackArray, 0);
            arrayStack.CopyTo(arrayStackArray, 0);

            Assert.AreEqual(linkedListStackLast, 1, "invalid last element");
            Assert.AreEqual(arrayStackLast, 1, "invalid last element");

            Assert.AreEqual(linkedListStackArray[0], 5, "invalid element");
            Assert.AreEqual(arrayStackArray[0], 5, "invalid element");

            Assert.AreEqual(linkedListStackArray[4], 1, "invalid element");
            Assert.AreEqual(arrayStackArray[4], 1, "invalid element");


        }


    }
}
