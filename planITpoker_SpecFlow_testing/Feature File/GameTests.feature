Feature: GameTests

Scenario: User creates a story
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I create a story named "Test Story"
	When I request story information
	Then I should see that the story is named "Test Story"

Scenario: User that creates the Game Room should be assigned Moderator
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	When I request Game information from getPlayInfo
	Then I should see that the moderator is connected

Scenario: Moderator starts the Game
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I create a story named "Test Story"
	And I start the game
	When I request Game information from getPlayersAndState
	Then I should see that the game has started

Scenario: Moderator votes
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I create a story named "Test Story"
	And I start the game
	And I vote
	When I request Vote information
	Then I should see that I have voted
