@login
Feature: Login
	In order to manage the hospital records 
	As a portal users
	I would to access the openemr dashboard 


Background: 
	Given I have browser with openemr page

@valid   @low  @ignore
Scenario Outline: Valid Credential
	When I enter username as '<username>'
	And I enter password as '<password>'
	And I select language as '<language>'
	And I click on login
	Then I should get access to portal with title as 'OpenEMR'

	Examples:
		| username  | password  | language         |
		| admin     | pass      | English (Indian) |
		| physician | physician | English (Indian) |

@invalid  @high
Scenario: Invalid Credential
	When I enter username as 'bala'
	And I enter password as 'bala123'
	And I select language as 'English (Indian)'
	And I click on login
	Then I should get error message as 'Invalid username or password'

