USE IMDb;
GO

--Data
SELECT *
FROM [Foundation].[Actors];
SELECT *
FROM [Foundation].[Producers];
SELECT *
FROM [Foundation].[Movies];
SELECT *
FROM [Foundation].[ActorsMovies];
SELECT *
FROM [Foundation].[Genres];
SELECT *
FROM [Foundation].[GenresMovies];
SELECT *
FROM [Foundation].[Reviews];
GO

SET DATEFORMAT dmy;
GO

-- If Previous Data Deleted
--Check if Actors is empty
IF NOT EXISTS (SELECT *
FROM [Foundation].[Actors])
DBCC CHECKIDENT ('[Foundation].[Actors]', RESEED, 0);
GO

IF NOT EXISTS (SELECT *
FROM [Foundation].[Producers])
DBCC CHECKIDENT ('[Foundation].[Producers]', RESEED, 0);
GO

IF NOT EXISTS (SELECT *
FROM [Foundation].[Movies])
DBCC CHECKIDENT ('[Foundation].[Movies]', RESEED, 0);
GO

IF NOT EXISTS (SELECT *
FROM [Foundation].[ActorsMovies])
DBCC CHECKIDENT ('[Foundation].[ActorsMovies]', RESEED, 0);
GO

IF NOT EXISTS (SELECT *
FROM [Foundation].[Genres])
DBCC CHECKIDENT ('[Foundation].[Genres]', RESEED, 0);
GO

IF NOT EXISTS (SELECT *
FROM [Foundation].[GenresMovies])
DBCC CHECKIDENT ('[Foundation].[GenresMovies]', RESEED, 0);
GO


-- 4. Fill in the required data making sure of the following conditions:
BEGIN TRANSACTION;
GO

-- Inserting actors
INSERT INTO [Foundation].[Actors]
    ([Name], Sex, DOB, Bio)
