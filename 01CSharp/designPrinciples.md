# Design Principles

## Separation of Concerns
- Helps with error handling
- organizes code
- allows reusability of code
- Easier to understand
- uses layered architecture such as UI/BL/DL, etc.
- It can be achieved using encapsulation
- ** One file is not in charge of handling everything 
- is like separating methods and classes so not everything is in one place
- avoid spaghetti code, instead construct lasagna
- helps with unit testing, readability of code, extendibility, etc.

## DRY Principle VS WET
**D**on't **R**epeat **Y**ourself
WET: Write Every Twice or We Enjoy Typing

## KISS
**K**eep **i**t **s**imple **s**tupid

## SOLID Principles
- **S**ingle Responsibility: A class should only be responsible for one thing and one thing only
- **O**pen Close: A class should be Open for extension and Closed for modification
- **L**iskov Substitution Principle: Any derived classes should be able to replace its base class
- **I**nterface Segregation: Interface should be kept lean such that any class that implements that interface doesn't have to implement methods that it doesn't need.
- **D**ependency Inversion: Concrete implementation should come from abstract definition. 