# OOP Pillars

## A PIE
Abstraction, Polymorphism, Inheritance, Encapsulation

## Abstraction
hiding the complex implementation detail and providing the user with a simple interface to use.

### Interface
Contract between the class that implements the interface and the user that uses the class.
All methods in interface are implicitly public and abstract (which means they lack the implementation detail or method body)
Any class that implements the interface, must provide implementation detail for all interface members.
Doesn't have constructors

### Abstract Class
Abstract is a non access modifier that signals that the method lacks body or implementation detail.
Abstract class is a class that has abstract non-access modifier, and they cannot be instantiated and is meant to be inherited and implemented. When a class inherits an abstract class, it must provide implementation details for abstract class members.
Class can only inherit from one class, but can implement multiple interfaces.

## Polymorphism
Stands for many forms, it is the ability of an object to take many forms.

### Method Overloading
Method Overloading is the ability of a method to behave differently depending on the parameters being passed to it. (Ex. Console.WriteLine )

### Method Overriding
A child class can override inherited parent's method to its own behavior. The parent's method that can be overridden must have "virtual" non access modifier and the child's overriding method must contain the "override" non-access modifier. 

### Generics
Also a type of polymorphism, because generic classes can act the same regardless of what kind of type <T> is being passed to it.

## Inheritance
Is the ability for a class to inherit another class's methods and properties. Promotes code reusability

## Encapsulation
### Data Hiding
Uses access modifiers hide data, or make it unreachable by unintended users.

### Data Wrapping
Is a way of bundling the related data and its behavior together into one unit. IE using class to bundle together related information