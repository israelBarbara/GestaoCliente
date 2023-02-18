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

CREATE TABLE [CLIENTE] (
    [Id] int NOT NULL IDENTITY,
    [Nome] varchar(100) NOT NULL,
    [Cpf] varchar(11) NOT NULL,
    [DataNascimento] datetime2 NOT NULL,
    [Sexo] int NOT NULL,
    [Endereco] varchar(100) NOT NULL,
    [Estado] varchar(2) NOT NULL,
    [Cidade] varchar(100) NOT NULL,
    CONSTRAINT [PK_CLIENTE] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230217160206_Initial', N'6.0.14');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230218122641_Initial2', N'6.0.14');
GO

COMMIT;
GO

