USE IMDb;
GO

---- MOVIES ----
-- Add Movie
CREATE PROCEDURE usp_AddMovieDetails
	@Title NVARCHAR(225),
	@YearOfRelease INT,
	@Plot NVARCHAR(max),
	@Poster NVARCHAR(max),
	@Language NVARCHAR(25),
	@Profit INT,
	@ProducerId INT,
	@ActorIds VARCHAR(max),
	@genreIds VARCHAR(max)
AS
BEGIN
	-- adding movie details to the Movies Table
	INSERT INTO [Foundation].[Movies]
		(
		Title,
		YearOfRelease,
		Plot,
		Poster,
		[Language],
		Profit,
		ProducerId
		)
	VALUES
		(
			@Title,
			@YearOfRelease,
			@Plot,
			@Poster,
			@Language,
			@Profit,
			@ProducerId
			)

	-- fetching the movie Id
	DECLARE @MovieId INT

	SET @MovieId = SCOPE_IDENTITY()

	-- add actorsIds to the ActorsMovies table
	INSERT INTO [Foundation].[ActorsMovies]
		(
		MovieId,
		ActorId
		)
	SELECT @MovieId,
		VALUE
	FROM STRING_SPLIT(@ActorIds, ',');

	-- add genresIds to the GenresMovies table
	INSERT INTO [Foundation].[GenresMovies]
		(
		MovieId,
		GenreId
		)
	SELECT @MovieId,
		VALUE
	FROM STRING_SPLIT(@genreIds, ',');

	SELECT @MovieId
-- PRINT 'Movie Added'
END
GO

-- Update Movie
CREATE PROCEDURE usp_UpdateMovieDetails
	@Id INT,
	@Title NVARCHAR(225),
	@YearOfRelease INT,
	@Plot NVARCHAR(max),
	@Poster NVARCHAR(max),
	@Language NVARCHAR(25),
	@Profit INT,
	@ProducerId INT,
	@ActorIds VARCHAR(max),
	@genreIds VARCHAR(max)
AS
BEGIN
	IF EXISTS (
			SELECT *
	FROM [Foundation].[Movies]
	WHERE Id = @Id
			)
	BEGIN
		-- adding movie details to the Movies Table
		-- PRINT 'Updating Movie Details'

		UPDATE [Foundation].[Movies] 
		SET
			Title = @Title,
			YearOfRelease = @YearOfRelease,
			Plot = @Plot,
			Poster = @Poster,
			[Language] = @Language,
			Profit = @Profit,
			ProducerId = @ProducerId
		WHERE [Id] = @Id;

		-- update actorsIds to the ActorsMovies table
		DELETE FROM [Foundation].[ActorsMovies] WHERE MovieId = @Id;

		INSERT INTO [Foundation].[ActorsMovies]
			(
			MovieId,
			ActorId
			)
		SELECT @Id,
			VALUE
		FROM STRING_SPLIT(@ActorIds, ',');

		-- update genresIds to the GenresMovies table
		DELETE FROM [Foundation].[GenresMovies] WHERE MovieId = @Id;

		INSERT INTO [Foundation].[GenresMovies]
			(
			MovieId,
			GenreId
			)
		SELECT @Id,
			VALUE
		FROM STRING_SPLIT(@genreIds, ',');
	END
END
GO

-- Delete Movie
CREATE PROCEDURE usp_DeleteMovieDetails
	@Id INT
AS
BEGIN
	DELETE
	FROM [Foundation].[GenresMovies]
	WHERE [MovieId] = @Id

	DELETE
	FROM [Foundation].[ActorsMovies]
	WHERE [MovieId] = @Id

	DELETE
	FROM [Foundation].[Reviews]
	WHERE [Id] = @Id

	DELETE
	FROM [Foundation].[Movies]
	WHERE [Id] = @Id
END
GO


---- ACTORS ----
-- Add Actor
CREATE PROCEDURE usp_AddActorDetails
	@Name NVARCHAR(max),
	@Sex CHAR(1),
	@DOB DATE,
	@Bio NVARCHAR(max)
AS
BEGIN
	INSERT INTO [Foundation].[Actors]
		(
		[Name],
		[Sex],
		[DOB],
		[Bio]
		)
	Values
		(
			@Name,
			@Sex,
			@DOB,
			@Bio
		)

	SELECT SCOPE_IDENTITY()
END
GO

-- Update Actor
CREATE PROCEDURE usp_UpdateActorDetails
	@Id INT,
	@Name NVARCHAR(max),
	@Sex CHAR(1),
	@DOB DATE,
	@Bio NVARCHAR(max)
AS
BEGIN
	IF EXISTS (
			SELECT *
	FROM [Foundation].[Actors]
	WHERE Id = @Id
			)
	BEGIN
		UPDATE [Foundation].[Actors]
		Set [Name] = @Name,
			[Sex] = @Sex,
			[DOB] = @DOB,
			[Bio] = @Bio
		WHERE [Id] = @Id
	END
END
GO

