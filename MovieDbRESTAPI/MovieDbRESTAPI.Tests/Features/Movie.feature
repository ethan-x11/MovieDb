Feature: Movie Resource

@GetAllMovies
Scenario: Get All Movie
	Given I am a Client
	When I make GET Request to '<endpoint>'
	Then response code must be '<statusCode>'
	And response data must look like '<response>'

Examples:
	| endpoint    | statusCode | response                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            |
	| /api/movies | 200        | [{ "id": 1, "title": "Test Movie 1", "yearOfRelease": 2000, "plot": "Test Plot 1", "producer": { "id": 1,"name": "Test Producer 1","gender": "M","dob": "1965-04-04T00:00:00","bio": "Test Bio 1"}, "poster": "Test Poster 1", "language": "English", "profit": 1000, "actors": [ { "id": 1,"name": "Test Actor 1","gender": "M","dob": "1965-04-04T00:00:00","bio": "Test Bio 1"},{"id": 2,"name": "Test Actor 2","gender": "M","dob": "1981-06-13T00:00:00","bio": "Test Bio 2"} ], "genres": [ { "id": 1,"name": "Test Genre 1"},{"id": 2,"name": "Test Genre 2"} ] }, { "id": 2, "title": "Test Movie 2", "yearOfRelease": 2000, "plot": "Test Plot 2", "producer": { "id": 1,"name": "Test Producer 1","gender": "M","dob": "1965-04-04T00:00:00","bio": "Test Bio 1"}, "poster": "Test Poster 2", "language": "English", "profit": 1000, "actors": [ { "id": 1,"name": "Test Actor 1","gender": "M","dob": "1965-04-04T00:00:00","bio": "Test Bio 1"},{"id": 2,"name": "Test Actor 2","gender": "M","dob": "1981-06-13T00:00:00","bio": "Test Bio 2"} ], "genres": [ { "id": 1,"name": "Test Genre 1"},{"id": 2,"name": "Test Genre 2"} ] } ] |


@GetMovieById
Scenario: Get Movie By Id
	Given I am a Client
	When I make GET Request to '<endpoint>'
	Then response code must be '<statusCode>'
	And response data must look like '<response>'

@ValidCases
Examples:
	| endpoint      | statusCode | response                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                |
	| /api/movies/1 | 200        | { "id": 1, "title": "Test Movie 1", "yearOfRelease": 2000, "plot": "Test Plot 1", "producer": { "id": 1,"name": "Test Producer 1","gender": "M","dob": "1965-04-04T00:00:00","bio": "Test Bio 1"}, "poster": "Test Poster 1", "language": "English", "profit": 1000, "actors": [ { "id": 1,"name": "Test Actor 1","gender": "M","dob": "1965-04-04T00:00:00","bio": "Test Bio 1"},{"id": 2,"name": "Test Actor 2","gender": "M","dob": "1981-06-13T00:00:00","bio": "Test Bio 2"} ], "genres": [ { "id": 1,"name": "Test Genre 1"},{"id": 2,"name": "Test Genre 2"} ] } |

@InvalidCases
Examples:
	| endpoint        | statusCode | response                                      |
	| /api/movies/555 | 404        | { "message": "Movie with Id 555 Not Found!" } |


@CreateMovie
Scenario: Create Movie
	Given I am a Client
	When I make POST Request to '<endpoint>' with body '<requestBody>'
	Then response code must be '<statusCode>'
	And response data must look like '<response>'

@ValidCases
Examples:
	| endpoint    | requestBody                                                                                                                                                                                            | statusCode | response                                           |
	| /api/movies | { "title": "Test Movie 3", "yearOfRelease": 2000, "plot": "Test Plot 3", "producerId": 1, "poster": "Test Poster 3", "language": "English", "profit": 1000, "actorIds": [ 1,2 ], "genreIds": [ 1,2 ] } | 201        | {"data":3,"message":"Movie Created Successfully!"} |

@InvalidCases
Examples:
	| endpoint    | requestBody                                                                                                                                                                                        | statusCode | response                                                                      |
	| /api/movies | { "title": "", "yearOfRelease": 2000, "plot": "Test Plot", "producerId": 1, "poster": "Test Poster", "language": "English", "profit": 1000, "actorIds": [ 1,2 ], "genreIds": [ 1,2 ] }             | 400        | { "message": "Validation Error!", "errors": [ "Please Add Title Property" ] } |
	| /api/movies | { "title": "Test Movie", "yearOfRelease": -1000, "plot": "Test Plot", "producerId": 1, "poster": "Test Poster", "language": "English", "profit": 1000, "actorIds": [ 1,2 ], "genreIds": [ 1,2 ] }  | 400        | { "message": "Invalid Year!" }                                                |
	| /api/movies | { "title": "Test Movie", "yearOfRelease": 3000, "plot": "Test Plot", "producerId": 1, "poster": "Test Poster", "language": "English", "profit": 1000, "actorIds": [ 1,2 ], "genreIds": [ 1,2 ] }   | 400        | { "message": "Invalid Year!" }                                                |
	| /api/movies | { "title": "Test Movie", "yearOfRelease": 2000, "plot": "Test Plot", "producerId": 555, "poster": "Test Poster", "language": "English", "profit": 1000, "actorIds": [ 1,2 ], "genreIds": [ 1,2 ] } | 400        | { "message": "Invalid Producer Id!" }                                         |
	| /api/movies | { "title": "Test Movie", "yearOfRelease": 2000, "plot": "Test Plot", "producerId": 1, "poster": "Test Poster", "language": "English", "profit": 1000, "actorIds": [ 1,200 ], "genreIds": [ 1,2 ] } | 400        | { "message": "Invalid Actor Id!" }                                            |
	| /api/movies | { "title": "Test Movie", "yearOfRelease": 2000, "plot": "Test Plot", "producerId": 1, "poster": "Test Poster", "language": "English", "profit": 1000, "actorIds": [ 1,2 ], "genreIds": [ 1,200 ] } | 400        | { "message": "Invalid Genre Id!" }                                            |


