using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

// You will have to make sure that all the namespaces match
// between the different platform specific projects and the shared
// code files. This has to do with how we initialize the AppiumDriver
// through the AppiumSetup.cs files and NUnit SetUpFixture attributes.
// Also see: https://docs.nunit.org/articles/nunit/writing-tests/attributes/setupfixture.html
namespace UITests;

// This is an example of tests that do not need anything platform specific
public class MainPageTests : BaseTest
{
	[Test]
	public void AppLaunches()
	{
		// bug https://github.com/appium/dotnet-client/issues/798
		App.GetScreenshot().SaveAsFile($"{nameof(AppLaunches)}.png");
	}
	[Test]
	[Category("Test_Login_Success")]
	public void Test_Login_Success()
	{
		// Find UI elements
		var usernameField = FindUIElement("UsernameEntry");
		var passwordField = FindUIElement("PasswordEntry");
		var loginButton = FindUIElement("LoginButton");

		// Input credentials
		usernameField.SendKeys("usernametest" + "\n");
		Task.Delay(1000).Wait(); // Short delay to ensure UI readiness
		passwordField.SendKeys("passwordTest" + "\n");
		Task.Delay(1000).Wait(); // Optional delay before clicking the login button

		loginButton.Click();

		// Wait for navigation to complete (consider using a more reliable wait mechanism)
		Task.Delay(5000).Wait();

	}

}