VALUES
    ('Robert Downey Jr.', 'M', '04/04/1965', 'Robert John Downey Jr. is an American actor, producer, and singer.'),
    ('Chris Evans', 'M', '13/06/1981', 'Christopher Robert Evans is an American actor.'),
    ('Chris Hemsworth', 'M', '11/08/1983', 'Christopher Hemsworth is an Australian actor.'),
    ('Scarlett Johansson', 'F', '22/11/1984', 'Scarlett Ingrid Johansson is an American actress and singer.'),
    ('Mark Ruffalo', 'M', '22/11/1967', 'Mark Alan Ruffalo is an American actor and producer.'),
    ('Tom Holland', 'M', '01/06/1996', 'Thomas Stanley Holland is an English actor and dancer.'),
    ('Brie Larson', 'F', '01/10/1989', 'Brianne Sidonie Desaulniers, known professionally as Brie Larson, is an American actress and filmmaker.'),
    ('Paul Rudd', 'M', '06/04/1969', 'Paul Stephen Rudd is an American actor, comedian, writer, and film producer.'),
    ('Jeremy Renner', 'M', '07/01/1971', 'Jeremy Lee Renner is an American actor and musician.'),
    ('Tom Hiddleston', 'M', '09/02/1981', 'Thomas William Hiddleston is an English actor.'),
    ('Samuel L. Jackson', 'M', '21/12/1948', 'Samuel Leroy Jackson is an American actor and producer.'),
    ('Zoe Saldana', 'F', '19/06/1978', 'Zoe Saldana-Perego is an American actress.'),
    ('Vin Diesel', 'M', '18/07/1967', 'Mark Sinclair, known professionally as Vin Diesel, is an American actor and filmmaker.'),
    ('Dave Bautista', 'M', '18/01/1969', 'David Michael Bautista Jr. is an American actor, retired professional wrestler, and former mixed martial artist.'),
    ('Karen Gillan', 'F', '28/11/1987', 'Karen Sheila Gillan is a Scottish actress and filmmaker.'),
    ('Bradley Cooper', 'M', '05/01/1975', 'Bradley Charles Cooper is an American actor and filmmaker.'),
    ('Gwyneth Paltrow', 'F', '27/09/1972', 'Gwyneth Kate Paltrow is an American actress, singer, author, and businesswoman.'),
    ('Don Cheadle', 'M', '29/11/1964', 'Donald Frank Cheadle Jr. is an American actor, author, director, producer, and writer.'),
    ('Anthony Mackie', 'M', '23/09/1978', 'Anthony Dwane Mackie is an American actor.'),
    ('Chadwick Boseman', 'M', '29/11/1976', 'Chadwick Aaron Boseman was an American actor and playwright.'),
    ('Elizabeth Olsen', 'F', '16/02/1989', 'Elizabeth Chase Olsen is an American actress.'),
    ('Paul Bettany', 'M', '27/05/1971', 'Paul Bettany is an English actor.'),
    ('Benedict Cumberbatch', 'M', '19/07/1976', 'Benedict Timothy Carlton Cumberbatch CBE is an English actor.'),
    ('Chris Pratt', 'M', '21/06/1979', 'Christopher Michael Pratt is an American actor.'),
    ('Josh Brolin', 'M', '12/02/1968', 'Josh James Brolin is an American actor.'),
    ('Idris Elba', 'M', '06/09/1972', 'Idrissa Akuna Elba OBE is an English actor, writer, producer, rapper, singer, songwriter, and DJ.'),
    ('Tessa Thompson', 'F', '03/10/1983', 'Tessa Lynne Thompson is an American actress.'),
    ('Benedict Wong', 'M', '03/06/1971', 'Benedict Wong is an English actor.'),
    ('Pom Klementieff', 'F', '03/05/1986', 'Pom Klementieff is a French actress.'),
    ('Letitia Wright', 'F', '31/10/1993', 'Letitia Michelle Wright is a Guyanese-British actress.'),
    ('Danai Gurira', 'F', '14/02/1978', 'Danai Jekesai Gurira is a Zimbabwean-American actress and playwright.'),
    ('Winston Duke', 'M', '15/11/1986', 'Winston Duke is a Tobagonian-American actor.'),
    ('Jacob Batalon', 'M', '09/10/1996', 'Jacob Batalon is a Filipino-American actor.'),
    ('Sebastian Stan', 'M', '13/08/1982', 'Sebastian Stan is a Romanian-American actor.'),
    ('Lupita Nyong''o', 'F', '01/03/1983', 'Lupita Amondi Nyong''o is a Kenyan-Mexican actress.'),
    ('Michael B. Jordan', 'M', '09/02/1987', 'Michael Bakari Jordan is an American actor and producer.'),
    ('Martin Freeman', 'M', '08/09/1971', 'Martin John Christopher Freeman is an English actor.'),
    ('Andy Serkis', 'M', '20/04/1964', 'Andrew Clement Serkis is an English actor and film director.'),
    ('Cate Blanchett', 'F', '14/05/1969', 'Catherine Elise Blanchett AC is an Australian actress and theatre director.'),
    ('Jeff Goldblum', 'M', '22/10/1952', 'Jeffrey Lynn Goldblum is an American actor and musician.');
GO

-- Inserting producers
INSERT INTO [Foundation].[Producers]
    ([Name], Sex, DOB, Bio)
