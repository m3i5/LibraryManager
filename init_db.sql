IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
CREATE TABLE [Resources] (
    [Id] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NOT NULL,
    [Author] nvarchar(max) NOT NULL,
    [PublicationYear] int NOT NULL,
    [Genre] nvarchar(max) NOT NULL,
    [ResourceType] nvarchar(max) NOT NULL,
    [IsAvailable] bit NOT NULL,
    [BorrowedBy] nvarchar(max) NULL,
    [DueDate] datetime2 NULL,
    CONSTRAINT [PK_Resources] PRIMARY KEY ([Id])
);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250629220306_InitialCreate', N'9.0.6');

COMMIT;
GO

