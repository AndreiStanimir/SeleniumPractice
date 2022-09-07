using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Pages
{
    public class VacanciesPage
    {
        IWebDriver driver;
        private WebDriverWait wait;

        public VacanciesPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.Id("cookiescript_accept")));
            PageFactory.InitElements(this.driver, this);
        }

        //[FindsBy(How = How.Id, Using = "sl", Priority = 0)]
        [FindsBy(How = How.CssSelector, Using = ".col-lg-4 div:nth-of-type(2) #sl")]
        [CacheLookup]
        public IWebElement departmentsDropDown { get; set; }

        [FindsBy(How.Id, "cookiescript_accept")]
        public IWebElement acceptCookieButton { get; set; }

        [FindsBy(How.CssSelector, ".h-100")]
        IWebElement jobs;
        public void SelectDepartment(string departmentName)
        {
            departmentsDropDown.Click();
            var departmentButton = departmentsDropDown.FindElement(By.XPath($"//a[.='{departmentName}']"));
            //var department = departmentButton(e => e.Text.Equals(departmentName, StringComparison.CurrentCultureIgnoreCase));
            if (departmentButton != null)
                departmentButton.Click();
        }
        public int GetJobCount()
        {
            var jobsWebElements = driver.FindElements(By.CssSelector("a[class='card card-sm card-no-hover'"));
            return jobsWebElements.Count();
        }
        public void AcceptCookies()

        {
            var acceptCookieButton = wait.Until(driver =>
            {
                var elem = driver.FindElement(By.Id("cookiescript_accept"));
                if (elem.Displayed)
                    return elem;
                return null;
                });
            if (acceptCookieButton != null)
                if (acceptCookieButton.Enabled && acceptCookieButton.Displayed)
                    acceptCookieButton?.Click();
        }
    }
}
