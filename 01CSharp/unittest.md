# Unit Testing

## Why do we test?
We test to ensure there are no unexpected errors or behaviors (aka bugs) in the program
" Errors may come up that we have not thought of before. Coming from game design, there are ways that people can create issues in your "flawless" program" - Tucker Fabin

## Different Types of Testing
### Manual Testing
- a human being manually goes through the workflow in the program to ensure that the program functions as intended
- Pros: you're on-site to fix the bug, real time errors and solutions, people would be able to find logic errors that the machine can't, intuitive
- Cons: Cost, Labor, and time intensive, repetitive, human errors, sanity of the workers.

### Automated Testing
Automated testing is programmatically writing the tests and making the computer run those tests. And this saves on time and resources, also help prevent breaking existing features when we introduce new features. (which unfortunately is rather common)

#### Unit Testing
- Unit Tests focuses on testing isolated unit of code. In C#, we are going to use xUnit testing framework. 3 steps to write unit tests. AAA: Arrange, Act, Assert
Arrange: We 'arrange' all our artifacts that we need to be able to execute our action that we want to test
Act: We 'act' or trigger the behavior or call that method that we're trying to test
Assert: we 'assert' that the outcome is the same as the expected behavior 

#### Integration Testing

#### End to End Testing