using OpenQA.Selenium;

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

        public CriarEnderecoPages IncluirEndereco()
        {
            var codigo = Driver.FindElement(By.Id("code"));
            var armazem = Driver.FindElement(By.ClassName("Select-placeholder"));
            var descricao = Driver.FindElement(By.Id("description"));
            var ativo = Driver.FindElement(By.ClassName("btn btn-primary btn-sm ativo"));

            var tipoEndereco = Driver.FindElement(By.ClassName("Select-placeholder"));
            var controleDeManuseio = Driver.FindElement(By.Id("react-select-5--value"));
            var statusEndereco = Driver.FindElement(By.Id("react-select-7--value"));
            var statusDeMovimentacao = Driver.FindElement(By.Id("react-select-8--value"));
                
            var sequencia = Driver.FindElement(By.Id("sequence"));


            codigo.SendKeys(Codigo);
            armazem.Click();
            Driver.FindElement(By.Id("react-select-3--value-item")).Click();




            tipoEndereco.SendKeys("Equipamento");
            tipoEndereco.SendKeys(Keys.Tab);
            controleDeManuseio.SendKeys("Indiferente");
            controleDeManuseio.SendKeys(Keys.Tab);            
            sequencia.SendKeys("0");
            statusEndereco.SendKeys("Vazio");
            statusDeMovimentacao.SendKeys("Liberado");














            return this;
        }


    }
}