CREATE TABLE [dbo].[Table]
(
	[CustId] INT NOT NULL PRIMARY KEY, 
    [first_name] NVARCHAR(50) NULL, 
    [last_name] NVARCHAR(50) NULL, 
    [date_of_birth] DATE NULL, 
    [security_no] NCHAR(10) NULL
)
