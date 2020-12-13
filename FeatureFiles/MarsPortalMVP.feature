Feature: MarsPortal
	

@mytag
Scenario: Verify user is able to sign in to the Mars Portal successfully

Given I can navigate to the Mars Portal
When I add user name and password to the sign in box and click login
Then I click Hi Denzel 
And Go to profile to edit my skills