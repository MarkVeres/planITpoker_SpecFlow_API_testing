Feature: LoginTests
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers


Scenario: User login by Quick Play
	Given I logged in by Quick Play as "John"
	And I created a Game Room named "Test Room"
	When I request Game Room information
	Then The name of the Game Room should be "Test Room"

Scenario: User loggs in with valid credentials
	Given I logged in using the following credentials "ggg@gggmail.com", "password123"
	And I created a Game Room named "Test Room"
	When I request Game Room information
	Then The name of the Game Room should be "Test Room"

Scenario: User registers an account and loggs in
	Given I create an account using the following credentials "gg@mail.com", "John", "password123"
	And I created a Game Room named "Test Room"
	When I request Game Room information
	Then The name of the Game Room should be "Test Room"
