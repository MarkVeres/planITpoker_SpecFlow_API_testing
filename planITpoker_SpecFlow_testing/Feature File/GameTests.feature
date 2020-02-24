Feature: GameTests

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