﻿Feature: RoomCreationTests

Scenario: Create a Game Room that cannot have stories
	Given I log in by Quick Play as "John"
	And I create a Game Room named "Test Room" that cannot have stories
	When I request information regarding the Game Room
	Then I should see that I am unable to add stories to the Game Room

Scenario: Create a Game Room in which you can skip stories without having to give confirmation
	Given I log in by Quick Play as "John"
	And I create a Game Room named "Test Room" in which skipping stories does not require confirmation
	When I request information regarding the Game Room
	Then I should see that I do not have to give confirmation for skipping stories

Scenario: Create a Game Room in which the Observer user cannot see the votes during the voting process
	Given I log in by Quick Play as "John"
	And I create a Game Room named "Test Room" in which the observer cannot see the votes during the voting process
	When I request information regarding the Game Room
	Then I should see that the observer is unable to see the votes during the voting process

Scenario: Create a Game Room in which the the votes are revealed automatically when voting ends
	Given I log in by Quick Play as ""John"
	And I create a Game Room named "Test Room" that automatically reveals votes at the end of the voting process
	When I request information regarding the Game Room
	Then I should see that the votes will be revealed automatically

Scenario: Create a Game Room in which changing votes is permitted
	Given I log in by Quick Play as ""John"
	And I create a Game Room named "Test Room" in which changing votes is permitted
	When I request information regarding the Game Room
	Then I should see that changing votes, after voting, is permitted

Scenario: Create a Game Room that uses a countdown timer
	Given I log in by Quick Play as ""John"
	And I create a Game Room named "Test Room" that uses a countdowntimer
	When I request information regarding the Game Room
	Then I should see that the Game Room has a countdowntimer