VALUES
    ('Victoria Alonso', 'F', '01/01/1970', 'Victoria Alonso is an Argentine film producer and executive vice president of production at Marvel Studios.'),
    ('Brad Winderbaum', 'M', '01/01/1970', 'Brad Winderbaum is an American film producer and executive producer at Marvel Studios.'),
    ('Kevin Feige', 'M', '02/06/1973', 'Kevin Feige is an American film producer and television producer.'),
    ('Louis D''Esposito', 'M', '01/01/1970', 'Louis D''Esposito is an American film producer and co-president of Marvel Studios.'),
    ('Jon Favreau', 'M', '19/10/1966', 'Jonathan Kolia Favreau is an American actor, director, producer, and screenwriter.'),
    ('Stephen Broussard', 'M', '01/01/1970', 'Stephen Broussard is an American film producer and executive producer at Marvel Studios.'),
    ('Nate Moore', 'M', '01/01/1970', 'Nate Moore is an American film producer and executive producer at Marvel Studios.'),
    ('Trinh Tran', 'F', '01/01/1970', 'Trinh Tran is an American film producer and executive producer at Marvel Studios.'),
    ('Amy Pascal', 'F', '01/01/1970', 'Amy Beth Pascal is an American business executive and film producer.'),
    ('Kathleen Kennedy', 'F', '01/01/1970', 'Kathleen Kennedy is an American film producer and current president of Lucasfilm.'),
    ('Bong Joon Ho', 'M', '14/09/1969', 'Bong Joon-ho is a South Korean film director and screenwriter.'),
    ('Ang Lee', 'M', '23/10/1954', 'Ang Lee is a Taiwanese film director, producer, and screenwriter.'),
    ('Jean-Pierre Jeunet', 'M', '03/09/1953', 'Jean-Pierre Jeunet is a French film director, producer, and screenwriter.'),
    ('Olivier Nakache', 'M', '15/04/1973', 'Olivier Nakache is a French film director, producer, and screenwriter.'),
    ('Florian Henckel von Donnersmarck', 'M', '02/05/1973', 'Florian Maria Georg Christian Graf Henckel von Donnersmarck is a German film director, screenwriter, and producer.'),
    ('Thomas Vinterberg', 'M', '19/05/1969', 'Thomas Vinterberg is a Danish film director, who, along with Lars von Trier, co-founded the Dogme 95 movement in filmmaking.'),
    ('Paolo Sorrentino', 'M', '31/05/1970', 'Paolo Sorrentino is an Italian film director and screenwriter.'),
    ('Juan José Campanella', 'M', '19/07/1959', 'Juan José Campanella is an Argentine television and film director, writer and producer.'),
    ('Stefan Ruzowitzky', 'M', '25/12/1961', 'Stefan Ruzowitzky is an Austrian film director and screenwriter.'),
    ('Alejandro Amenábar', 'M', '31/03/1972', 'Alejandro Fernando Amenábar Cantos is a Spanish-Chilean film director, screenwriter, and composer.');
GO

-- Inserting movies
INSERT INTO [Foundation].[Movies]
    (Title, YearOfRelease, Plot, Poster, ProducerId, [Language], Profit)
