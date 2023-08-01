using QueueStack;

MyQueue<int> myQueue = new MyQueue<int>(2);
myQueue.Enqueue(1); 
myQueue.Enqueue(2);

myQueue.Dequeue();

Console.ReadLine();
