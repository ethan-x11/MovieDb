Feature: Genre Resource

@GetAllGenres
Scenario: Get All Genre
	Given I am a Client
	When I make GET Request to '<endpoint>'
	Then response code must be '<statusCode>'
	And response data must look like '<response>'

Examples:
	| endpoint    | statusCode | response                                                              |
	| /api/genres | 200        | [ { "id": 1,"name": "Test Genre 1"},{"id": 2,"name": "Test Genre 2"}] |


@GetGenreById
Scenario: Get Genre By Id
	Given I am a Client
	When I make GET Request to '<endpoint>'
	Then response code must be '<statusCode>'
	And response data must look like '<response>'

@ValidCases
Examples:
	| endpoint      | statusCode | response                           |
	| /api/genres/1 | 200        | { "id": 1, "name": "Test Genre 1"} |

@InvalidCases
Examples:
	| endpoint        | statusCode | response                                      |
	| /api/genres/555 | 404        | { "message": "Genre with Id 555 Not Found!" } |


@CreateGenre
Scenario: Create Genre
	Given I am a Client
	When I make POST Request to '<endpoint>' with body '<requestBody>'
	Then response code must be '<statusCode>'
	And response data must look like '<response>'

@ValidCases
Examples:
	| endpoint    | requestBody             | statusCode | response                                           |
	| /api/genres | {"name":"Test Genre 3"} | 201        | {"data":3,"message":"Genre Created Successfully!"} |

@InvalidCases
Examples:
	| endpoint    | requestBody | statusCode | response                                                                |
	| /api/genres | {"name":""} | 400        | { "message":"Validation Error!","errors": ["Please Add Name Property"] } |
	

@UpdateGenre
Scenario: Update Genre
	Given I am a Client
	When I make PUT Request to '<endpoint>' with requestBody '<requestBody>'
	Then response code must be '<statusCode>'
	And response data must look like '<response>'

@ValidCases
Examples:
	| endpoint      | requestBody                  | statusCode | response                                                  |
	| /api/genres/1 | {"name":"Updated Test Name"} | 200        | { "data": 1, "message": "Genre 1 Updated Successfully!" } |

@InvalidCases
Examples:
	| endpoint        | requestBody                  | statusCode | response                                                                 |
	| /api/genres/555 | {"name":"Updated Test Name"} | 404        | { "message": "Genre with Id 555 Not Found!" }                            |
	| /api/genres/1   | {"name":""}                  | 400        | { "message": "Validation Error!","errors": ["Please Add Name Property"] } |
	

@DeleteGenre
Scenario: Delete Genre
	Given I am a Client
	When I make DELETE Request to '<endpoint>'
	Then response code must be '<statusCode>'
	And response data must look like '<response>'

@ValidCases
Examples:
	| endpoint      | statusCode | response                                                  |
	| /api/genres/1 | 200        | { "data": 1, "message": "Genre 1 Deleted Successfully!" } |

@InvalidCases
Examples:
	| endpoint        | statusCode | response                                      |
	| /api/genres/555 | 404        | { "message": "Genre with Id 555 Not Found!" } |