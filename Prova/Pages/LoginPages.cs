using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova.Pages
{
    class LoginPages
    {
        private IWebDriver Driver;

        public LoginPages(IWebDriver driver)
        {
            Driver = driver;
        }


        public LoginFromPage InformacoesLogin(string login, string password)
        {
            Driver.FindElement(By.Id("Login")).SendKeys(login);         
            Driver.FindElement(By.Id("Password")).SendKeys(password);
            Driver.FindElement(By.Id("Entrar")).Click();

            return new LoginFromPage(Driver);
        }
    }
}
