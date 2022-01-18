Feature: Code first approach in the Database

Background:
	Given I clean up the Users table in the local DB

@case=1
Scenario: Add new user to the database
	Given I add 'Alena' user where '28' is age and '1' is Id
	And I add 'Vasya' user where '23' is age and '2' is Id