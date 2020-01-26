using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MailPage
{
    [TestClass]
    public class FoxPage
    {
        ChromeDriver chrome;    
        string user = "dasstest";
        string password = "12345ZaqQ";

        [TestMethod]
        public void MailPage()
        {
            chrome = new ChromeDriver();
            chrome.Manage().Window.Maximize();

            chrome.Navigate().GoToUrl("https://mail.ru/");

            chrome.FindElementById("mailbox:login")
                .SendKeys(user);

            chrome.FindElementById("mailbox:submit")
                .Click();

            chrome.FindElementById("mailbox:password")
                .SendKeys(password);

            chrome.FindElementById("mailbox:submit")
                .Click();


            WebDriverWait wait = new WebDriverWait(chrome, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementExists(By.ClassName("compose-button")));
            chrome.FindElementByClassName("compose-button").Click();

            WebDriverWait wait1 = new WebDriverWait(chrome, TimeSpan.FromSeconds(20));
            wait1.Until(ExpectedConditions.ElementExists(By.Name("Subject")));            
            chrome.FindElementByName("Subject").SendKeys("Не важная тема");

            WebDriverWait wait2 = new WebDriverWait(chrome, TimeSpan.FromSeconds(20));
            wait2.Until(ExpectedConditions.ElementExists(By.XPath("//div/div/input")));
            chrome.FindElementByXPath("//div/div/input").SendKeys("Неизвестный получатель");

            WebDriverWait wait3 = new WebDriverWait(chrome, TimeSpan.FromSeconds(20));
            wait3.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[15]/div[2]/div/div[1]/div[2]/div[3]/div[5]/div/div/div[2]/div[1]/div/div[1]")));
            chrome.FindElementByXPath("/html/body/div[15]/div[2]/div/div[1]/div[2]/div[3]/div[5]/div/div/div[2]/div[1]/div/div[1]").SendKeys("Много текста");

            chrome.FindElementByXPath("//div[2]/div/span/span/span").Click();
        }

    }
}
