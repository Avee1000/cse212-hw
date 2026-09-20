using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities (e.g., "A" [pri: 2], "B" [pri: 5], "C" [pri: 1], "D" [pri: 3])
    // Expected Result: Dequeue returns items in order of highest priority: "B", "D", "A", "C".
    // Defect(s) Found: The loop condition `index < _queue.Count - 1` missed the last item ("D"), and items were never removed from the queue after being dequeued.
    public void TestPriorityQueue_HighestPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 1);
        priorityQueue.Enqueue("D", 3);

        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("D", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items with duplicate highest priorities (e.g., "A" [pri: 3], "B" [pri: 5], "C" [pri: 5], "D" [pri: 2])
    // Expected Result: FIFO order is respected for ties; "B" is dequeued before "C".
    // Defect(s) Found: `_queue[index].Priority >= _queue[highPriorityIndex].Priority` used `>=` instead of `>`, causing the last duplicate high-priority item ("C") to be dequeued before "B".
    public void TestPriorityQueue_TieBreakerFIFO()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 3);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 5);
        priorityQueue.Enqueue("D", 2);

        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("D", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Attempt to Dequeue from an empty queue.
    // Expected Result: Throws InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: None. Exception throwing on an empty queue worked correctly.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(string.Format("Unexpected exception of type {0} caught: {1}", e.GetType(), e.Message));
        }
    }
}