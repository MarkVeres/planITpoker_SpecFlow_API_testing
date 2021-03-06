﻿Feature: GameTests

Scenario: Moderator creates a story
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

Scenario: Moderator changes the title of a story before game starts
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

Scenario: Moderator submits an estimate
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I create a story named "Test Story"
	And I start the game
	And I vote
	And I Finish voting
	When I request story estimate information
	Then I should see that my estimate is 3

Scenario: Moderator changes the title of a story after game starts
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I create a story named "Test Story"
	And I start the game
	And I change the title of the story to "Modified Test Story"
	When I request story information
	Then I should see that the story is named "Modified Test Story"

Scenario: Moderator changes the title of a story after he votes
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I create a story named "Test Story"
	And I start the game
	And I vote
	And I change the title of the story to "Modified Test Story"
	When I request story information
	Then I should see that the story is named "Modified Test Story"

Scenario: Moderator skips a story
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I create a story named "Test Story"
	And I create a story named "Second Test Story"
	And I start the game
	And I skip the current story
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
	Then I should see that the voting step has ended

Scenario: Moderator Reveals cards
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I create a story named "Test Story"
	And I start the game
	And I reveal the cards
	When I request Vote information
	Then I Should see that the vote value is -1

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

Scenario: Moderator adds a new story after voting ends on the first story
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

Scenario: Moderator Resets the Game timer
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I create a story named "Test Story"
	And I create a story named "Second Test Story"
	And I start the game
	And I set the initial timer
	And I reset the Game Timer
	When I set the second Timer
	Then I should see that the two timers are different

Scenario: Moderator deletes a story
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I create a story named "Test Story"
	And I delete a story
	When I request information from getStoryState
	Then I should see that there are no stories created

Scenario: Moderator changes his estimate
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I create a story named "Test Story"
	And I start the game
	And I vote
	And I Finish voting
	And I change my estimate
	When I request story estimate information
	Then I should see that my estimate has changed

Scenario: Moderator generates a report of the Game
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I create a story named "Test Story"
	And I start the game
	And I vote
	And I Finish voting
	When I generate a report of the Game
	Then I should see the user name "John" and the story title "Test Story" within that report

Scenario: Moderator starts the game with no stories created
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I start the game
	When I request Game information from getPlayInfo
	Then I should see that the game has not started

Scenario: Moderator tries to vote before the game has started
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I create a story named "Test Story"
	And I vote
	When I request Game information from getPlayInfo
	Then I should see that there are no votes submitted

Scenario: Moderator tries to vote in a game that has no stories
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I start the game
	And I vote
	When I request Game information from getPlayInfo
	Then I should see that there are no votes submitted

Scenario: Moderator tries to create a story in a room that does not allow story creation
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room" that cannot have stories
	And I create a story named "Test Story"
	When I request Game information from getPlayInfo
	Then I should see that there are no stories created

Scenario: Moderator tries to skip stories before the game starts
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I create a story named "Test Story"
	And I create a story named "Second Test Story"
	And I skip the current story
	And I start the game
	When I request Current Story Information
	Then I Should see that the Current Story is named "Test Story"

Scenario: Moderator tries to reveal votes before game starts
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I create a story named "Test Story"
	And I reveal the cards	
	When I request player information from getPlayInfo
	Then I should see that my vote is still null

Scenario: Moderator tries to reveal votes after voting
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I create a story named "Test Story"
	And I start the game
	And I vote
	And I reveal the cards	
	When I request player information from getPlayInfo
	Then I Should see that the vote value is not -1

Scenario: Moderator tries to end the voting process before the game starts
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I create a story named "Test Story"
	And I Finish voting
	When I request Game information from getPlayersAndState
	Then I should see that the voting had not been ended

Scenario: Moderator tries to send an estimate before the game starts
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I create a story named "Test Story"
	And I Finish voting
	When I request story estimate information
	Then I should see that my estimate is null

Scenario: Moderator tries to send an estimate after the game starts, but without submitting a vote
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I create a story named "Test Story"
	And I start the game
	And I Finish voting
	When I request story estimate information
	Then I should see that my estimate is null

Scenario: Moderator changes his role from player to observer
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I change my role to observer
	When I request Game information from getPlayersAndState
	Then I should see that my role has been changed to observer

Scenario: Moderator tries to add a story while in the role of observer
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I change my role to observer
	And I create a story named "Test Story"
	When I request story information
	Then I should see that there are no stories created

Scenario: Moderator tries to vote while in the role of observer
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I create a story named "Test Story"
	And I change my role to observer
	And I start the game
	And I vote
	When I request Vote information
	Then I should see that my vote is still null

Scenario: Moderator tries to send an estimate, without having submitted a vote, while in the role of observer
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I create a story named "Test Story"
	And I change my role to observer
	And I start the game
	And I Finish voting
	When I request story estimate information
	Then I should see that my estimate is 3

Scenario: Moderator tries to edit the game room to add a countdown timer, as observer
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I change my role to observer
	And I edit the Game Room to have a countdown timer
	When I request Room List information
	Then I should see that now, my Room has a countdown timer