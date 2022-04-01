-- JOINS --
-- We JOIN columns from different tables --
-- join makes a temporary table of columns from different tables where something matches --
-- We join our tables over a common column, and usually they are a PK/FK pair --
-- but technically they can be any matching column --
-- LEFT JOIN, INNER JOIN, RIGHT JOIN, FULL OUTER --
-- INNER JOIN: includes records that exists in both tables --
-- LEFT/RIGHT JOIN: includes all records that exists in LEFT or RIGHT table
-- even if they may not exist on the other table
-- EX: Getting all questions, regardless of if they have answers or not
-- FULL JOIN: All records from both tables

-- SET Operations
-- Set operations "joins" rows in the result set
-- Set operations take place between two select statements
-- KEYWORDS: UNION, UNION ALL, INTERSECT, EXCEPT
-- Make sure your result sets have the same shape
-- UNION/UNION ALL: Returns all records from both result sets
-- Union vs union all: union all returns duplicates

-- INSERSECT: Returns records that Exists on Both Result Sets
-- "Get me all names that are shared by both dogs and people"
-- SELECT Name FROM Dogs INTERSECT SELECT Name FROM People

-- EXCEPT/MINUS: "Get me all cats except the white ones"
-- SELECT * FROM CATS EXCEPT SELECT * FROM CATS WHERE color = 'white';

-- SUBQUERY
-- "Nested Query"
SELECT * FROM Orders JOIN Customers ON Orders.customerId = Customers.Id
WHERE Customers.cName = 'Auryn'

SELECT * FROM Orders WHERE 
customerId = (SELECT id FROM Customers WHERE cName = 'Auryn')

SELECT * FROM 
(SELECT Products.id as pId, Products.pName, LineItems.id as lId, orderId 
FROM Products JOIN LineItems ON Products.id = LineItems.productId
WHERE Products.pName = 'banneton') as product_lineitem 
JOIN Orders on product_lineitem.orderId = Orders.Id