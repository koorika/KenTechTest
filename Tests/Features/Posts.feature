Feature: Posts 

Scenario: Get All Posts
	When I request all posts
	Then The response code is 200
	And The response has 100 posts

Scenario: Get a post 
	When I request post 1
	Then The response code is 200
	And The post data is post1.json

Scenario: Cannot persist posts
	Given I create post 101 from post101.json
	When I request post 101
	Then The response code is 404

Scenario: Posts creation is accepted for existing users
	Given I create post 101 from newpost.json
	Then The response code is 201

Scenario: Posts creation is accepted for non-existing users
	Given I create post 101 from badpost.json
	Then The response code is 201

Scenario: Posts creation is accepted without a body
	Given I create post 101 from emptypost.json
	Then The response code is 201

Scenario: Posts editing is accepted without a body
	Given I edit post 100 from emptypost.json
	Then The response code is 200

Scenario: Posts editing is accepted for exising posts
	Given I edit post 100 from newpost.json
	Then The response code is 200

Scenario: Posts editing for non-exising posts throws error 
	Given I edit post 101 from newpost.json
	Then The response code is 500

Scenario: Delete a post
	Given I delete post 87
	Then The response code is 200

Scenario: Deleting all posts is refused
	Given I delete all posts
	Then The response code is 404