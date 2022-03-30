--SQL is a declarative language not imperative --

--SELECT--

-- SELECT column_name_separated_by_coma FROM table_name --

-- SELECTING ALL COLUMNS and ALL RECORDS FROM Users Table --
SELECT * FROM Users;

-- SELECTING Specific columns for all records from Users Table --
SELECT UserName, Bio, Id FROM Users;
SELECT Bio, Id, UserName FROM Users;

-- WHERE Clause --
SELECT * FROM Users WHERE UserName = 'jsong';
SELECT Id, UserName, Bio FROM Users WHERE Id < 4 OR Bio LIKE '%like%';

-- GROUP BY Clause --
SELECT COUNT(Password) AS Number_of_Users, Password FROM Users 
GROUP BY Password;

-- HAVING Clause --
SELECT COUNT(Password) AS Number_of_Users, Password FROM Users 
GROUP BY Password
HAVING COUNT(Password) > 1;

-- ORDER BY Clause --
SELECT * FROM Users ORDER BY UserName desc;
SELECT * FROM Users ORDER BY UserName asc;

SELECT * FROM Users ORDER BY Id desc;

-- DML --
Update Users
SET Bio = 'My Name is Juniper and I like to pet cats'
WHERE UserName = 'jsong';

Delete FROM Users WHERE UserName = 'jsong';

INSERT INTO Users(UserName, NickName, Password, Bio) VALUES ('jsong', 'roaringsheep', 'P@ssw0rd!', 'I like to play OMORI');

-- FUNCTIONS --
-- SCALAR Fns --
-- Scalar Fn's is any sql functions that returns a Single value --
-- EX: GET_DATE(), UPPER(), LOWER(), AVG(), COUNT(), MIN(), MAX() --

-- AGGREGATE Fns --
-- Aggregate fn's are functions that takes in many records --
-- EX: COUNT, MAX, MIN, AVG --

-- Using Aggregate Fn's in SELECT statements with Alias --
SELECT COUNT(Password) AS Number_of_Users FROM Users WHERE Password = 'P@ssw0rd!';

-- Using Scalar Fn's in SELECT Statements --
SELECT UPPER(UserName) as Upper_Case_UsrName, Password, Bio FROM Users;
SELECT UPPER(Password) As Upper_Pass FROM Users;


-- TYPES OF JOINS --
-- INNER JOIN, FULL JOIN, LEFT JOIN, RIGHT JOIN, SELF JOIN --
SELECT cName, dateCreated, total
FROM Customers
LEFT JOIN Orders ON Orders.customerId = Customers.id;

SELECT cName, dateCreated, total
FROM Orders
JOIN Customers ON Orders.customerId = Customers.id
JOIN LineItems ON Orders.Id = LineItems.orderId
JOIN Products ON LineItems.productId = Products.Id;
