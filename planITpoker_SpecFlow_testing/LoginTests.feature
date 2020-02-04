Feature: LoginTests

@fact
Scenario: QuickPlayLogin
	Given I have logged in via QuickPlay as "John"
	And I create a Game Room named "Test Room"
	When I request Game Room information
	Then The Room name should be "Test Room"
