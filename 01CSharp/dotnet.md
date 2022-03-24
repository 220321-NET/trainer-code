# .NET / C#

## SDK
- Software Development Kit, includes everything you need to write, compile and run .NET programs, such as compiler, run time, and base class libraries

## CLR
Common Language Runtime, includes tools needed to run compiled .NET programs, includes features such as garbage collection, JIT compilation, and exception handling.

### Garbage Collection
One of CLR's features, CLR automatically looks through the memory and unallocates objects that are no longer being referenced. This in turn frees up the memory to be used by other objects in your program.

## Commands
- `dotnet new console -n <insert-name-here>`
    - new console project with the name you gave
- `dotnet new classlib -n <insert-name-here>`
    - creates a new class library projects with the given name
- `dotnet new gitignore`
    - Creates new gitignore file that ignores common files and folders .NET platform applications ignore
- `dotnet restore`
    - Restores all project dependencies
- `dotnet build`
    - restores, and then compiles the project(s)
- `dotnet run`
    - runs the project

## Moving Parts of C# Program
- Program.cs: This is the main entry point of the program. When we run our program, this is the place run time will start executing commands.
- *.csproj: This file denotes that this folder is a C# project. This file also holds configuration for the particular project, such as which framework are you using. We can also turn on and off certain features here as well as declare project dependencies and references to other projects
- *.cs: These are C# files
- namespace: is a logical grouping of code (for us to logically group related types and classes together) Akin to java's package.
- assembly: is a physical grouping of code (think dll, exe)
- project: is what we call basic executable unit of code (it's the folder that has .csproj file)
- solution: is a grouping of project (.sln)

## Compilation Process
- MSBuild - looks into project dependencies and figures out project build order
- Language specific compiler - compiles our .cs files to IL (Intermediate Language)
- CLR (Common language runtime) (when we do 'dotnet run'): takes the IL code, and then Just-In-Time compiles to native code
- this is what allows for write-once-run-anywhere
- This also helps with language interoperability - this just means, your solution can have different projects that are written in different .NET compliant languages (such as C#, F#, VB.NET)

## .NET Standard
this a set of standard that all .NET compliant languages such as C#, F#, VB.NET must comply to. Another tool that allows for language interoperability

## CTS: Common Type System
Is a spec sheet for types that all .NET compliant languages have to make it available. (such as INT32, INT64, BOOLEAN, DOUBLE, etc.)

## Reference vs Value Types in C#
Reference types are stored in heap memory. And in the stack, instead of the actual value of the type, we store the memory address to the variable in the heap
Examples of reference types are string, class, array, collections.
Value types are stored directly in stack. (ex. int, bool, char, double, decimal)

## Collections
Are... collection of objects or data structures. 
Two Types: Generic, Non Generic
Generic Collections are collections that are type-safe: List<T>, Dictionary<TKey, TValue>, Stack<T>, Queue<T>
Non-Generic Collections can have multiple types in one collection. Because in non-generic collection, we wrap everything with object. ArrayList, Stack, Queue, etc.

## Boxing and Unboxing
is a type of type conversion
* boxing is casting a type into object 
* unboxing is going the other way

## Implicit/Explicit Type Casting
* Going from narrower type to broader type (such as int -> double), the type is casted implicitly
    * ```csharp
        int n = 10;
        double m = n; 
    ```
* Going from broader type to narrower type (such as double -> int), we need to be explicit about it, because it can result in data loss
    * ```csharp
        double m = 10.45;
        int n = (int) m;
    ```

## Variance (Covariance, Contravariance, Invariance)