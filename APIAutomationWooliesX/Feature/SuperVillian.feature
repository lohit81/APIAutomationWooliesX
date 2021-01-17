Feature: SuperVillian
	In order to avoid silly mistakes
	As a User
	I want to be able to add, update and view lists of users

Background: 
	Given I have url with endpoint /endpoint/

Scenario: To fetch all listed users using GET method
	#Given I have GET endpoint /getEndPoint/
	When I call get method of API
	Then I will get the response

	
Scenario Outline: : Add resources using POST method with username and Score
	#Given I have POST endpoint /postEndpoint/
	When I call POST method of API using <username> and <score>
	Then I will get the response after POST

	Examples: User Information
	| username | score |
	| David    | 478     |


# I created PUT scenario just for test purpose
# otherwise POST method can be used for creating a resourec then additional steps to alter resource fields using PUT verbs

Scenario Outline: : Add and Update resources using PUT method with username and Score
	When I call PUT method of API using <username> and <score>
	Then I will get the response after PUT

	Examples: User Information
	| username | score |
	| OnePlus    | 1234     |