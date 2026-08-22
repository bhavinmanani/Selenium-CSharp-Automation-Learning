// using classess from Selenium and WebdriverManager

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome; //->for Chrome
using OpenQA.Selenium.Safari;
using WebDriverManager;
using
    WebDriverManager.DriverConfigs.Impl; // chrome config  -> cant use this becoz my chrome version and driver version is different
using WebDriverManager.Helpers;

namespace Selenium_CSharp_Automation_Learning;

public class SimpleApplicationRunner
{
    public static void Main(string[] args)
    {
        /*//new DriverManager().SetUpDriver(new ChromeConfig()); // prepare driver for chrome ->cant coz of chrome version
        //IWebDriver driver  = new ChromeDriver(); // Selenium-controlled -> chrome browser
        IWebDriver driver  = new SafariDriver();

        driver.Navigate().GoToUrl("https://github.com");

        Console.WriteLine("GitHub opened. Press Enter to close.");
        Console.ReadLine();

        driver.Quit();*/

        //now the above one is not working becoz chrome browser version and chromeDriver version both are different thats why below code is use to match version

        Console.WriteLine("1. Program started");
        //to match versions 
        new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);

        Console.WriteLine("2. Driver setup complete");

        IWebDriver driver = new ChromeDriver();

        Console.WriteLine("3. Chrome opened");

        driver.Navigate().GoToUrl("https://github.com");

        Console.WriteLine("4. GitHub navigation complete");
        Console.WriteLine("5. PRESS ENTER TO CLOSE");

        Console.ReadLine();

        Console.WriteLine("6. Program finished");
    }
}
