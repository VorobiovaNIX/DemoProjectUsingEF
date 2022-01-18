Feature: DatabaseFirstApproach
In order to Login to Hub
	As a Hub user 
	I want to check user creation 

Background:
	Given Clean up Hub DB

@case=2
Scenario: Log in to HUB with correct details
	Given I navigate to HUB url
	And I am redirected to IMS Log in page
	When I log in with correct username and password
	Then I am redirected to HUB Dashboard