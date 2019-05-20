using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;

namespace Prova.Pages
{
    public class CriarEnderecoPages
    {
        public IWebDriver Driver { get; set; }

        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Armazem { get; set; }

        public CriarEnderecoPages(IWebDriver driver)
        {
            Driver = driver;            
        }

        public CriarEnderecoPages IncluirEndereco(CriarEnderecoPages endereco)        
        {
            var codigo = Driver.FindElement(By.Id("code"));
            //var armazem = Driver.FindElement(By.ClassName("Select-placeholder"));
            var armazem = Driver.FindElement(By.XPath("//*[@id='locationFormModal']/div/div/div[2]/form/div[1]/div[2]/div/div/span/span"));
            var armazem01 = Driver.FindElements(By.XPath("//*[@id='locationFormModal']/div/div/div[2]/form/div[1]/div[2]/div/div/span/span"));
            var descricao = Driver.FindElement(By.Id("description"));
            var ativo = Driver.FindElement(By.XPath("//*[@id='inputBooleano']/a[1]"));

            var tipoEndereco = Driver.FindElement(By.ClassName("Select-placeholder"));
            var controleDeManuseio = Driver.FindElement(By.Id("react-select-5--value"));
            var statusEndereco = Driver.FindElement(By.Id("react-select-7--value"));
            var statusDeMovimentacao = Driver.FindElement(By.Id("react-select-8--value"));                
            var sequencia = Driver.FindElement(By.Id("sequence"));


            codigo.SendKeys(endereco.Codigo);
            codigo.SendKeys(Keys.Tab);
            armazem.Click();
            Thread.Sleep(1000);        
            //id = "react-select-3--value-item"
            //BR1E - CDD-Guarulhos
            var teste = Driver.FindElement(By.XPath("//*[@id='react-select-3--value']/div[1]"));
            //var teste = Driver.FindElement(By.XPath("//*[@id='react-select-3--value']/div[2]"));

            Driver.FindElement(By.XPath("//*[@id='characteristics']/div/div[1]/div[1]/div/div/span")).Click();
            Thread.Sleep(2000);

            var teste01 = Driver.FindElements(By.ClassName("Select-input"));


            Actions actions = new Actions(Driver);
            foreach (var item in teste01)
            {
                IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
                executor.ExecuteScript("window.scrollBy(" + item.Location.X + "," + item.Location.Y + ")");
                executor.ExecuteScript("arguments[0].click();", item);
            }
            actions.MoveToElement(teste, teste.Location.X, teste.Location.Y).Build().Perform();
            Thread.Sleep(1000);
            actions.MoveToElement(teste, teste.Location.X, teste.Location.Y).SendKeys("BR1E - CDD-Guarulhos").Perform();
            Thread.Sleep(1000);
            teste.SendKeys(Keys.Tab);
            Thread.Sleep(1000);
            descricao.SendKeys(endereco.Codigo);
            //ativo.Click();
            //*[@id="react-select-4--value-item"]
            tipoEndereco.Click();
            var novo = Driver.FindElements(By.XPath("//*[@id='react-select-4--value']/div[2]/input"));

            
            tipoEndereco.SendKeys(Keys.Tab);
            controleDeManuseio.SendKeys("Indiferente");
            controleDeManuseio.SendKeys(Keys.Tab);            
            sequencia.SendKeys("0");
            statusEndereco.SendKeys("Vazio");
            statusDeMovimentacao.SendKeys("Liberado");
            return this;
        }


        public CriarEnderecoPages ObterUltimoRegistroCadastrado()
        {

            int ultimoRegistro = Convert.ToInt32(Driver.FindElement(By.XPath("//*[@id='app']/div/div/div[1]/div/div/div[2]/div/div/div[3]/div[2]/div[1]/div[1]/div")).Text.Substring(24, 4).Trim());

            string proximoCodigo = RetornaProximoRegistroValido(ultimoRegistro);

            CriarEnderecoPages criarEnderecoPages = new CriarEnderecoPages(Driver)
            {
                Armazem = Driver.FindElement(By.XPath($"//*[@id='app']/div/div/div[1]/div/div/div[2]/div/div/div[3]/div[1]/table/tbody/tr[{ultimoRegistro}]/td[1]")).Text,
                Descricao = Driver.FindElement(By.XPath($"//*[@id='app']/div/div/div[1]/div/div/div[2]/div/div/div[3]/div[1]/table/tbody/tr[{ultimoRegistro}]/td[3]")).Text,
                Codigo = proximoCodigo
            };

            return criarEnderecoPages;
        }

        private string RetornaProximoRegistroValido(int ultimoRegistro)
        {
            string codigo = Driver.FindElement(By.XPath($"//*[@id='app']/div/div/div[1]/div/div/div[2]/div/div/div[3]/div[1]/table/tbody/tr[{ultimoRegistro}]/td[2]")).Text;
            string iniciaisDoCodigo = codigo.Substring(0, 2);
            string finalDoCodigo = codigo.Substring(2, 3);

            int auxCodigo = Convert.ToInt32(finalDoCodigo) + 1;
            codigo = iniciaisDoCodigo + Convert.ToString(auxCodigo);
            return codigo;
        }


    }
}