-- Delete Actor
CREATE PROCEDURE usp_DeleteActorDetails
	@Id INT
AS
BEGIN
	DELETE
	FROM [Foundation].[ActorsMovies]
	WHERE [ActorId] = @Id

	DELETE
	FROM [Foundation].[Actors]
	WHERE [Id] = @Id
END
GO


---- PRODUCERS ----
-- Add Producer
CREATE PROCEDURE usp_AddProducerDetails
	@Name NVARCHAR(max),
	@Sex CHAR(1),
	@DOB DATE,
	@Bio NVARCHAR(max)
AS
BEGIN
	INSERT INTO [Foundation].[Producers]
		(
		[Name],
		[Sex],
		[DOB],
		[Bio]
		)
	Values
		(
			@Name,
			@Sex,
			@Dob,
			@Bio
		)

	SELECT SCOPE_IDENTITY()
END
GO

-- Update Producer
CREATE PROCEDURE usp_UpdateProducerDetails
	@Id INT,
	@Name NVARCHAR(max),
	@Sex CHAR(1),
	@DOB DATE,
	@Bio NVARCHAR(max)
AS
BEGIN
	IF EXISTS (
			SELECT *
	FROM [Foundation].[Producers]
	WHERE Id = @Id
			)
	BEGIN
		UPDATE [Foundation].[Producers]
		Set [Name] = @Name,
			[Sex] = @sex,
			[DOB] = @dob,
			[Bio] = @bio
		WHERE [Id] = @Id
	END
END
GO

-- Delete Producer
CREATE PROCEDURE usp_DeleteProducerDetails
	@Id INT
AS
BEGIN
	DELETE
	FROM [Foundation].[ActorsMovies]
	WHERE [MovieId] IN 
	(
		SELECT [Id]
	FROM [Foundation].[Movies]
	WHERE [ProducerId] = @Id
	)

	DELETE
	FROM [Foundation].[GenresMovies]
	WHERE [MovieId] IN 
	(
		SELECT [Id]
	FROM [Foundation].[Movies]
	WHERE [ProducerId] = @Id
	)

	DELETE
	FROM [Foundation].[Reviews]
	WHERE [MovieId] IN 
	(
		SELECT [Id]
	FROM [Foundation].[Movies]
	WHERE [ProducerId] = @Id
	)

	DELETE
	FROM [Foundation].[Movies]
	WHERE [ProducerId] = @Id

	DELETE
	FROM [Foundation].[Producers]
	WHERE [Id] = @Id
END
GO


---- GENRES ----
-- Add Genre
CREATE PROCEDURE usp_AddGenreDetails
	@Name NVARCHAR(max)
AS
BEGIN
	INSERT INTO [Foundation].[Genres]
		(
		[Name]
		)
	Values
		(
			@Name
		)

	SELECT SCOPE_IDENTITY()
END
GO

-- Update Genre
CREATE PROCEDURE usp_UpdateGenreDetails
	@Id INT,
	@Name NVARCHAR(max)
AS
BEGIN
	IF EXISTS (
			SELECT *
	FROM [Foundation].[Genres]
	WHERE Id = @Id
			)
	BEGIN
		UPDATE [Foundation].[Genres]
		Set [Name] = @Name
		WHERE [Id] = @Id
	END
END
GO

-- Delete Genre
CREATE PROCEDURE usp_DeleteGenreDetails
	@Id INT
AS
BEGIN
	DELETE
	FROM [Foundation].[GenresMovies]
	WHERE [GenreId] = @Id

	DELETE
	FROM [Foundation].[Genres]
	WHERE [Id] = @Id
END
GO


---- REVIEWS ----
-- Add Review
CREATE PROCEDURE usp_AddReviewDetails
	@Message NVARCHAR(max),
	@MovieId INT
AS
BEGIN
	DECLARE @ReviewId INT

	SELECT @ReviewId = MAX(Id) + 1
	FROM [Foundation].[Reviews]
	WHERE [MovieId] = @MovieId

	INSERT INTO [Foundation].[Reviews]
		(
		[Id],
		[Message],
		[MovieId]
		)
	Values
		(
			@ReviewId,
			@Message,
			@movieId
		)

	SELECT @ReviewId
END
GO

-- Update Review
CREATE PROCEDURE usp_UpdateReviewDetails
	@Id INT,
	@Message NVARCHAR(max),
	@MovieId INT
AS
BEGIN
	IF EXISTS (
			SELECT *
	FROM [Foundation].[Reviews]
	WHERE Id = @Id
			)
	BEGIN
		UPDATE [Foundation].[Reviews]
		Set [Message] = @Message
		WHERE [MovieId] = @movieId AND [Id] = @Id
	END
END
GO

-- Delete Review
CREATE PROCEDURE usp_DeleteReviewDetails
	@Id INT,
	@MovieId INT
AS
BEGIN
	DELETE
	FROM [Foundation].[Reviews]
	WHERE [MovieId] = @movieId AND [Id] = @Id
END
GO