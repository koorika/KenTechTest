Feature: Users
	Since the JSONServer's PUTS and POSTS does not use any persistence mechanism for new data, we're stuck with the default data


Scenario: Count the users 
	When I request all users
	Then The response code is 200
	And The response has 10 users

Scenario: User data is sane
	When I request data on user 3 
	Then The response code is 200
	And The user data is user3.json

Scenario: Cannot create new users
	Given I create users from user1.json
	When I request data on user 11
	Then The response code is 404

Scenario: Create multiple users 
	Given I create multiple users from moreusers.json
	Then The response code is 201
	And The response has 2 users and id 11
