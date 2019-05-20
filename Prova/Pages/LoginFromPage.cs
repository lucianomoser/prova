using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Prova.Pages
{
    public class LoginFromPage
    {
        public IWebDriver Driver { get; set; }
        private WebDriverWait aguarde;

        public LoginFromPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public EnderecosPages MenuConfiguracaoEndereco(string itemMenu)
        {
            Driver.FindElement(By.XPath("//*[@id='main-menu']/li[10]")).Click();

            var menuEnderecos = Driver.FindElement(By.XPath("//*[@id='main-menu']/li[10]/ul/li[11]/a"));

            IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
            executor.ExecuteScript("window.scrollBy(" + menuEnderecos.Location.X + "," + menuEnderecos.Location.Y + ")");
            executor.ExecuteScript("arguments[0].click();", menuEnderecos);

            aguarde = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            aguarde.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(By.Id("formfiltro")));
                                   
            return new EnderecosPages(Driver);
        }

    }
}