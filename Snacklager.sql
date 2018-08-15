CREATE DATABASE [Snacklager];
GO

USE [Snacklager]
GO

CREATE TABLE [SnackArt] (
	[Id] int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Name] nvarchar(max)
);
GO

CREATE TABLE [Snack] (
	[Id] int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[SnackArtId] int NOT NULL,
	[Name] nvarchar(max) NOT NULL,
	[GewichtProEinheit] float,
	[Added] DateTime2 NOT NULL,
	[Modified] DateTime2,
	[ModifiedBy] Varchar(200),
	CONSTRAINT [FK_Snack_SnackArt] FOREIGN KEY([SnackArtId]) REFERENCES [SnackArt]([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Zutaten](
	[Id] int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[SnackId] int NOT NULL,
	[Name] nvarchar(max) NOT NULL,
	[IstVegan] bit,
	[IstVegetarisch] bit,
	[IstNuss] bit,
	[Added] DateTime2 NOT NULL,
	[Modified] DateTime2,
	[ModifiedBy] Varchar(200),
	CONSTRAINT [FK_Zutaten_Snack] FOREIGN KEY ([SnackId]) REFERENCES [Snack] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Lager](
	[Id] int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Bezeichnung] nvarchar(max) NOT NULL,
	[Kapazitaet] int,
	[Added] DateTime2 NOT NULL,
	[Modified] DateTime2,
	[ModifiedBy] Varchar(200),
);
GO

CREATE TABLE [Lagerhaltung](
	[Id] int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[LagerId] int NOT NULL,
	[SnackId] int NOT NULL,
	[Einheiten] int,
	[Haltbarkeit] DateTime2,
	[Added] DateTime2 NOT NULL,
	[Modified] DateTime2,
	[ModifiedBy] Varchar(200),
	CONSTRAINT [FK_Lagerhaltung_Lager] FOREIGN KEY ([LagerId]) REFERENCES [Lager] ([Id]) ON DELETE CASCADE,
	CONSTRAINT [FK_Lagerhaltung_Snack] FOREIGN KEY ([SnackId]) REFERENCES [Snack] ([Id]) ON DELETE CASCADE
);