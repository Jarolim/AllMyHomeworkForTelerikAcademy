UPDATE Users
SET Password = 'default'
WHERE LastLogin <= CAST('10.03.2010 00:00:00' AS smalldatetime)