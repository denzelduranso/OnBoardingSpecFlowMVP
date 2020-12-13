using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace MarsPortalSpecFlowMVP.PageObjectModels
{
    public class GoToProfilePage
    {
        readonly IWebDriver driver;



        public GoToProfilePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void GoToProfile()
        {
           
            //Click Skills Tab Page
            var SkillsBtn = driver.FindElement(By.XPath("//a[text()='Skills']"));
            SkillsBtn.Click();

            //Click Add New Button in Skills Tab
            var AddNewBtn = driver.FindElement(By.CssSelector("div[class='ui teal button']"));
            AddNewBtn.Click();

            //Generate a Unique Skill Level
            var randomNumber = new Random();
            var code = "Payroll Master" + randomNumber.Next(0, 999);
            var skillLevel = "Expert";
            addSkill(code, skillLevel);
            
            //Coding for clicking the Last created Skill and Level
            var tableRow1 = driver.FindElement(By.XPath("//td[text()='" + code + "']//ancestor::tr"));
            var tableRow2 = driver.FindElement(By.XPath("//td[text()='" + skillLevel + "']//ancestor::tr"));

            //Assertion if the Skill and Level was created
            Assert.IsTrue(tableRow1.Displayed);
            Assert.IsTrue(tableRow2.Displayed);
        }

        //A method that can be reuse by another tester
        private void addSkill(String skillName, String skillLevel)
        {
            var Skill = driver.FindElement(By.CssSelector("input[placeholder = 'Add Skill']"));
            Skill.SendKeys(skillName);

            var dropdownSkillLevel = new SelectElement(driver.FindElement(By.XPath("//select[@name='level']")));
            dropdownSkillLevel.SelectByValue(skillLevel);

            var AddBtn = driver.FindElement(By.XPath("//input[@value='Add']"));
            AddBtn.Click();
        }
    }
}