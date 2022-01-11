@patient
Feature: Patient
	In order to add,edit,delete the patient records
	As a admin
	I want to get access to portal 

@addpatient @ignore
Scenario Outline: Add Patient Record
	Given I have browser with openemr page
	When I enter username as 'admin'
	And I enter password as 'pass'
	And I select language as 'English (Indian)'
	And I click on login
	And I click on patient client
	And I click on patient
	And I click on add new patient
	And I fill the form
		| firstname   | lastname   | dob   | gender   |
		| <firstname> | <lastname> | <dob> | <gender> |
	And I click on create new patient
	And I click on confirm create new patient
	And I store alert text and handle it
	And I handle happy birthday pop up if any
	Then I should verify the stored alert text as '<expectedalert>'
	And I should verify the patient detail as '<expectedvalue>'

	Examples:
	| firstname | lastname | dob        | gender | expectedalert | expectedvalue                        |
	| John      | Wick     | 2022-01-11 | Male   | New Due       | Medical Record Dashboard - John Wick |
	| Bala      | Dina     | 2022-01-11 | Male   | New Due       | Medical Record Dashboard - John Wick |