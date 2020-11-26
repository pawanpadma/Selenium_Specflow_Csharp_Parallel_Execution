Feature: Loginntest cases
	
@smoke
Scenario: Verify Invalid Login
	Given I provide invalid credentials
	| email					 | password|
	| meenalkuber1@gmail.com |Try	   |
	| meenalkuber1@gmail.com |Try	   |
	| meenalkuber1@gmail.com |Try	   |
	When I submit the login form
	Then "Invalid password." message should be displayed

	@smoke
Scenario: Verify Invalid Loginn
	Given I provide invalid credentials
	| email					 | password|
	| meenalkuber1@gmail.com |Try	   |
	| meenalkuber1@gmail.com |Try	   |
	| meenalkuber1@gmail.com |Try	   |
	When I submit the login form
	Then "Invalid password." message should be displayed