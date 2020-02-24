Feature: MultipleUsersTests

Scenario: A second user joins the Game Room
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And a second user logs into the same Game Room as "Jack"
	When I ask for information from getPlayersAndState
	Then I should see that the second user's name is "Jack"

Scenario: Second user tries to create a story
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I create a story named "Test Story"
	And a second user logs into the same Game Room as "Jack"
	And Jack creates a story named "New User Story"
	When I ask for Story information
	Then i should see that Jack could not create a story, as there is only 1 story created

Scenario: Second user tries to start the game
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I create a story named "Test Story"
	And a second user logs into the same Game Room as "Jack"
	And Jack tries to start the game
	When I request Room information from GetPlayInfo
	Then I Should see that Jack was unable to start the game

Scenario: Second user votes
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I create a story named "Test Story"
	And a second user logs into the same Game Room as "Jack"
	And I start the game
	And Jack votes
	When I request Vote information from GetVoteInfo
	Then I should see that Jack has voted

Scenario: Second user tries to skip a story
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I create a story named "Test Story"
	And I create a story named "Second Test Story"
	And a second user logs into the same Game Room as "Jack"
	And I start the game
	And Jack tries to skip the current story
	When I request information about the current story
	Then I should see that the current story is still "Test Story"

Scenario: Second user tries to reset the in-game timer
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I create a story named "Test Story"
	And a second user logs into the same Game Room as "Jack"
	And I start the game and set the initial timer
	And Jack tries to reset the in-game timer
	When I set the second timer
	Then I should see that Jack could not reset the timer, because the two timers are identical

Scenario: Second user tries to reveal the cards
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I create a story named "Test Story"
	And a second user logs into the same Game Room as "Jack"
	And I start the game
	And Jack tries to reveal the cards
	When I request Vote information from GetVoteInfo
	Then I should see that my vote is null

Scenario: Second user tries to clear votes before the voting process ends
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I create a story named "Test Story"
	And a second user logs into the same Game Room as "Jack"
	And I start the game
	And I vote
	And Jack tries to clear the votes
	When I request Vote information from GetVoteInfo
	Then I Should see that my vote has not been cleared

Scenario: Second user tries to clear votes after the voting process ends
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I create a story named "Test Story"
	And a second user logs into the same Game Room as "Jack"
	And I start the game
	And I vote
	And I Finish voting
	And Jack tries to clear the votes
	When I request Vote information from GetVoteInfo
	Then I Should see that my vote has not been cleared

Scenario: Second user tries to end the voting process
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I create a story named "Test Story"
	And a second user logs into the same Game Room as "Jack"
	And I start the game
	And Jack tries to end the voting process
	When I ask for information from getPlayersAndState
	Then I should see that the voting process has not ended

Scenario: Second user tries to change the title of a story
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I create a story named "Test Story"
	And a second user logs into the same Game Room as "Jack"
	And Jack tries to change the title of the story to "Modified Test Story"
	When I ask for Story information
	Then I should see that the story name is still "Test Story"