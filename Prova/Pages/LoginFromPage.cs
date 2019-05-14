using OpenQA.Selenium;

namespace Prova.Pages
{
    public class LoginFromPage
    {
        public IWebDriver Driver { get; set; }

        public LoginFromPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public EnderecosPages MenuConfiguracaoEndereco(string itemMenu)
        {
            Driver.FindElement(By.XPath("//*[@id='main-menu']/li[10]")).Click();

            var menuEnderecos= Driver.FindElement(By.XPath("//*[@id='main-menu']/li[10]/ul/li[11]/a"));
            
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;

            executor.ExecuteScript("window.scrollBy(menuEnderecos.Location.X", "menuEnderecos.Location.Y)");
            menuEnderecos.Click();










            return new EnderecosPages(Driver);
        }

    }
}