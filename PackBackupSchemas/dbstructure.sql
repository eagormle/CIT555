CREATE TABLE [User] (
    [UserId] UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    [Username] NVARCHAR(255) NOT NULL,
    [PasswordSalt] VARBINARY(MAX) NOT NULL,
    [PasswordHash] VARBINARY(MAX) NOT NULL,
    [IsAdmin] BIT NOT NULL,
    [CreatedAt] DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
);

-- MSSQL Scheme for the User table, this is used by the program, do not change unless using different data structure.