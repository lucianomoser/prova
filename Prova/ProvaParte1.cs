﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Prova.suporte;
using Prova.Pages;

namespace Prova
{
    [TestClass]
    public class ProvaParte1
    {
        private IWebDriver Driver { get; set; }
        private WebDriverWait Aguardar { get; set; }

        public static string[] proximoCodigo;

        [TestInitialize]       

        public void InicializaAmbiente()
        {
            Driver = Web.chrome();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            

        }



        [TestMethod]
        public void Login()
        {

            new LoginPages(Driver).InformacoesLogin("lucianoteste", "Hb1234");
            new LoginFromPage(Driver).MenuConfiguracaoEndereco("Configurações");
            new EnderecosPages(Driver).ConsultaDeEnderecos();
            





        }


        [TestCleanup]
        public void FinalizaAmbiente()
        {
            Driver.Quit();
        }



    }
}
