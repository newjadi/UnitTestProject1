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
            //Создание экземпляра класса и открытие браузероа на полный экран, ввод адреса сайта.
            chrome = new ChromeDriver();
            chrome.Manage().Window.Maximize();            
            chrome.Navigate().GoToUrl("https://mail.ru/");

            //Авторизация на сайте по локаторам.
            chrome.FindElementById("mailbox:login")
                .SendKeys(user);

            chrome.FindElementById("mailbox:submit")
                .Click();

            chrome.FindElementById("mailbox:password")
                .SendKeys(password);

            chrome.FindElementById("mailbox:submit")
                .Click();

            //Создание письма и заполнение полей.
            //1. Ждем появления элемента, проверяем. Нажимаем кнопку создать письмо.
            WebDriverWait wait = new WebDriverWait(chrome, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementExists(By.ClassName("compose-button")));
            chrome.FindElementByClassName("compose-button").Click();

            //Открывается форма для заполнения.
            //2. Ждем когда появиться нужный элемент, проверяем. Заполняем поле "Тема письма".
            WebDriverWait wait1 = new WebDriverWait(chrome, TimeSpan.FromSeconds(20));
            wait1.Until(ExpectedConditions.ElementExists(By.Name("Subject")));            
            chrome.FindElementByName("Subject").SendKeys("Не важная тема");

            //3. Ждем когда появиться нужный элемент, проверяем. Заполняем поле "Адрес получателя".
            WebDriverWait wait2 = new WebDriverWait(chrome, TimeSpan.FromSeconds(20));
            wait2.Until(ExpectedConditions.ElementExists(By.XPath("//div/div/input")));
            chrome.FindElementByXPath("//div/div/input").SendKeys("Неизвестный получатель");

            //4. Ждем когда появиться нужный элемент, проверяем. Заполняем поле "Тело письма".
            WebDriverWait wait3 = new WebDriverWait(chrome, TimeSpan.FromSeconds(20));
            wait3.Until(ExpectedConditions.ElementExists(By.XPath("//div[3]/div[5]/div/div/div[2]/div")));
            chrome.FindElementByXPath("//div[3]/div[5]/div/div/div[2]/div").SendKeys("Много текста");

            //Находим и нажимаем кнопку отправить письмо.
            chrome.FindElementByXPath("//div[2]/div/span/span/span").Click();
        }

    }
}
