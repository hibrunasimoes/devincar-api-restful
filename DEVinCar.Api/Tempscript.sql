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

CREATE TABLE [Cars] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(255) NOT NULL,
    [SuggestedPrice] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_Cars] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [Email] nvarchar(150) NOT NULL,
    [Password] nvarchar(50) NOT NULL,
    [Name] nvarchar(255) NOT NULL,
    [BirthDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220816222151_BaseClassRegistrationModule', N'6.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'SuggestedPrice') AND [object_id] = OBJECT_ID(N'[Cars]'))
    SET IDENTITY_INSERT [Cars] ON;
INSERT INTO [Cars] ([Id], [Name], [SuggestedPrice])
VALUES (1, N'Camaro Chevrolet', 60000.0),
(2, N'Maverick Ford', 20000.0),
(3, N'Astra Chevrolet', 30000.0),
(4, N'Hilux Toyota', 20000.0),
(5, N'Bravo Fiat', 20000.0),
(6, N'BR800 Gurgel', 10000.0),
(7, N'147 Fiat', 50000.0),
(8, N'Del Rey Ford', 10000.0),
(9, N'Mustang Ford', 70000.0),
(10, N'Belina Ford', 20000.0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'SuggestedPrice') AND [object_id] = OBJECT_ID(N'[Cars]'))
    SET IDENTITY_INSERT [Cars] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'BirthDate', N'Email', N'Name', N'Password') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] ON;
INSERT INTO [Users] ([Id], [BirthDate], [Email], [Name], [Password])
VALUES (1, '2000-12-10T00:00:00.0000000', N'jose@email.com', N'Jose', N'12345678'),
(2, '1999-05-11T00:00:00.0000000', N'andrea@email.com', N'Andrea', N'12345678'),
(3, '2005-09-02T00:00:00.0000000', N'adao@email.com', N'Adao', N'12345678'),
(4, '2001-06-07T00:00:00.0000000', N'monique@email.com', N'Monique', N'12345678');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'BirthDate', N'Email', N'Name', N'Password') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220816233112_BaseClassSeeds', N'6.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Sales] (
    [Id] int NOT NULL IDENTITY,
    [SaleDate] datetime NOT NULL,
    [BuyerId] int NOT NULL,
    [SellerId] int NOT NULL,
    CONSTRAINT [PK_Sales] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Sales_Users_BuyerId] FOREIGN KEY ([BuyerId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Sales_Users_SellerId] FOREIGN KEY ([SellerId]) REFERENCES [Users] ([Id])
);
GO

CREATE TABLE [State] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Initials] nvarchar(max) NULL,
    CONSTRAINT [PK_State] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [SaleCars] (
    [Id] int NOT NULL,
    [UnitPrice] decimal(18,2) NOT NULL,
    [Amount] int NOT NULL,
    [CarId] int NOT NULL,
    [SaleId] int NOT NULL,
    CONSTRAINT [PK_SaleCars] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_SaleCars_Cars_Id] FOREIGN KEY ([Id]) REFERENCES [Cars] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_SaleCars_Sales_Id] FOREIGN KEY ([Id]) REFERENCES [Sales] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Cities] (
    [Id] int NOT NULL IDENTITY,
    [StateId] int NOT NULL,
    [Name] nvarchar(255) NOT NULL,
    CONSTRAINT [PK_Cities] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Cities_State_StateId] FOREIGN KEY ([StateId]) REFERENCES [State] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Address] (
    [Id] int NOT NULL IDENTITY,
    [CityId] int NOT NULL,
    [Street] nvarchar(max) NULL,
    [Cep] nvarchar(max) NULL,
    [Number] int NOT NULL,
    [Complement] nvarchar(max) NULL,
    CONSTRAINT [PK_Address] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Address_Cities_CityId] FOREIGN KEY ([CityId]) REFERENCES [Cities] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Deliveries] (
    [Id] int NOT NULL IDENTITY,
    [DeliveryForecast] datetime NOT NULL,
    [AddressId] int NOT NULL,
    [SaleId] int NOT NULL,
    CONSTRAINT [PK_Deliveries] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Deliveries_Address_AddressId] FOREIGN KEY ([AddressId]) REFERENCES [Address] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Deliveries_Sales_SaleId] FOREIGN KEY ([SaleId]) REFERENCES [Sales] ([Id]) ON DELETE CASCADE
);
GO

UPDATE [Users] SET [Password] = N'123456opp78'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Users] SET [Password] = N'987dasd654321'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Users] SET [Password] = N'2589asd'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [Users] SET [Password] = N'asd45uio'
WHERE [Id] = 4;
SELECT @@ROWCOUNT;

GO

CREATE INDEX [IX_Address_CityId] ON [Address] ([CityId]);
GO

CREATE INDEX [IX_Cities_StateId] ON [Cities] ([StateId]);
GO

CREATE INDEX [IX_Deliveries_AddressId] ON [Deliveries] ([AddressId]);
GO

CREATE INDEX [IX_Deliveries_SaleId] ON [Deliveries] ([SaleId]);
GO

CREATE INDEX [IX_Sales_BuyerId] ON [Sales] ([BuyerId]);
GO

CREATE INDEX [IX_Sales_SellerId] ON [Sales] ([SellerId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220817235652_relationshipsSalesModule', N'6.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220818112159_DeliveryModule', N'6.0.8');
GO

COMMIT;
GO

