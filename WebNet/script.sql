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

CREATE TABLE [Pessoas] (
    [PessoaId] SERIAL PRIMARY KEY NOT NULL,
    [Nome] nvarchar(max) NOT NULL,
    [Sobrenome] nvarchar(max) NOT NULL,
    [Idade] int NOT NULL,
    [Profissao] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Pessoas] PRIMARY KEY ([PessoaId])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240130000404_criacaoDB', N'8.0.1');
GO

COMMIT;
GO

