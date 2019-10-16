Feature: RottenTomatoes
	
Background: 
	Given I navigate to https://www.rottentomatoes.com/browse/top-dvd-streaming

@TestRail @ID=C1
Scenario: Tomatometer set to 90%
	When I move the tomatometer slider to 90%
	Then All movies in the page have a rating of at least 90%

@TestRail @ID=C2
Scenario: Certified filtering
	When I check the Certified filter
	Then All movies in the page have a rating of at least 70%

@TestRail @ID=C3
Scenario: Navigation retains the settings
	Given I set Sort by filter to Tomatometer
	And I set Genre filter to Sci-fi & Fantasy
	#And I move the tomatometer slider to 80%
	And I set Providers filter to FandangoNow
	When I click the first movie
	And I navigate back
	Then The Sort by filter is Tomatometer
	And The Genre filter is Sci-fi & Fantasy
	#And The Tomatometer slider is 80%
	And The Providers filter is FandangoNow