VALUES
    ('Iron Man', 2008, 'After being held captive in an Afghan cave, billionaire engineer Tony Stark creates a unique weaponized suit of armor to fight evil.', 'iron_man_poster.jpg', 1, 'English', 585),
    ('The Incredible Hulk', 2008, 'Bruce Banner, a scientist on the run from the U.S. Government, must find a cure for the monster he turns into whenever he loses his temper.', 'the_incredible_hulk_poster.jpg', 1, 'English', 263),
    ('Iron Man 2', 2010, 'With the world now aware of his identity as Iron Man, Tony Stark must contend with both his declining health and a vengeful mad man with ties to his father''s legacy.', 'iron_man_2_poster.jpg', 1, 'English', 623),
    ('Thor', 2011, 'The powerful but arrogant god Thor is cast out of Asgard to live amongst humans in Midgard (Earth), where he soon becomes one of their finest defenders.', 'thor_poster.jpg', 2, 'English', 449),
    ('Captain America: The First Avenger', 2011, 'Steve Rogers, a rejected military soldier, transforms into Captain America after taking a dose of a "Super-Soldier serum". But being Captain America comes at a price as he attempts to take down a war monger and a terrorist organization.', 'captain_america_the_first_avenger_poster.jpg', 1, 'English', 370),
    ('The Avengers', 2012, 'Earth''s mightiest heroes must come together and learn to fight as a team if they are going to stop the mischievous Loki and his alien army from enslaving humanity.', 'the_avengers_poster.jpg', 1, 'English', 1519),
    ('Iron Man 3', 2013, 'When Tony Stark''s world is torn apart by a formidable terrorist called the Mandarin, he starts an odyssey of rebuilding and retribution.', 'iron_man_3_poster.jpg', 3, 'English', 1214),
    ('Thor: The Dark World', 2013, 'When the Dark Elves attempt to plunge the universe into darkness, Thor must embark on a perilous and personal journey that will reunite him with doctor Jane Foster.', 'thor_the_dark_world_poster.jpg', 4, 'English', 644),
    ('Captain America: The Winter Soldier', 2014, 'As Steve Rogers struggles to embrace his role in the modern world, he teams up with a fellow Avenger and S.H.I.E.L.D agent, Black Widow, to battle a new threat from history: an assassin known as the Winter Soldier.', 'captain_america_the_winter_soldier_poster.jpg', 6, 'English', 714),
    ('Guardians of the Galaxy', 2014, 'A group of intergalactic criminals must pull together to stop a fanatical warrior with plans to purge the universe.', 'guardians_of_the_galaxy_poster.jpg', 5, 'English', 773),
    ('Parasite', 2019, 'Greed and class discrimination threaten the newly formed symbiotic relationship between the wealthy Park family and the destitute Kim clan.', 'parasite_poster.jpg', 9, 'Korean', 266),
    ('Crouching Tiger, Hidden Dragon', 2000, 'Two warriors in pursuit of a stolen sword and a notorious fugitive are led to an impetuous, physically skilled, adolescent nobleman''s daughter, who is at a crossroads in her life.', 'crouching_tiger_hidden_dragon_poster.jpg', 10, 'Mandarin', 213),
    ('Amélie', 2001, 'Amélie is an innocent and naive girl in Paris with her own sense of justice. She decides to help those around her and, along the way, discovers love.', 'amelie_poster.jpg', 11, 'French', 33),
    ('The Intouchables', 2011, 'After he becomes a quadriplegic from a paragliding accident, an arist ocrat hires with his assistant and caretaker, his unlikely friend and his life completely changes.', 'the_intouchables_poster.jpg', 12, 'French', 426),
    ('The Lives of Others', 2006, 'In 1984 East Berlin, an agent of the secret police, conducting surveillance on a writer and his lover, finds himself becoming increasingly absorbed by their lives.', 'the_lives_of_others_poster.jpg', 13, 'German', 77),
    ('The Hunt', 2012, 'A teacher lives a lonely life, all the while struggling over his son''s custody. His life slowly gets better as he finds love and receives good news from his son, but his new luck is about to be brutally shattered by an innocent little lie.', 'the_hunt_poster.jpg', 14, 'Danish', 16),
    ('The Great Beauty', 2013, 'Jep Gambardella has seduced his way through the lavish nightlife of Rome for decades, but after his 65th birthday and a shock from the past, Jep looks past the nightclubs and parties to find a timeless landscape of absurd, exquisite beauty.', 'the_great_beauty_poster.jpg', 15, 'Italian', 4),
    ('The Secret in Their Eyes', 2009, 'A retired legal counselor writes a novel hoping to find closure for one of his past unresolved homicide cases and for his unreciprocated love with his superior - both of which still haunt him decades later.', 'the_secret_in_their_eyes_poster.jpg', 16, 'Spanish', 33),
    ('The Counterfeiters', 2007, 'The story of the Operation Bernhard, the largest counterfeiting operation in history, carried out by Germany during WWII.', 'the_counterfeiters_poster.jpg', 17, 'German', 5),
    ('The Sea Inside', 2004, 'The factual story of Spaniard Ramon Sampedro, who fought a 30-year campaign to win the right to end his life with dignity.', 'the_sea_inside_poster.jpg', 18, 'Spanish', 2),
    ('The Barbarian Invasions', 2003, 'During his final days in a Quebecois palliative care unit, a father sees his life start to unravel when a new patient arrives.', 'the_barbarian_invasions_poster.jpg', 19, 'French', 2),
    ('Doctor Strange', 2016, 'A former neurosurgeon embarks on a journey of healing only to be drawn into the world of the mystic arts.', 'doctor_strange_poster.jpg', 1, 'English', 677);
GO

-- Inserting actors_movies
INSERT INTO [Foundation].[ActorsMovies]
    (ActorId, MovieId)
