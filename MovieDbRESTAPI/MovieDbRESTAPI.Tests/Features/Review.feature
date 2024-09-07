Feature: Review Resource

@GetAllReviews
Scenario: Get All Review
	Given I am a Client
	When I make GET Request to '<endpoint>'
	Then response code must be '<statusCode>'
	And response data must look like '<response>'

@ValidCases
Examples:
	| endpoint              | statusCode | response                                                                                                               |
	| /api/movies/1/Reviews | 200        | [ { "id": 1, "message": "Review 1 Movie 1", "movieId": 1 }, { "id": 2, "message": "Review 2 Movie 1", "movieId": 1 } ] |

@InvalidCases
Examples:
	| endpoint                | statusCode | response                                      |
	| /api/movies/555/Reviews | 404        | { "message": "Movie with Id 555 Not Found!" } |

@GetReviewById
Scenario: Get Review By Id
	Given I am a Client
	When I make GET Request to '<endpoint>'
	Then response code must be '<statusCode>'
	And response data must look like '<response>'

@ValidCases
Examples:
	| endpoint                | statusCode | response                                                 |
	| /api/movies/1/Reviews/1 | 200        | { "id": 1, "message": "Review 1 Movie 1", "movieId": 1 } |

@InvalidCases
Examples:
	| endpoint                  | statusCode | response                                       |
	| /api/movies/555/Reviews/1 | 404        | { "message": "Movie with Id 555 Not Found!" }  |
	| /api/movies/1/Reviews/555 | 404        | { "message": "Review with Id 555 Not Found!" } |

@CreateReview
Scenario: Create Review
	Given I am a Client
	When I make POST Request to '<endpoint>' with body '<requestBody>'
	Then response code must be '<statusCode>'
	And response data must look like '<response>'

@ValidCases
Examples:
	| endpoint              | requestBody                  | statusCode | response                                                 |
	| /api/movies/1/Reviews | { "message": "Test Review" } | 201        | { "data": 3, "message": "Review Created Successfully!" } |

@InvalidCases
Examples:
	| endpoint                | requestBody                  | statusCode | response                                                                        |
	| /api/movies/555/Reviews | { "message": "Test Review" } | 404       | { "message": "Movie with Id 555 Not Found!" }                                   |
	| /api/movies/1/Reviews   | { "message": "" }            | 400        | { "message": "Validation Error!", "errors": [ "Please Add Message Property" ] } |


@UpdateReview
Scenario: Update Review
	Given I am a Client
	When I make PUT Request to '<endpoint>' with requestBody '<requestBody>'
	Then response code must be '<statusCode>'
	And response data must look like '<response>'

@ValidCases
Examples:
	| endpoint                | requestBody                     | statusCode | response                                                              |
	| /api/movies/1/Reviews/1 | { "message": "Updated Review" } | 200        | { "data": 1, "message": "Review 1 of Movie 1 updated Successfully!" } |

@InvalidCases
Examples:
	| endpoint                  | requestBody                     | statusCode | response                                                                        |
	| /api/movies/555/Reviews/1 | { "message": "Updated Review" } | 404        | { "message": "Movie with Id 555 Not Found!" }                                   |
	| /api/movies/1/Reviews/555 | { "message": "Updated Review" } | 404        | { "message": "Review with Id 555 Not Found!" }                                  |
	| /api/movies/1/Reviews/1   | { "message": "" }               | 400        | { "message": "Validation Error!", "errors": [ "Please Add Message Property" ] } | 


@DeleteReview
Scenario: Delete Review
	Given I am a Client
	When I make DELETE Request to '<endpoint>'
	Then response code must be '<statusCode>'
	And response data must look like '<response>'

@ValidCases
Examples:
	| endpoint                | statusCode | response                                                              |
	| /api/movies/1/Reviews/1 | 200        | { "data": 1, "message": "Review 1 of movie 1 deleted Successfully!" } |

@InvalidCases
Examples:
	| endpoint                  | statusCode | response                                       |
	| /api/movies/555/Reviews/1 | 404        | { "message": "Movie with Id 555 Not Found!" }  |
	| /api/movies/1/Reviews/555 | 404        | { "message": "Review with Id 555 Not Found!" } | 
