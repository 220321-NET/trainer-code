# ORM
Object Relational Mapper is a tool that enables developers to access different datasource in uniform fashion, regardless of where the data is coming from.

In .NET, Entity Framework Core is our ORM. Other examples of ORM are Hibernate for java.

Not only we can do DML stuff with EFCore, EFCore is also capable of DDL, translating between the DB tables and our model object.
Two ways to achieve this:
    - code first
        - Takes model classes in your program, and then translates to db tables
        - migrations
        - DB snapshots
    - DB first (or reverse engineering)
        - scaffolding

## Artifacts
- DBContext
- connection string
- migrations
- db snapshots