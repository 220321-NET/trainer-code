# Triggers, Indexes, Cascading, and Stored Procedure

## Trigger
responds to different DML commands such as INSERT, DELETE, UPDATE on a particular table to execute certain functions

## Cascading
responds to UPDATE/DELETE to also UPDATE/DELETE the related records
EX. If I want to delete all answers associated to the question when I delete a question then I can say so during table creation

## Stored Procedures
Is a named collection of SQL Statements that are stored in DB that can be used over and over again.

## Index
[index](https://dataschool.com/sql-optimization/how-indexing-works/)
Index is a structure that allows SQL to quickly find a record
Two Types: Clustered and non-clustered
CREATE INDEX index_name ON Table(column)
-> This creates an index that will sort by the column on the table