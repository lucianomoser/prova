using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Prova.Pages
{
    public class EnderecosPages
    {
        private IWebDriver Driver { get; set; }
        private IJavaScriptExecutor executor { get; set; }


        public EnderecosPages(IWebDriver driver)
        {
            Driver = driver;
        }



        public EnderecosPages Mostrar()
        {            
            Driver.FindElement(By.Id("react-select-2--value")).Click();
            Thread.Sleep(500);
            Driver.FindElement(By.Id("react-select-2--option-4")).Click();
            Thread.Sleep(5000);
            WebDriverWait aguarde = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            aguarde.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//*[@id='formfiltro']/form/button")));
            return this;
        }

        public EnderecosPages ConsultaDeEnderecos()
        {
            new EnderecosPages(Driver).BotaoTodos();
            new EnderecosPages(Driver).Mostrar();
            new EnderecosPages(Driver).EditorDePesquisar("EQ0");
            new EnderecosPages(Driver).BotaoConsultar();
            CriarEnderecoPages novoEndereco = new CriarEnderecoPages(Driver).ObterUltimoRegistroCadastrado();
            new EnderecosPages(Driver).BotaoCriarNovo();
            new CriarEnderecoPages(Driver).IncluirEndereco(novoEndereco);

            return this;
        }

        public EnderecosPages BotaoTodos()
        {
            Driver.FindElement(By.XPath("//*[@id='formfiltro']/form/div/div[2]/div/div[3]")).Click();
            Thread.Sleep(1000);
            return new EnderecosPages(Driver);
        }

        public EnderecosPages BotaoConsultar()
        {
            WebDriverWait aguarde = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            aguarde.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//*[@id='formfiltro']/form/button")));
                
            IWebElement botaoConsultar = Driver.FindElement(By.XPath("//*[@id='formfiltro']/form/button"));
            executor = (IJavaScriptExecutor)Driver;
            executor.ExecuteScript("window.scrollBy(" + botaoConsultar.Location.X + ", " + botaoConsultar.Location.Y + ")");
            executor.ExecuteScript("arguments[0].click();", botaoConsultar);
            Thread.Sleep(2000);
            return this;            
        }
        public CriarEnderecoPages BotaoCriarNovo()
        {
            Driver.FindElement(By.XPath("//*[@id='app']/div/div/div[1]/div/div/div[1]/button")).Click();
            WebDriverWait aguarde = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            aguarde.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='locationFormModal']/div/div/div[1]/h4")));
            
         
            return new CriarEnderecoPages(Driver);
        }

        public EnderecosPages EditorDePesquisar(string pesquisa)
        {
            Driver.FindElement(By.XPath("//*[@id='formfiltro']/form/div/div[3]/input")).SendKeys(pesquisa);
            Thread.Sleep(2000);
            return this;
        }
        
    }
}