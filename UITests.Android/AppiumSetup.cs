﻿using NUnit.Framework;

using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Remote;

namespace UITests;

[SetUpFixture]
public class AppiumSetup
{
	private static AppiumDriver? driver;

	public static AppiumDriver App => driver ?? throw new NullReferenceException("AppiumDriver is null");

	[OneTimeSetUp]
	public void RunBeforeAnyTests()
	{
		// If you started an Appium server manually, make sure to comment out the next line
		// This line starts a local Appium server for you as part of the test run
		AppiumServerHelper.StartAppiumLocalServer();
		var androidOptions = new AppiumOptions
		{
			// Specify UIAutomator2 as the driver, typically don't need to change this
			AutomationName = "UIAutomator2",
			// Always Android for Android
			PlatformName = "Android",
			// This is the Android version, not API level
			// This is ignored if you use the avd option belowf
			// PlatformVersion = "12",
			// The full path to the .apk file to test or the package name if the app is already installed on the device
			// App = "/Users/dungnb/DemoAppiumTest-Git/MauiApp/bin/Debug/net7.0-android/com.companyname.basicappiumsample.apk",

		};
		// androidOptions.AddAdditionalAppiumOption(MobileCapabilityType.NoReset, "true");
		androidOptions.AddAdditionalAppiumOption(AndroidMobileCapabilityType.AppPackage, "com.companyname.basicappiumsample");

		//Make sure to set [Register("com.companyname.basicappiumsample.MainActivity")] on the MainActivity of your android application
		androidOptions.AddAdditionalAppiumOption(AndroidMobileCapabilityType.AppActivity, $"com.companyname.basicappiumsample.MainActivity");
		// Specifying the avd option will boot the emulator for you
		// make sure there is an emulator with the name below
		// If not specified, make sure you have an emulator booted
		// androidOptions.AddAdditionalAppiumOption("avd", "Pixel_6a_API_31");
		// Setting allowInvisibleElements to true

		// androidOptions.AddAdditionalAppiumOption("android:allowInvisibleElements", true);
		// androidOptions.AddAdditionalAppiumOption("settings:allowInvisibleElements", true);
		// Note there are many more options that you can use to influence the app under test according to your needs
		driver = new AndroidDriver(androidOptions);
	}

	[OneTimeTearDown]
	public void RunAfterAnyTests()
	{
		driver?.Quit();

		// If an Appium server was started locally above, make sure we clean it up here
		AppiumServerHelper.DisposeAppiumLocalServer();
	}
}