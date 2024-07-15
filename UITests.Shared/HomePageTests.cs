using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android.UiAutomator;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace UITests
{
    public class HomePageTests : BaseTest
    {
        [Test]
        [Category("Test_Home_Move_Tab")]
        public void Test_Home_Move_Tab()
        {
            Console.WriteLine("Test_Home_Move_Tab");
            var usernameField = FindUIElement("UsernameEntry");
            usernameField.SendKeys("usernametest" + "\n");
            Task.Delay(1000).Wait();
            Console.WriteLine(usernameField.Text);

            var passwordField = FindUIElement("PasswordEntry");
            passwordField.SendKeys("passwordTest" + "\n");
            Task.Delay(1000).Wait();
            Console.WriteLine(passwordField.Text);

            var loginButton = FindUIElement("LoginButton");
            loginButton.Click();
            Task.Delay(2000).Wait();
            var tabSecond = FindUIElement("TabSecond");
            tabSecond.Click();
            Task.Delay(2000).Wait();
            var lbSecond = FindUIElement("lbSecond");
            Assert.True(lbSecond.Displayed);
            Task.Delay(1000).Wait();
            var tabFirst = FindUIElement("TabFirst");
            tabFirst.Click();
            Task.Delay(2000).Wait();
            var lbFirst = FindUIElement("lbFirst");
            Assert.True(lbFirst.Displayed);
            Task.Delay(1000).Wait();
        }
        [Test]
        [Category("Test_Login_Success_AI")]
        public void Test_Login_And_Navigate_To_Second_Tab()
        {
            // Find UI elements for login
            var usernameField = FindUIElement("UsernameEntry");
            var passwordField = FindUIElement("PasswordEntry");
            var loginButton = FindUIElement("LoginButton");

            // Input credentials
            usernameField.SendKeys("usernametest" + "\n");
            Task.Delay(1000).Wait(); // Short delay to ensure UI readiness
            passwordField.SendKeys("passwordTest" + "\n");
            Task.Delay(1000).Wait(); // Optional delay before clicking the login button

            loginButton.Click();
            // // Wait for HomePage to be visible
            if (App.PlatformName != "Android")
            {
                WebDriverWait wait = new WebDriverWait(App, TimeSpan.FromSeconds(20));
                wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(MobileBy.AccessibilityId("HomePage")));
                var tab2 = FindUIElement("Tab2");
                var tab3 = FindUIElement("Tab3");
                tab2.Click();
                tab3.Click();
            }
            // Assuming 'driver' is your Appium driver and is already initialized
            if (App.PlatformName == "Android")
            {
                var tab2 = App.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().description(\"Tab 2\")"));
                tab2.Click();
                var lbSecond = FindUIElement("lbSecond"); // Assuming 'lbSecond' is an element unique to the second tab
                Assert.IsTrue(lbSecond.Displayed, "Failed to navigate to the second tab.");
                var tab3 = App.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().description(\"Tab 3\")"));
                tab3.Click();
            }

            // Click on the first tab
            // var homePage = FindUIElement("Tab1");
            // homePage.Click();
            // // Optionally wait for an element in the first tab to be visible
            // Task.Delay(1000).Wait(); // Replace with explicit wait if possible

            // Assertions to verify the first tab is displayed
            // var lbFirst = FindUIElement("lbFirst");
            // Assert.IsTrue(lbFirst.Displayed, "Failed to navigate to the first tab.");
            // if (App.PlatformName != "Android")
            // {
            //     Console.WriteLine(App.PageSource.ToString());
            // }
            // // Click on the second tab
            // var tabSecond = FindUIElement("TabSecond");
            // tabSecond.Click();
            // // Optionally wait for an element in the second tab to be visible
            // Task.Delay(1000).Wait(); // Replace with explicit wait if possible

            // // Assertions to verify the second tab is displayed
            // var lbSecond = FindUIElement("lbSecond"); // Assuming 'lbSecond' is an element unique to the second tab
            // Assert.IsTrue(lbSecond.Displayed, "Failed to navigate to the second tab.");
        }
    }

}