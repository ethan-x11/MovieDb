## MovieDbRESTAPI

**A RESTful API for a Movie Database built with C#, ASP.NET, SQL Server, and Firebase Storage.**

This project provides a robust and scalable REST API for managing a movie database. It leverages the power of:

- **C#** <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/csharp/csharp-original.svg" width="20" height="20"> and **ASP.NET Core** <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/dot-net/dot-net-original-wordmark.svg" width="35" height="20">: For building a fast and efficient API.
- **SQL Server** : As a reliable relational database for storing movie information, actors, directors, etc.
- **Firebase Storage** <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/firebase/firebase-plain.svg" width="20" height="20">: For secure and scalable storage of movie posters and other media assets.
- **Specflow** <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/cucumber/cucumber-plain.svg" width="20" height="20">: Used for Behavior Driven Development (BDD) testing to ensure the API behaves as expected from a user's perspective.

### Features

- **CRUD Operations:** Create, Read, Update, and Delete movies, actors, directors, genres, and more.
- **Search & Filtering:** Easily find movies based on title, genre, release year, actors, directors, and other criteria.
- **User Authentication & Authorization:** Secure the API using industry-standard authentication methods. (**Implementation details will depend on your chosen approach**)
- **Firebase Integration:** Seamlessly upload and retrieve movie posters and other media assets using Firebase Storage.
- **Behavior Driven Development (BDD) Testing:** Implemented using Specflow for clear and maintainable tests, ensuring that the API behaves as expected from a user's perspective.

### Getting Started

1. **Clone the Repository:**
   ```bash
   git clone https://github.com/ethan-x11/MovieDb.git
   ```

2. **Database Setup:**
   - Create a SQL Server database and update the connection string in the application settings (`appsettings.json`).
   - Run any necessary database migrations to create the required tables. (Provide migration instructions if applicable)

3. **Firebase Setup:**
   - Create a Firebase project and obtain the necessary credentials for storage.
   - Configure the application to use your Firebase credentials.

4. **Build & Run:**
   - Build the project using your preferred IDE or command-line tools.
   - Run the application, and the API will be accessible at the configured address (e.g., `https://localhost:5001/api/movies`).

## API Documentation

This documentation provides an overview of the available endpoints in the IMDbRESTAPI (v1), which offers CRUD operations for managing movie-related data.

**Key Features:**

- **CRUD Operations:** Create, Read, Update, and Delete Movies, Actors, Producers, Genres, and Reviews.
- **Search & Filter:** Search for movies based on various criteria like year, language, and genre.
- **Firebase Integration:** Upload and manage movie posters using Firebase Storage. 

**Base URL:** `[Your Base URL]/api` (Replace `[Your Base URL]` with your actual API base URL)

**Endpoints:**

**Actors:**
- `GET /Actors`: Get all actors.
- `POST /Actors`: Create a new actor.
- `GET /Actors/{id}`: Get an actor by ID.
- `PUT /Actors/{id}`: Update an existing actor.
- `DELETE /Actors/{id}`: Delete an actor.

**Genres:**
- `GET /Genres`: Get all genres.
- `POST /Genres`: Create a new genre.
- `GET /Genres/{id}`: Get a genre by ID.
- `PUT /Genres/{id}`: Update an existing genre.
- `DELETE /Genres/{id}`: Delete a genre.

**Movies:**
- `GET /Movies`: Get all movies (with optional filtering).
- `POST /Movies`: Create a new movie.
- `GET /Movies/{id}`: Get a movie by ID.
- `PUT /Movies/{id}`: Update an existing movie.
- `DELETE /Movies/{id}`: Delete a movie.
- `POST /Movies/upload`: Upload a movie poster.

**Producers:**
- `GET /Producers`: Get all producers.
- `POST /Producers`: Create a new producer.
- `GET /Producers/{id}`: Get a producer by ID.
- `PUT /Producers/{id}`: Update an existing producer.
- `DELETE /Producers/{id}`: Delete a producer.

**Reviews:**
- `GET /movies/{movieId}/Reviews`: Get all reviews for a movie.
- `POST /movies/{movieId}/Reviews`: Add a review to a movie.
- `GET /movies/{movieId}/Reviews/{id}`: Get a specific review.
- `PUT /movies/{movieId}/Reviews/{id}`: Update a review.
- `DELETE /movies/{movieId}/Reviews/{id}`: Delete a review.

**Request and Response Formats:**

The API uses JSON for request and response bodies. Refer to the provided OpenAPI specification (JSON) for detailed information on request parameters, response structures, and data types. 
