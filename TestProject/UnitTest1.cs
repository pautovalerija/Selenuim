using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Selenium_Demo
{
    class Selenium_Demo
    {
        IWebDriver driver;
        String test_url = "http://prelive.aptimea.com/form/questionnaire";   
        private readonly Random _random = new Random();

        [SetUp]
        public void start_browser()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void test_page1()
        {
            driver.Url = test_url;
            driver.Navigate().GoToUrl("http://prelive.aptimea.com/form/questionnaire");

            //IWebElement searchText = driver.FindElement(By.CssSelector("[name = 'q']"));
            //searchText.SendKeys("LambdaTest");

            IWebElement sButton2 = driver.FindElement(By.XPath("//button[@class='agree-button eu-cookie-compliance-secondary-button']"));
            sButton2.Click();


            for (int a = 0; a < 10; a++)
            {
                Thread.Sleep(2500);




                var sRadio = driver.FindElements(By.XPath("//div[@class='fieldset-wrapper']"));
                for (int i = 0; i < sRadio.Count; i++)
                {
                    var els = sRadio[i].FindElements(By.XPath(".//input[@type='radio']"));
                    if (els.Count >= 2)
                    {
                        try { els[_random.Next(0, els.Count)].Click(); } catch (Exception) { }
                    }
                }




                var sText = driver.FindElements(By.XPath("//input[@type='text']"));
                for (int i = 0; i < sText.Count; i++)
                {
                    try { sText[i].Click(); sText[i].SendKeys("LambdaTest"); } catch (Exception) { }
                }
                var sTextArea = driver.FindElements(By.XPath("//textarea"));
                for (int i = 0; i < sTextArea.Count; i++)
                {
                    try { sTextArea[i].Click(); sTextArea[i].SendKeys("LambdaTest"); } catch (Exception) { }
                }
                var sNum = driver.FindElements(By.XPath("//input[@type='number']"));
                for (int i = 0; i < sNum.Count; i++)
                {
                    try { sNum[i].Click(); sNum[i].SendKeys("1"); } catch (Exception) { }
                }
                var sSelect = driver.FindElements(By.XPath("//select"));
                for (int i = 0; i < sNum.Count; i++)
                {
                    try { sSelect[i].Click(); sSelect[i].FindElements(By.XPath(".//*"))[2].Click(); } catch (Exception) { }
                }
                IWebElement sButton = driver.FindElement(By.XPath("//*[@value='Suivant']"));
                try { sButton.Click(); } catch (Exception) { }
            }

            Thread.Sleep(2500);

            IWebElement sButton3 = driver.FindElement(By.XPath("//*[@value='Finaliser']"));
            try { sButton3.Click(); } catch (Exception) { }

            Thread.Sleep(2500);

            IWebElement sButton4 = driver.FindElement(By.XPath("//a[@href='/user/login']"));
            try { sButton4.Click(); } catch (Exception) { }

            Thread.Sleep(2500);

            var sText1 = driver.FindElement(By.XPath("//input[@type='text']"));
            try { sText1.Click(); sText1.SendKeys("klassivend870@gmail.com"); } catch (Exception) { }

            var sText2 = driver.FindElement(By.XPath("//input[@type='password']"));
            try { sText2.Click(); sText2.SendKeys("123123"); } catch (Exception) { }

            Thread.Sleep(100);

            IWebElement sButton5 = driver.FindElement(By.XPath("//*[@value='Se connecter']"));
            try { sButton5.Click(); } catch (Exception) { }








            Thread.Sleep(100000);
        }
        [TearDown]
        public void close_Browser()
        {
            driver.Quit();
        }
    }
}
