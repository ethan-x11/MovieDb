Feature: Actor Resource

@GetAllActors
Scenario: Get All Actor
	Given I am a Client
	When I make GET Request to '<endpoint>'
	Then response code must be '<statusCode>'
	And response data must look like '<response>'

Examples:
	| endpoint    | statusCode | response                                                                                                                                                                                            |
	| /api/actors | 200        | [ { "id": 1,"name": "Test Actor 1","gender": "M","dob": "1965-04-04T00:00:00","bio": "Test Bio 1"},{"id": 2,"name": "Test Actor 2","gender": "M","dob": "1981-06-13T00:00:00","bio": "Test Bio 2"}] |


@GetActorById
Scenario: Get Actor By Id
	Given I am a Client
	When I make GET Request to '<endpoint>'
	Then response code must be '<statusCode>'
	And response data must look like '<response>'

@ValidCases
Examples:
	| endpoint      | statusCode | response                                                                                              |
	| /api/actors/1 | 200        | { "id": 1, "name": "Test Actor 1", "gender": "M", "dob": "1965-04-04T00:00:00", "bio": "Test Bio 1" } |

@InvalidCases
Examples:
	| endpoint        | statusCode | response                                      |
	| /api/actors/555 | 404        | { "message": "Actor with Id 555 Not Found!" } |


@CreateActor
Scenario: Create Actor
	Given I am a Client
	When I make POST Request to '<endpoint>' with body '<requestBody>'
	Then response code must be '<statusCode>'
	And response data must look like '<response>'

@ValidCases
Examples:
	| endpoint    | requestBody                                                                | statusCode | response                                           |
	| /api/actors | {"name":"Test Actor 3","gender":"M","dob":"2000-05-23","bio":"Test Bio 4"} | 201        | {"data":3,"message":"Actor Created Successfully!"} |

@InvalidCases
Examples:
	| endpoint    | requestBody                                                           | statusCode | response                                                                                                            |
	| /api/actors | {"name":"","gender":"O","dob":"2024-05-23","bio":"test bio"}          | 400        | { "message":"Validation Error!","errors": ["Please Add Name Property"] }                                             |
	| /api/actors | {"name":"Test Name","gender":"","dob":"2024-05-23","bio":"test bio"}  | 400        | { "message":"Validation Error!","errors": ["Please Add Gender Property"] }                                           |
	| /api/actors | {"name":"Test Name","gender":"M","dob":"","bio":"test bio"}           | 400        | { "message":"Validation Error!","errors": ["Please Add DOB Property"] }                                              |
	| /api/actors | {"name":"Test Name","gender":"Q","dob":"2024-05-23","bio":"Test Bio"} | 400        | { "message": "Validation Error!", "errors": [ "The field Gender must match the regular expression '^[MFOmfo]$'." ] } |


@UpdateActor
Scenario: Update Actor
	Given I am a Client
	When I make PUT Request to '<endpoint>' with requestBody '<requestBody>'
	Then response code must be '<statusCode>'
	And response data must look like '<response>'

@ValidCases
Examples:
	| endpoint      | requestBody                                                                            | statusCode | response                                                  |
	| /api/actors/1 | {"name":"Updated Test Name","gender":"M","dob": "2024-05-23","bio":"Updated Test Bio"} | 200        | { "data": 1, "message": "Actor 1 Updated Successfully!" } |

@InvalidCases
Examples:
	| endpoint        | requestBody                                                                           | statusCode | response                                                                                                            |
	| /api/actors/555 | {"name":"Updated Test Name","gender":"M","dob":"2024-05-23","bio":"Updated Test Bio"} | 404        | { "message": "Actor with Id 555 Not Found!" }                                                                       |
	| /api/actors/1   | {"name":"","gender":"O","dob":"2024-05-23","bio":"test bio"}                          | 400        | { "message": "Validation Error!","errors": ["Please Add Name Property"] }                                            |
	| /api/actors/1   | {"name":"Test Name","gender":"","dob":"2024-05-23","bio":"test bio"}                  | 400        | { "message": "Validation Error!","errors": ["Please Add Gender Property"] }                                          |
	| /api/actors/1   | {"name":"Test Name","gender":"M","dob":"","bio":"test bio"}                           | 400        | { "message": "Validation Error!","errors": ["Please Add DOB Property"] }                                             |
	| /api/actors/1   | {"name":"Test Name","gender":"Q","dob":"2024-05-23","bio":"Test Bio"}                 | 400        | { "message": "Validation Error!", "errors": [ "The field Gender must match the regular expression '^[MFOmfo]$'." ] } |


@DeleteActor
Scenario: Delete Actor
	Given I am a Client
	When I make DELETE Request to '<endpoint>'
	Then response code must be '<statusCode>'
	And response data must look like '<response>'

@ValidCases
Examples:
	| endpoint      | statusCode | response                                                  |
	| /api/actors/1 | 200        | { "data": 1, "message": "Actor 1 Deleted Successfully!" } |

@InvalidCases
Examples:
	| endpoint        | statusCode | response                                      |
	| /api/actors/555 | 404        | { "message": "Actor with Id 555 Not Found!" } |