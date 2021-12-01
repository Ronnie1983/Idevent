-- https://www.mssqltips.com/sqlservertip/6798/drop-all-tables-sql-server/ (source on how to make this code)
USE Idevent
GO

-- generate sql to drop tables
SELECT 'DROP TABLE ' + '[' + TABLE_SCHEMA + '].[' + TABLE_NAME + ']'
FROM INFORMATION_SCHEMA.TABLES
ORDER BY TABLE_SCHEMA, TABLE_NAME

GO
