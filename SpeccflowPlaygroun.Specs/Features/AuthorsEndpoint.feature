Feature: Author API

@TEST-001
Scenario: Send a request with Grisham as a surname
	Given the last name of an author is Grisham
	And the endpoint is /resources/authors
	When i send the GET request
	Then i should get OK response

@TEST-002
Scenario: Send a request whith no existing author
	When I send a rest request /resources/authors/{id} with no existing author
	Then I should get not found response