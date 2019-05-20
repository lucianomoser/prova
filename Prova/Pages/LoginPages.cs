using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;


namespace Prova.Pages
{
    class LoginPages
    {
        private IWebDriver Driver;
        private WebDriverWait aguarde;

        public LoginPages(IWebDriver driver)
        {
            Driver = driver;
        }

        

        public LoginFromPage InformacoesLogin(string login, string password)
        {
            Driver.FindElement(By.Id("Login")).SendKeys(login);         
            Driver.FindElement(By.Id("Password")).SendKeys(password);
            Driver.FindElement(By.Id("Entrar")).Click();

            aguarde = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            aguarde.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(By.Id("main-menu")));


            return new LoginFromPage(Driver);
        }
    }
}
