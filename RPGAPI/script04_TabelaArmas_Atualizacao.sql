BEGIN TRANSACTION;
ALTER TABLE [TB_PERSONAGENS] ADD [Derrotas] int NOT NULL DEFAULT 0;

ALTER TABLE [TB_PERSONAGENS] ADD [Disputas] int NOT NULL DEFAULT 0;

ALTER TABLE [TB_PERSONAGENS] ADD [Vitorias] int NOT NULL DEFAULT 0;

ALTER TABLE [TB_ARMAS] ADD [PersonagemId] int NOT NULL DEFAULT 0;

UPDATE [TB_ARMAS] SET [PersonagemId] = 1
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


UPDATE [TB_ARMAS] SET [PersonagemId] = 2
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


UPDATE [TB_ARMAS] SET [PersonagemId] = 3
WHERE [Id] = 3;
SELECT @@ROWCOUNT;


UPDATE [TB_ARMAS] SET [PersonagemId] = 4
WHERE [Id] = 4;
SELECT @@ROWCOUNT;


UPDATE [TB_ARMAS] SET [PersonagemId] = 5
WHERE [Id] = 5;
SELECT @@ROWCOUNT;


UPDATE [TB_ARMAS] SET [PersonagemId] = 6
WHERE [Id] = 6;
SELECT @@ROWCOUNT;


UPDATE [TB_ARMAS] SET [PersonagemId] = 7
WHERE [Id] = 7;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGENS] SET [Derrotas] = 0, [Disputas] = 0, [Vitorias] = 0
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGENS] SET [Derrotas] = 0, [Disputas] = 0, [Vitorias] = 0
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGENS] SET [Derrotas] = 0, [Disputas] = 0, [Vitorias] = 0
WHERE [Id] = 3;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGENS] SET [Derrotas] = 0, [Disputas] = 0, [Vitorias] = 0
WHERE [Id] = 4;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGENS] SET [Derrotas] = 0, [Disputas] = 0, [Vitorias] = 0
WHERE [Id] = 5;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGENS] SET [Derrotas] = 0, [Disputas] = 0, [Vitorias] = 0
WHERE [Id] = 6;
SELECT @@ROWCOUNT;


UPDATE [TB_PERSONAGENS] SET [Derrotas] = 0, [Disputas] = 0, [Vitorias] = 0
WHERE [Id] = 7;
SELECT @@ROWCOUNT;


CREATE UNIQUE INDEX [IX_TB_ARMAS_PersonagemId] ON [TB_ARMAS] ([PersonagemId]);

ALTER TABLE [TB_ARMAS] ADD CONSTRAINT [FK_TB_ARMAS_TB_PERSONAGENS_PersonagemId] FOREIGN KEY ([PersonagemId]) REFERENCES [TB_PERSONAGENS] ([Id]) ON DELETE CASCADE;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250407115211_MigracaoUmParaUm', N'9.0.2');

COMMIT;
GO

