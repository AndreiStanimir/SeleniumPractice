using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Selenium.Pages;
using SeleniumExtras.PageObjects;
using static System.Net.WebRequestMethods;

namespace Selenium
{
    public class Tests
    {
        VacanciesPage vacanciesPage;
        WebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new FirefoxDriver(@"C:\Users\andreio\Downloads\geckodriver-v0.31.0-win64");
            driver.Url = @"https://cz.careers.veeam.com/vacancies";
            driver.Manage()
                .Window
                .Maximize();
            driver.Manage()
                .Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            
            vacanciesPage = new VacanciesPage(driver);
            vacanciesPage.AcceptCookies();
        }

        [Test]
        public void JobCount()
        {
            
            //Assert.That(vacanciesPage.departmentsDropDown.Displayed^&)
            vacanciesPage.SelectDepartment("Research & Development");
            Assert.That(vacanciesPage.departmentsDropDown.Text, Contains.Substring("Research & Development"));
            Assert.AreEqual(13, vacanciesPage.GetJobCount());
        }
    }
}