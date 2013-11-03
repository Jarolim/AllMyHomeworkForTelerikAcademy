USE [BookstoreSystem]

-- Run this a few times to clear the DB. Note: Don't mind the errors, just run it a few times :) --
DELETE FROM Authors
DELETE FROM Books
DELETE FROM Reviews
DELETE FROM Books_Authors

-- Use this to see what you want from the tables :)
SELECT * FROM Authors
SELECT * FROM Books
SELECT * FROM Reviews
SELECT * FROM Books_Authors

USE [Logs]
SELECT * FROM SearchLogs