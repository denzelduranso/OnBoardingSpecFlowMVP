using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsPortalSpecFlowMVP.MarsPortalStepDefinition.PageObjectModels
{
    public class SignInToMarsPortal
    {

        readonly IWebDriver driver;



        public SignInToMarsPortal(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SignIn()
        {
            //Click the Sign In Btn
            var JoinBtn = driver.FindElement(By.XPath("//a[text()='Sign In']"));
            JoinBtn.Click();

            //Email Address
            var username = driver.FindElement(By.Name("email"));
            username.SendKeys("denzelevents@gmail.com");

            //Password
            var password = driver.FindElement(By.Name("password"));
            password.SendKeys("Test123456");

            //Log In to the Mars Portal
            var LogInBtn = driver.FindElement(By.XPath("//button[text()='Login']"));
            LogInBtn.Click();


            var dropwdowns = driver.FindElements(By.CssSelector("span[class=dropdown] a[data-toggle=dropdown]"));

            var isHiDenzelPresent = false;

            foreach (var dropdown in dropwdowns)

            {
                if (dropdown.Text == "Hi ")
                {
                    isHiDenzelPresent = true;
                    break;
               }
            }

            //Assert.IsTrue(isHiDenzelPresent);
        }
    }
}
