--SQL Sublanguages--
--DDL, DML, DQL, DCL, TCL--

--DDL: Data Definition Lanuage--
-- CREATE, ALTER, DROP, TRUNCATE --

--DML: Data Manipulation Language--
--INSERT, UPDATE, DELETE--

--DQL: Data Query Language--
--SELECT--

--DCL: Data Control Language--
--GRANT, REVOKE--

--TCL: Transaction Control Language--
--COMMIT, SAVEPOINT, ROLLBACK--

CREATE TABLE Users
(
    Id int PRIMARY KEY IDENTITY(1, 1),
    UserName VARCHAR(50) not null unique,
    NickName varchar(50),
    Password varchar(100) NOT NULL,
    Bio varchar(max)
);

DROP TABLE Users;

INSERT INTO Users(UserName, NickName, Password, Bio) VALUES
('nova_flash', 'novaflash', 'password', 'Bungus Time');

SELECT * FROM Users;

CREATE TABLE Issues (
    Id int PRIMARY KEY IDENTITY(1, 1),
    Title VARCHAR(255) NOT NULL,
    DateCreated DATETIME DEFAULT CURRENT_TIMESTAMP,
    Content VARCHAR(255),
    IsClosed BIT DEFAULT 0,
    Score INT DEFAULT 0,
    AuthorId INT FOREIGN KEY REFERENCES Users(Id),
);

INSERT INTO Issues(Title, Content, AuthorId) VALUES ('Object already exists, SQL', 'It''s giving me this error in my sql, how do i fix this?', 2)

SELECT * FROM Issues;

CREATE TABLE Answers
(
    Id int PRIMARY KEY IDENTITY(1,1),
    Score int Default 0,
    DateCreated DATETIME DEFAULT GETDATE(),
    AuthorId int FOREIGN KEY REFERENCES Users(Id),
    Content VARCHAR(255) not null,
    IsBestAnswer BIT DEFAULT 0,
    IssueId int FOREIGN KEY REFERENCES Issues(Id) NOT NULL
);

--CHECK(Condition against column name), UNIQUE--
--CHECK(Column_Name > 0)--

INSERT INTO Answers(AuthorId, Content, IssueId) VALUES (1, 'a sample answer', 1)

SELECT * FROM Answers

Truncate table Answers;