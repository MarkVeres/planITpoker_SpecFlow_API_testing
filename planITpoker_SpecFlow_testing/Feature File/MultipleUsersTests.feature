Feature: MultipleUsersTests

Scenario: A second user joins the Game Room
	Given I log in via Quick Play as "John"
	And I create a Game Room named "Test Room"
	And a second user logs into the same Game Room as "Jack"
	When I ask for players information from getPlayersAndState
	Then I should see that the second user's name is "Jack"
