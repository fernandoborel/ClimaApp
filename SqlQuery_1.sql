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
CREATE TABLE [Solicitante] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_Solicitante] PRIMARY KEY ([Id])
);

CREATE TABLE [Relatorio] (
    [Id] int NOT NULL IDENTITY,
    [Cidade] nvarchar(100) NOT NULL,
    [Pais] nvarchar(100) NOT NULL,
    [Temperatura] decimal(18,2) NOT NULL,
    [Condicao] nvarchar(50) NOT NULL,
    [VelocidadeVento] decimal(18,2) NOT NULL,
    [DataHora] datetime2 NOT NULL,
    [SolicitanteId] int NOT NULL,
    CONSTRAINT [PK_Relatorio] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Relatorio_Solicitante_SolicitanteId] FOREIGN KEY ([SolicitanteId]) REFERENCES [Solicitante] ([Id]) ON DELETE CASCADE
);

CREATE INDEX [IX_Relatorio_SolicitanteId] ON [Relatorio] ([SolicitanteId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250627150422_Initial', N'9.0.6');

COMMIT;
GO