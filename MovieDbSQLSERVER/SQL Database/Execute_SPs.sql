USE IMDb;
GO

--Data
SELECT Id, [Name], DOB, Bio, UpdatedAt
FROM [Foundation].[Actors];
SELECT Id, [Name], DOB, Bio, UpdatedAt
FROM [Foundation].[Producers];
SELECT Id, Title, YearOfRelease, Plot, Poster, ProducerId, [Language], Profit, UpdatedAt
FROM [Foundation].[Movies];
SELECT Id, MovieId, ActorId
FROM [Foundation].[ActorsMovies];
GO

-- Execute usp_AddMovieDetails 
BEGIN TRANSACTION;
GO
-- ROLLBACK;
-- COMMIT;

EXEC usp_AddMovieDetails 
@Title = 'The Dark Knight', 
@YearOfRelease = 2008,  
@Plot = 'When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept...', 
@Poster = 'https://www.imdb.com/title/tt0468569/mediaviewer/rm2489069056/', 
@Language = 'English', 
@Profit = 1000000, 
@ProducerId = 1, 
@ActorIds = '1,2,3',
@GenreIds = '1,2'
GO

-- Execute usp_DeleteMovieByMovieId 
BEGIN TRANSACTION;
GO
-- ROLLBACK;
-- COMMIT;

EXEC usp_DeleteMovieByMovieId 
@MovieId = 2
GO

--Execute usp_DeleteProduceMovieByProducerId
BEGIN TRANSACTION;
GO
-- ROLLBACK;
-- COMMIT;

EXEC usp_DeleteProduceMovieByProducerId
@ProducerId = 1
GO

--Execute usp_DeleteActorByActorId
BEGIN TRANSACTION;
GO
-- ROLLBACK;
-- COMMIT;

EXEC usp_DeleteActorByActorId
@ActorId = 1
GO
