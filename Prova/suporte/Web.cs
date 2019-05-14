using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Prova.suporte
{
    public class Web
    {
        public static IWebDriver chrome()
        {
            IWebDriver navegador = new ChromeDriver();
            //IWebDriver navegador = new FirefoxDriver();

            navegador.Navigate().GoToUrl("https://wmst2qa.ambev.com.br");

            navegador.Manage().Window.Maximize();

            return navegador;
        }
    }

    
}
