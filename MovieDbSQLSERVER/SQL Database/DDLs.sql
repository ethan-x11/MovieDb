USE master
GO
ALTER DATABASE IMDb SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
DROP DATABASE IMDb;
GO

-- 1. Create a new database called IMDB.
CREATE DATABASE IMDb;
GO

USE IMDb;
GO

-- 2. Create a new schema called Foundation.
CREATE SCHEMA Foundation;
GO

-- 3. Use the schema to create the tables in the design created in Assignment 1.
CREATE TABLE [Foundation].[Actors]
(
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Name] NVARCHAR(225) NOT NULL,
    [Sex] CHAR(1) NOT NULL,
    [DOB] DATE NOT NULL,
    [Bio] NVARCHAR(max),
    CONSTRAINT CK_ActorSex CHECK(Sex in ('M', 'F', 'O')),
    CONSTRAINT CK_ActorDOB CHECK(DOB < GETDATE()),
);

CREATE TABLE [Foundation].[Producers]
(
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Name] NVARCHAR(225) NOT NULL,
    [Sex] CHAR(1) NOT NULL,
    [DOB] DATE NOT NULL,
    [Bio] NVARCHAR(max),
    CONSTRAINT CK_ProducerSex CHECK(Sex in ('M', 'F', 'O')),
    CONSTRAINT CK_ProducerDOB CHECK(DOB < GETDATE()),
);

CREATE TABLE [Foundation].[Movies]
(
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Title] NVARCHAR(500) NOT NULL,
    [YearOfRelease] INT NOT NULL,
    [Plot] NVARCHAR(max),
    [Poster] NVARCHAR(max),
    [ProducerId] INT NOT NULL FOREIGN KEY REFERENCES [Foundation].[Producers](Id),
    CONSTRAINT CK_MovieYearOfRelease CHECK(YearOfRelease > 1700 and YearOfRelease < YEAR(GETDATE()) + 100),
);

CREATE TABLE [Foundation].[ActorsMovies]
(
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [MovieId] INT NOT NULL FOREIGN KEY REFERENCES [Foundation].[Movies](Id),
    [ActorId] INT NOT NULL FOREIGN KEY REFERENCES [Foundation].[Actors](Id),
    CONSTRAINT UQ_ActorsMovies UNIQUE(MovieId, ActorId)
);

CREATE TABLE [Foundation].[Genres]
(
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Name] NVARCHAR(50) NOT NULL,
    CONSTRAINT UQ_Genre UNIQUE(Name)
);

CREATE TABLE [Foundation].[GenresMovies]
(
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [MovieId] INT NOT NULL FOREIGN KEY REFERENCES [Foundation].[Movies](Id),
    [GenreId] INT NOT NULL FOREIGN KEY REFERENCES [Foundation].[Genres](Id),
    CONSTRAINT UQ_MoviesGenres UNIQUE(MovieId, GenreId)
);

CREATE TABLE [Foundation].[Reviews]
(
    [Id] INT NOT NULL,
    [Message] NVARCHAR(max) NOT NULL,
    [MovieId] INT NOT NULL FOREIGN KEY REFERENCES [Foundation].[Movies](Id),
    CONSTRAINT UQ_Reviews UNIQUE(MovieId, Id)
)
GO

-- 5. Add two new columns called CreatedAt and UpDATEdAt using the alter Table command.
ALTER TABLE [Foundation].[Actors]
ADD
CreatedAt DATETIME, 
UpdatedAt DATETIME;

ALTER TABLE [Foundation].[Producers]
ADD
CreatedAt DATETIME, 
UpdatedAt DATETIME;

ALTER TABLE [Foundation].[Movies]
ADD
CreatedAt DATETIME, 
UpdatedAt DATETIME;
GO

-- 6. Create a default constraINT for CreatedAt to store the current DATE.
ALTER TABLE [Foundation].[Actors]
ADD CONSTRAINT DF_ActorsCreatedAt
DEFAULT GETUTCDATE() FOR CreatedAt;

ALTER TABLE [Foundation].[Producers]
ADD CONSTRAINT DF_ProducersCreatedAt
DEFAULT GETUTCDATE() FOR CreatedAt;

ALTER TABLE [Foundation].[Movies]
ADD CONSTRAINT DF_MoviesCreatedAt
DEFAULT GETUTCDATE() FOR CreatedAt;

-- 8. Alter the table to add a language(VARCHAR) and a profit(INT) column to the movies table.
ALTER TABLE [Foundation].[Movies]
ADD [Language] VARCHAR(25),
Profit INT,
CONSTRAINT DF_MovieProfit DEFAULT 0 FOR Profit;
GO