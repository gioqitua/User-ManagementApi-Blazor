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
GO

CREATE TABLE [UserProfiles] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(max) NOT NULL,
    [LastName] nvarchar(max) NOT NULL,
    [PersonalNumber] nvarchar(11) NOT NULL,
    CONSTRAINT [PK_UserProfiles] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [UserName] nvarchar(max) NOT NULL,
    [PasswordHash] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [IsActive] bit NOT NULL,
    [UserProfileId] int NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Users_UserProfiles_UserProfileId] FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfiles] ([Id])
);
GO

CREATE UNIQUE INDEX [IX_Users_UserProfileId] ON [Users] ([UserProfileId]) WHERE [UserProfileId] IS NOT NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230602144605_first', N'7.0.5');
GO

COMMIT;
GO

