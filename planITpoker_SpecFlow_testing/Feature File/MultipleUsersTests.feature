Feature: MultipleUsersTests

Scenario: A second user joins the Game Room
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And a second user logs into the same Game Room as "Jack"
	When I ask for information from getPlayersAndState
	Then I should see that the second user's name is "Jack"

Scenario: Moderator removes second user from the room
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And a second user logs into the same Game Room as "Jack"
	And I remove Jack from the game room
	When I request Room information from GetPlayInfo
	Then I should see that there is only 1 user in the room

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

Scenario: Second user tries to submit an estimate
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I create a story named "Test Story"
	And a second user logs into the same Game Room as "Jack"
	And I start the game
	And Jack submits an estimate
	When I request information about story estimates
	Then I should see that Jack has no estimate submitted

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

Scenario: Second user tries to change the title of a story before the game starts
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I create a story named "Test Story"
	And a second user logs into the same Game Room as "Jack"
	And Jack tries to change the title of the story to "Modified Test Story"
	When I ask for Story information
	Then I should see that the story name is still "Test Story"

Scenario: Second user tries to change the title of a story after the game starts
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I create a story named "Test Story"
	And a second user logs into the same Game Room as "Jack"
	And I start the game
	And Jack tries to change the title of the story to "Modified Test Story"
	When I ask for Story information
	Then I should see that the story name is still "Test Story"

Scenario: Second user tries to change the title of a story after he votes
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I create a story named "Test Story"
	And a second user logs into the same Game Room as "Jack"
	And I start the game
	And Jack votes
	And Jack tries to change the title of the story to "Modified Test Story"
	When I ask for Story information
	Then I should see that the story name is still "Test Story"

Scenario: Second user tries to start a game that has no stories created
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room" that cannot have stories
	And a second user logs into the same Game Room as "Jack"
	And Jack tries to start the game
	When I request Room information from GetPlayInfo
	Then I Should see that Jack was unable to start the game

Scenario: Second user tries to create a story in a room that does not allow story creation
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room" that cannot have stories	
	And a second user logs into the same Game Room as "Jack"
	And Jack creates a story named "New User Story"
	When I request Room information from GetPlayInfo
	Then I should see that there are no stories in this room

Scenario: Second user tries to skip stories before the game starts
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I create a story named "Test Story"
	And I create a story named "Second Test Story"
	And a second user logs into the same Game Room as "Jack"
	And Jack tries to skip the current story
	And I start the game
	When I request information about the current story
	Then I should see that the current story is still "Test Story"

Scenario: Second user tries to reveal cards before the game starts
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I create a story named "Test Story"
	And a second user logs into the same Game Room as "Jack"
	And Jack tries to reveal the cards
	When I request Room information from GetPlayInfo
	Then I should see that my vote is null

Scenario: Second user tries to end the voting process before the game starts
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I create a story named "Test Story"
	And a second user logs into the same Game Room as "Jack"
	And Jack tries to end the voting process
	When I ask for information from getPlayersAndState
	Then I should see that the voting process has not ended

Scenario: Second user tries to send an estimate before game starts
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I create a story named "Test Story"
	And a second user logs into the same Game Room as "Jack"
	And Jack tries to end the voting process
	When I request information about story estimates
	Then I should see that Jack has no estimate submitted

Scenario: Second user tries to send an estimate after the game has started, but without having submitted a vote
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I create a story named "Test Story"
	And a second user logs into the same Game Room as "Jack"
	And I start the game
	And Jack tries to end the voting process
	When I request information about story estimates
	Then I should see that Jack has no estimate submitted

Scenario: Moderator assigns second user as observer
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And a second user logs into the same Game Room as "Jack"
	And I assign Jack as observer
	When I ask for information from getPlayersAndState
	Then I should see that Jack has the role of observer

Scenario: Second User tries to create story, as observer
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And a second user logs into the same Game Room as "Jack"
	And I assign Jack as observer
	And Jack creates a story named "New User Story"
	When I request Room information from GetPlayInfo
	Then I should see that there are no stories in this room

Scenario: Second User tries to start the game, as observer
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And a second user logs into the same Game Room as "Jack"
	And I assign Jack as observer
	And Jack tries to start the game
	When I request Room information from GetPlayInfo
	Then I Should see that Jack was unable to start the game

Scenario: Second user tries to vote, as observer
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And I create a story named "Test Story"
	And a second user logs into the same Game Room as "Jack"
	And I assign Jack as observer
	And I start the game
	And Jack votes
	When I request Room information from GetPlayInfo
	Then I should see that there are nobody has voted
