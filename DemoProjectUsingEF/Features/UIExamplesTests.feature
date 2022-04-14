Feature: UIExamplesTests
	As user, I want to perfomr simle actions on the web site 

@smoke
Scenario: User sees search results
	Given User open web-site
	When User performs a search with 'супермен' value
	Then User should see results for 'супермен'

@smoke
Scenario: User sees a message that there are no search results
	Given User open web-site
	When User performs a search with 'superman' value
	Then User should see a message that there are no search results

@smoke
Scenario: User sees an error message if try to login with invalid data
	Given User open web-site
	When User click on 'ВХОД' buton on the side bar
	And User enters the following data
		| Username | Password |
		| admin    | 0000     |
	Then User sees an error message about invalid login
	When User enters the following data
         | Username | Password |
         |          |          |

Scenario Outline: User can select many movies sections
	Given User open web-site
	When User selects '<section>' on the home page
	Then User should see corresponding '<section>' results

	Examples:
		| section        |
		| ВЕСТЕРН        |
		| БИОГРАФИЯ      |
		| БОЕВИК         |
		| ВОЕННЫЙ        |
		| ДЕТЕКТИВ       |
		| ДРАМА          |
		| ДОКУМЕНТАЛЬНЫЙ |
		| ИСТОРИЯ        |
		| КОМЕДИЯ        |
		| КРИМИНАЛ       |
		| МЕЛОДРАМА      |
		| МУЗЫКА         |
		| МУЛЬТФИЛЬМ     |
		| ПРИКЛЮЧЕНИЯ    |
		| СЕМЕЙНЫЙ       |