VALUES
-- 21 movies are there and 40 actors
    (1, 1), (2, 1), (4, 2),(5, 2), (1, 3), (2, 3), (1, 6),(2, 6), (1, 7), (2, 7), (1, 10), (2, 10), (3, 4), (3, 5), (3, 8), (3, 9), (3, 10),
    (4, 5), (4, 6), (4, 7), (4, 8), (4, 9), (4, 10), (5, 6), (5, 7), (5, 8), (5, 9), (5, 10), (6, 6), (6, 7), (6, 8), (6, 9),
    (6, 10), (7, 6), (7, 7), (7, 8), (7, 9), (7, 10), (8, 6), (8, 7), (8, 8), (8, 9), (8, 10), (9, 6), (9, 7), (9, 8), (9, 9),
    (9, 10), (10, 6), (10, 7), (10, 8), (10, 9), (10, 10), (12,11), (13,11), (14,12), (15, 12), (16,12), (17, 12), (18, 12),
    (19,12), (20,13), (21,13), (22,13), (23,13), (24, 13), (25, 13), (21,14), (22,14), (23,14), (23, 15), (24, 15), (25, 15), 
    (37, 16), (26, 16), (37, 17),(38, 18),(39, 18),(40, 18), (31, 19),(32, 19),(33, 19), (34, 20),(35, 20),(36, 20),(37,21),
    (38, 21),(39, 21), (40,21),(23, 22),(6, 22);
GO

-- Inserting genres
INSERT INTO [Foundation].[Genres]
    (Name)
VALUES
    ('Action'),
    ('Adventure'),
    ('Sci-Fi'),
    ('Drama'),
    ('Comedy'),
    ('Thriller'),
    ('Crime'),
    ('Biography'),
    ('History'),
    ('Mystery'),
    ('Fantasy'),
    ('Romance'),
    ('War'),
    ('Horror'),
    ('Animation'),
    ('Family'),
    ('Music'),
    ('Musical'),
    ('Sport'),
    ('Western'),
    ('Documentary');
GO

-- Inserting genres_movies
INSERT INTO [Foundation].[GenresMovies]
    (MovieId, GenreId)
VALUES
    (1, 1), (1, 3), (2, 1), (2, 3), (3, 1), (3, 3), (4, 1), (4, 3), (5, 1), (5, 3), (6, 1), (6, 3), (7, 1), (7, 3), (8, 1), (8, 3),
    (9, 1), (9, 3), (10, 1), (10, 3), (11, 1), (11, 3), (12, 1), (12, 3), (13, 1), (13, 3), (14, 1), (14, 3), (15, 1), (15, 3),
    (16, 1), (16, 3), (17, 1), (17, 3), (18, 1), (18, 3), (19, 1), (19, 3), (20, 1), (20, 3), (21, 1), (21, 3), (22, 1), (22, 3);

-- Inserting reviews
INSERT INTO [Foundation].[Reviews]
    (Id, [Message], MovieId)
VALUES
    (1, 'Great movie!', 1),
    (1, 'Awesome movie!', 2),
    (1, 'Fantastic movie!', 3),
    (1, 'Amazing movie!', 4),
    (1, 'Superb movie!', 5),
    (1, 'Excellent movie!', 6),
    (1, 'Good movie!', 7),
    (1, 'Nice movie!', 8),
    (1, 'Cool movie!', 9),
    (1, 'Brilliant movie!', 10),
    (1, 'Great movie!', 11),
    (1, 'Awesome movie!', 12),
    (1, 'Fantastic movie!', 13),
    (1, 'Amazing movie!', 14),
    (1, 'Superb movie!', 15),
    (1, 'Excellent movie!', 16),
    (1, 'Good movie!', 17),
    (1, 'Nice movie!', 18),
    (1, 'Cool movie!', 19),
    (2, 'Brilliant movie!', 20),
    (1, 'Great movie!', 21),
    (1, 'Great movie!', 22),    
    (2, 'Awesome movie!', 22);    
GO

-- ROLLBACK;
-- COMMIT;