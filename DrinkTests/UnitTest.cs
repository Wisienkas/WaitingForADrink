using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WaitingForADrink;

namespace DrinkTests
{
    [TestClass]
    public class UnitTest
    {
        Queue<String> queue;

        [TestInitialize]
        public void Init()
        {
            queue = new Queue<String>();
        }

        [TestMethod]
        public void TestIsEmpty()
        {
            Assert.AreEqual(true, queue.isEmpty());
        }

        [TestMethod]
        public void TestInput()
        {
            // Setup
            String input = "test input";
            // Operate
            queue.add(input);
            // Validate
            Assert.AreEqual(false, queue.isEmpty());
        }

        [TestMethod]
        public void TestInputOutputSame()
        {
            // Setup
            String input = "test input";
            // Operate
            queue.add(input);
            String output = queue.poll();
            // Validate
            Assert.AreEqual(output, input);
        }

        [TestMethod]
        public void TestInputOutputEmpty()
        {
            // Setup
            String input = "test input";
            // Operate
            queue.add(input);
            queue.poll();
            // Validate
            Assert.AreEqual(true, queue.isEmpty());
        }

        [TestMethod, ExpectedException(typeof(InvalidOperationException))]
        public void TestEmptyQueue()
        {
            // Setup
            String input = "test input";
            // Operate
            queue.add(input);
            queue.poll();
            queue.poll();
            // Validate
            Assert.AreEqual(true, queue.isEmpty());
        }

        [TestMethod]
        public void TestOrder()
        {
            for (int i = 0; i < 10; i++)
                queue.add("" + i);

            for (int i = 0; i < 10; i++)
                Assert.AreEqual("" + i, queue.poll());
        }

        [TestMethod]
        public void TestFillEmptyFillEmpty1()
        {
            // Fill
            for (int i = 0; i < 10; i++)
                queue.add("" + i);
            // Empty
            for (int i = 0; i < 10; i++)
                queue.poll();

            // Sanity
            Assert.AreEqual(true, queue.isEmpty());

            // Fill
            for (int i = 0; i < 10; i++)
                queue.add("" + i);

            // Empty
            for (int i = 0; i < 10; i++)
                queue.poll();

            Assert.AreEqual(true, queue.isEmpty());
        }

        [TestMethod]
        public void TestFillEmptyFillEmpty2()
        {
            // Fill
            for (int i = 0; i < 10; i++)
                queue.add("" + i);
            // Empty
            for (int i = 0; i < 10; i++)
                Assert.AreEqual("" + i, queue.poll());

            // Fill
            for (int i = 0; i < 10; i++)
                queue.add("" + i);

            // Empty
            for (int i = 0; i < 10; i++)
                Assert.AreEqual("" + i, queue.poll());
        }
    }
}
