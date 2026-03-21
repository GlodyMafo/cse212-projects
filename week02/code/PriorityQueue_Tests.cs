using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Dequeue should return the item with the highest priority
    // Expected Result: The item with the highest priority is returned
    // Defect(s) Found: None if code correct, otherwise wrong item returned
    public void TestPriorityQueue_HighestPriority()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 3);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("B", result);
    }

    [TestMethod]
    // Scenario: Dequeue items with same priority follow FIFO
    // Expected Result: Among items with same priority, the one enqueued first is returned
    // Defect(s) Found: None if code correct, otherwise wrong order
    public void TestPriorityQueue_FIFOWithSamePriority()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 5);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 5);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("A", result);

        // Next dequeue should return the next in FIFO order
        result = priorityQueue.Dequeue();
        Assert.AreEqual("B", result);
    }

    [TestMethod]
    // Scenario: Dequeue on empty queue throws exception
    // Expected Result: InvalidOperationException is thrown with message "The queue is empty."
    // Defect(s) Found: None if code correct, otherwise wrong exception
    public void TestPriorityQueue_EmptyQueueThrows()
    {
        var priorityQueue = new PriorityQueue();

        var ex = Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
        Assert.AreEqual("The queue is empty.", ex.Message);
    }

    // Optional: add more tests to cover multiple mixed priorities
    [TestMethod]
    // Scenario: Dequeue multiple times returns items in correct priority order
    // Expected Result: Items returned in descending priority; FIFO when equal
    // Defect(s) Found: None if code correct
    public void TestPriorityQueue_MultipleDequeues()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 5);
        priorityQueue.Enqueue("D", 1);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("B", result); // highest priority, FIFO first

        result = priorityQueue.Dequeue();
        Assert.AreEqual("C", result); // next highest priority

        result = priorityQueue.Dequeue();
        Assert.AreEqual("A", result); // next highest

        result = priorityQueue.Dequeue();
        Assert.AreEqual("D", result); // last one

        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }
}