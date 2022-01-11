Feature: Demo
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers
[bala](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)

Link to a feature: [Calculator](OpenEMR/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**
***hello***
**hello**


@mytag
Scenario: Add two numbers
	Given the first number is 50
	And the second number is 70
	When I click on create new patient
	And the two numbers are added	
	Then the result should be 120