@UpdateMovie
Scenario: Update Movie
	Given I am a Client
	When I make PUT Request to '<endpoint>' with requestBody '<requestBody>'
	Then response code must be '<statusCode>'
	And response data must look like '<response>'

@ValidCases
Examples:
	| endpoint      | requestBody                                                                                                                                                                                                                    | statusCode | response                                                  |
	| /api/movies/1 | { "title": "Updated Test Movie 1", "yearOfRelease": 2000, "plot": "Updated Test Plot 1", "producerId": 1, "poster": "Updated Test Poster 1", "language": "English", "profit": 1000, "actorIds": [ 1,2 ], "genreIds": [ 1,2 ] } | 200        | { "data": 1, "message": "Movie 1 Updated Successfully!" } |

@InvalidCases
Examples:
	| endpoint        | requestBody                                                                                                                                                                                                              | statusCode | response                                                                      |
	| /api/movies/555 | { "title": "Updated Test Movie", "yearOfRelease": 2000, "plot": "Updated Test Plot", "producerId": 1, "poster": "Updated Test Poster", "language": "English", "profit": 1000, "actorIds": [ 1,2 ], "genreIds": [ 1,2 ] } | 404        | { "message": "Movie with Id 555 Not Found!" }                                 |
	| /api/movies/1   | { "title": "", "yearOfRelease": 2000, "plot": "Test Plot", "producerId": 1, "poster": "Test Poster", "language": "English", "profit": 1000, "actorIds": [ 1,2 ], "genreIds": [ 1,2 ] }                                   | 400        | { "message": "Validation Error!", "errors": [ "Please Add Title Property" ] } |
	| /api/movies/1   | { "title": "Test Movie", "yearOfRelease": -1000, "plot": "Test Plot", "producerId": 1, "poster": "Test Poster", "language": "English", "profit": 1000, "actorIds": [ 1,2 ], "genreIds": [ 1,2 ] }                        | 400        | { "message": "Invalid Year!" }                                                |
	| /api/movies/1   | { "title": "Test Movie", "yearOfRelease": 3000, "plot": "Test Plot", "producerId": 1, "poster": "Test Poster", "language": "English", "profit": 1000, "actorIds": [ 1,2 ], "genreIds": [ 1,2 ] }                         | 400        | { "message": "Invalid Year!" }                                                |
	| /api/movies/1   | { "title": "Test Movie", "yearOfRelease": 2000, "plot": "Test Plot", "producerId": 555, "poster": "Test Poster", "language": "English", "profit": 1000, "actorIds": [ 1,2 ], "genreIds": [ 1,2 ] }                       | 400        | { "message": "Invalid Producer Id!" }                                         |
	| /api/movies/1   | { "title": "Test Movie", "yearOfRelease": 2000, "plot": "Test Plot", "producerId": 1, "poster": "Test Poster", "language": "English", "profit": 1000, "actorIds": [ 1,200 ], "genreIds": [ 1,2 ] }                       | 400        | { "message": "Invalid Actor Id!" }                                            |
	| /api/movies/1   | { "title": "Test Movie", "yearOfRelease": 2000, "plot": "Test Plot", "producerId": 1, "poster": "Test Poster", "language": "English", "profit": 1000, "actorIds": [ 1,2 ], "genreIds": [ 1,200 ] }                       | 400        | { "message": "Invalid Genre Id!" }                                            |


@DeleteMovie
Scenario: Delete Movie
	Given I am a Client
	When I make DELETE Request to '<endpoint>'
	Then response code must be '<statusCode>'
	And response data must look like '<response>'

@ValidCases
Examples:
	| endpoint      | statusCode | response                                                  |
	| /api/movies/1 | 200        | { "data": 1, "message": "Movie 1 Deleted Successfully!" } |

@InvalidCases
Examples:
	| endpoint        | statusCode | response                                      |
	| /api/movies/555 | 404        | { "message": "Movie with Id 555 Not Found!" } |