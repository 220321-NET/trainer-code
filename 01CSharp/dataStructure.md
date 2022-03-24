# Data Structure - Array, Stack, and Queue

## Array
Array is a collection of objects that can be indexed with a fixed size.
It is stored as a contiguous block of memory.
It is very cheap to access the element with known location: O(1)
```csharp
int[] arr = new int[5];
```
- It keeps of Size
- It can also keep how many items are there
- It can access its members by its index
- Insert an element to array
- Delete an element from array

## Big O Notation
Big O measures time complexity of the algorithm in question, which means it "counts" how many instructions that the algorithm needs to complete. Big O is interested in the worst case scenario, what's the worst possible way that algorithm can run given n item in the data structure. 
- O(1)
- O(log n)
- O(n)
- O(n^2)
- O(n^3)

## Stack
Stack is a FILO (First In Last Out) or LIFO (Last In First Out) data structure.
"Don't queue your pancakes" - Chase Swick
- Push: we are adding the element to the top of the stack
- Pop: we are removing the element from the top of the stack
- Peek: Looks at the top element in the stack without removing
- Size

## Queue
Queue is a FIFO (First In First Out) data structure.
Examples of queue includes: any line, loading queue, being on hold over the phone
- enqueue: adding an element to the queue
- dequeue: getting the element from the queue
- Peek: same as stack's peek
- Size: same as stack's size