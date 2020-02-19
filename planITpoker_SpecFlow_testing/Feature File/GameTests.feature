﻿Feature: GameTests

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

Scenario: Moderator changes the title of a story
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I create a story named "Test Story"
	And I change the title of the story to "Modified Test Story"
	When I request story information
	Then I should see that the story is named "Modified Test Story"

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

Scenario: Moderator skips a story
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I create a story named "Test Story"
	And I create a story named "Second Test Story"
	And I start the game
	And I skip the current story
	And I proceed to the next story
	When I request Current Story Information
	Then I Should see that the Current Story is named "Second Test Story"

Scenario: Moderator ends the voting process
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I create a story named "Test Story"
	And I start the game
	And I vote
	And I Finish voting
	When I request Game information from getPlayersAndState
	Then I should see that the voting has finished

Scenario: Moderator Reveals cards
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I create a story named "Test Story"
	And I start the game
	And I reveal the cards
	When I request Vote information
	Then I Should see that the vote values is -1

Scenario: Moderator clears votes before voting step ends
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I create a story named "Test Story"
	And I start the game
	And I vote
	And I clear the votes
	When I request Game information from getPlayersAndState
	Then I should see that my vote has been cleared

Scenario: Moderator clears votes after voting step ends
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I create a story named "Test Story"
	And I start the game
	And I vote
	And I Finish voting
	And I clear the votes
	When I request Game information from getPlayersAndState
	Then I should see that my vote has been cleared

Scenario: Add a new story after voting ends on the first story
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I create a story named "Test Story"
	And I create a story named "Second Test Story"
	And I start the game
	And I vote
	And I Finish voting
	And I create a story named "Third Test Story"
	When I request story information
	Then I should see that the "Third Test Story" is in the story list