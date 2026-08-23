// using classess from Selenium and WebdriverManager

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome; //->for Chrome
using OpenQA.Selenium.Safari;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl; // chrome config  -> cant use this becoz my chrome version and driver version is different
using WebDriverManager.Helpers;
using OpenQA.Selenium.Support.UI;

namespace Selenium_CSharp_Automation_Learning;

public class SimpleApplicationRunner
{
    public static void Main(string[] args)
    {
        //I merge all test case's in one file 
        //choose which test to run
        UIInputTest();
    }

    public static void chromeSafari()
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

// Video 11 - to do UI Integration on Web by code in Brave browser:

    public static void UIInputTest()
    {
    //So here are many problems related to chrome automatically closing in running phase; which from the beginning is very problem; but as the lecturer uses Visual Studio and i use JetBrains which can be a cause of problem and So is use gpt or online help to make my code run
    
        Console.WriteLine("1. Starting");

        new DriverManager().SetUpDriver(
            new ChromeConfig(),
            VersionResolveStrategy.MatchingBrowser
        );

        IWebDriver driver = new ChromeDriver();

        try
        {
            driver.Navigate().GoToUrl("https://github.com/");

            Console.WriteLine("2. GitHub opened");
            
            IWebElement searchBox = driver.FindElement(By.CssSelector(".HeaderSearch-module__searchSlot__oVOUS"));
            searchBox.Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); //wait for up to 10 seconds for something to become available.
            // Here also i run this using function (lambda)
            IWebElement searchInput = wait.Until(
                d => d.FindElement(//lamba operator
                    By.CssSelector("input[placeholder='Search or jump to...']")
                )
            );

            
            searchInput.SendKeys("selenium");

            Console.WriteLine("3. Text sent");
            Thread.Sleep(2000);
            searchInput.SendKeys(Keys.Enter);
            Console.WriteLine("4. Pressed Enter");

            Thread.Sleep(5000);
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR:");
            Console.WriteLine(ex.Message);

            // Keep Chrome open for debugging
            Thread.Sleep(10000);
        }
        finally
        {
            driver.Quit();
        }
        
        
        /*
        new DriverManager().SetUpDriver(
            new ChromeConfig(),
            VersionResolveStrategy.MatchingBrowser
        );
        
        
        // to prevent automatic browser closing
        var options = new ChromeOptions();
        options.LeaveBrowserRunning = true;
        // Setup for Chrome browser
        
        IWebDriver driver = new ChromeDriver();
        

        driver.Navigate().GoToUrl("https://github.com/");
        //to locate the search box
        IWebElement searchBox = driver.FindElement(By.CssSelector(".HeaderSearch-module__searchSlot__oVOUS"));
        searchBox.Click();

        IWebElement searchInput = driver.FindElement(By.CssSelector("input[placeholder='Search or jump to...']"));
        searchInput.SendKeys("selenium");
        searchInput.SendKeys(Keys.Enter);
        
        // Keep the browser open
     

        // Close the browser properly
        
        */
       
        
    }

}