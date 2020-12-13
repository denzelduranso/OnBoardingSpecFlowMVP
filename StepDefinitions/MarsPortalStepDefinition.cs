using MarsPortalSpecFlowMVP.MarsPortalStepDefinition.PageObjectModels;
using MarsPortalSpecFlowMVP.PageObjectModels;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace MarsPortalSpecFlowMVP.StepDefinitions.PageObjectModels
{
    [Binding]
    public class MarsPortalStepDefinition
    {
        

        IWebDriver driver;
        
        [BeforeScenario]
        public void Setup()
        {

            //Chrome Browser
            driver = new ChromeDriver();
            //Make the Browser Full Screen when it opens
            driver.Manage().Window.Maximize();

            //Implicit Wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);


        }

        [BeforeScenario]
        [Given(@"I can navigate to the Mars Portal")]
        public void GivenICanNavigateToTheMarsPortal()
        {
            driver.Navigate().GoToUrl("http://localhost:5000/Home");
        }

        [When(@"I add user name and password to the sign in box and click login")]
        public void WhenIAddUserNameAndPasswordToTheSignInBoxAndClickLogin()
        {
            var SignInPage = new SignInToMarsPortal(driver);
            SignInPage.SignIn();
        }

        

        [Then(@"I click Hi Denzel")]
        public void ThenIClickHiDenzel()
        {
            driver.Navigate().GoToUrl("http://localhost:5000/Account/Profile");
        }

        [Then(@"Go to profile to edit my skills")]
        public void ThenGoToProfileToEditMySkills()
        {
            var GotoProfile = new GoToProfilePage(driver);
            GotoProfile.GoToProfile();
        }


        [AfterScenario]

        public void CloseDriver()
        {

            driver.Close();
            driver.Dispose();
        }
    }
}
