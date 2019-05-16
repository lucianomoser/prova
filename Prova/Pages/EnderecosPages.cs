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
            WebDriverWait aguarde = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            aguarde.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//*[@id='formfiltro']/form/button")));
            return this;
        }

        public EnderecosPages BotaoTodos()
        {
            Driver.FindElement(By.XPath("//*[@id='formfiltro']/form/div/div[2]/div/div[3]")).Click();
            Thread.Sleep(1000);
            return new EnderecosPages(Driver);
        }

        public EnderecosPages Consultar()
        {
            WebDriverWait aguarde = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            aguarde.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//*[@id='formfiltro']/form/button")));
                
            IWebElement botaoConsultar = Driver.FindElement(By.XPath("//*[@id='formfiltro']/form/button"));
            executor = (IJavaScriptExecutor)Driver;
            executor.ExecuteScript("window.scrollBy(" + botaoConsultar.Location.X + ", " + botaoConsultar.Location.Y + ")");
            executor.ExecuteScript("arguments[0].click();", botaoConsultar);
            return this;            
        }
        public CriarEnderecoPages BotaoCriarNovo()
        {
            Driver.FindElement(By.XPath("//*[@id='app']/div/div/div[1]/div/div/div[1]/button")).Click();
            return new CriarEnderecoPages(Driver);
        }

        public EnderecosPages Pesquisar(string pesquisa)
        {
            Driver.FindElement(By.XPath("//*[@id='formfiltro']/form/div/div[3]/input")).SendKeys(pesquisa);
            return this;
        }

        public CriarEnderecoPages Grid()
        {           

            int ultimoRegistro = Convert.ToInt32(Driver.FindElement(By.XPath("//*[@id='app']/div/div/div[1]/div/div/div[2]/div/div/div[3]/div[2]/div[1]/div[1]/div")).Text.Substring(24,4).Trim());            

            CriarEnderecoPages criarEnderecoPages = new CriarEnderecoPages(Driver);

            criarEnderecoPages.Armazem = Driver.FindElement(By.XPath($"//*[@id='app']/div/div/div[1]/div/div/div[2]/div/div/div[3]/div[1]/table/tbody/tr[{ultimoRegistro}]/td[3]")).Text;
            criarEnderecoPages.Descricao = Driver.FindElement(By.XPath($"//*[@id='app']/div/div/div[1]/div/div/div[2]/div/div/div[3]/div[1]/table/tbody/tr[{ultimoRegistro}]/td[4]")).Text;

            string codigo = "EQ" + ultimoRegistro + 1;

            criarEnderecoPages.Codigo= Driver.FindElement(By.XPath($"//*[@id='app']/div/div/div[1]/div/div/div[2]/div/div/div[3]/div[1]/table/tbody/tr[{ultimoRegistro}]/td[2]")).Text;                   
            

            return criarEnderecoPages;
        }


    }
}