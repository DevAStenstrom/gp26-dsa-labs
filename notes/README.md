# Notes

This folder is optional.

Use it for your own:

* checkpoint-question answers;
* predictions;
* complexity notes;
* debugging notes;
* reflections.

You do not need to keep formal notes unless a lab specifically asks you to.




\[LAB02]



TASK1

push = adds the the variable to the top of the stack so if we added ABC then the they would be stacked with A at the bottom B in the middle C at the top

pop = removes the latest entry to from the stack so if we popped ABC then the remove order would be CBA



enqueue = queues each entry so if we added ABC then then the remove order would be ABC

dequeue = removes the first entry of the queue so if we have added ABC then the first one out would be A then B then C

the diffrence is the order you want to remove it in



TASK2

if Count == 3 the index would be 2 because arrays/list starts at index 0



TASK3

it removes the item at index 0
the remaining elements need to decrease their index by 1

if the queue contains 100'000 items and you remove 1 you need to go through the whole list which would be expensive



TASK4

i asked AI i asked \[explain why does public T Dequeue() not work with this test?

public void RingQueue\_WrapsAround()  

{  

&#x20;   var queue = new RingQueue<int>(3);  

&#x20;   queue.Enqueue(1); queue.Enqueue(2); queue.Enqueue(3);  

&#x20;   Assert.That(queue.Dequeue(), Is.EqualTo(1));  

&#x20;   Assert.That(queue.Dequeue(), Is.EqualTo(2));  

&#x20;   queue.Enqueue(4); queue.Enqueue(5);  

&#x20;   Assert.That(queue.Dequeue(), Is.EqualTo(3));  

&#x20;   Assert.That(queue.Dequeue(), Is.EqualTo(4));  

&#x20;   Assert.That(queue.Dequeue(), Is.EqualTo(5));  

} ] 



the AI answered \[The test is valid; the bug is in Dequeue()’s implementation. On the first dequeue, it reads 1 into obj and clears that slot, but then returns \_items\[\_count]—which is 3—instead of returning obj. So the first assertion already fails.

It also advances \_head using \_count rather than \_head, so the head position becomes incorrect as the queue changes size. It should return the saved item and advance from the current head:
T item = \_items\[\_head];

\_items\[\_head] = default;

\_head = (\_head + 1) % Capacity;

\_count--;

return item;
You’ll also need to throw InvalidOperationException when \_count == 0. Separately, Enqueue() should advance \_tail from \_tail, not \_count, for wrap-around to work reliably.]



TASK5

the list has to go through each index and does not to -1 them

it leaves empty indexes where they are and just reuses empty indexes

you have a set amount of indexes to work with while in lists you can add more

the structure behind the queue can be diffrent from how a real world queue looks like



TASK 6

it check with longer queue/dequeue sequence hold FIFO behaviour and filling the capacity to max

