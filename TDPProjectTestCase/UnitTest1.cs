using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using Xunit;
using SeleniumExtras.WaitHelpers;

namespace TDPProjectTestCase
{
    public class UnitTest1
    {
        IWebDriver driver;
        public UnitTest1()
        {

            driver = new ChromeDriver(@"C:\Users\91789\Downloads\chromedriver-win64\chromedriver-win64");
            driver.Navigate().GoToUrl("http://localhost:3000/");
            Thread.Sleep(1000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
         
        }

        [Fact]
        public void Login()
        {

            driver.Navigate().GoToUrl("http://localhost:3000/login");
            Thread.Sleep(1000);
            driver.FindElement(By.Name("Email")).SendKeys("akhila@gmail.com");
            Thread.Sleep(1000);
            driver.FindElement(By.Name("Password")).SendKeys("akki@123");
            Thread.Sleep(1000);
            driver.FindElement(By.ClassName("btn1")).Click();
            Thread.Sleep(1000);

            Assert.True(driver.FindElement(By.TagName("h1")).Displayed);
            Thread.Sleep(1000);

            var button = driver.FindElement(By.XPath("//button[text()='Add User']"));
            Thread.Sleep(1000);
            button.Click();

            // XPath using contains for class name
            //   var button = driver.FindElement(By.XPath("//button[contains(@class, 'add-user')]"));

            // XPath using text content


            // driver.FindElement(By.ClassName("add-user")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Name("Email")).SendKeys("priya@gmail.com");
            Thread.Sleep(2000);
            driver.FindElement(By.Name("Firstname")).SendKeys("Priya");
            Thread.Sleep(2000);
            driver.FindElement(By.Name("Lastname")).SendKeys("Madhuri");
            Thread.Sleep(2000);
            driver.FindElement(By.Name("Address")).SendKeys("Hyderabad");
            Thread.Sleep(2000);

            driver.FindElement(By.Name("Password")).SendKeys("priya@123");
            Thread.Sleep(2000);
            driver.FindElement(By.Name("Mobilenumber")).SendKeys("9618765432");
            Thread.Sleep(2000);
            // Select Department
            var departmentSelect = new SelectElement(driver.FindElement(By.Name("Select Department")));
            departmentSelect.SelectByText("IT");
            Thread.Sleep(2000);

            // Select Role
            var roleSelect = new SelectElement(driver.FindElement(By.Name("Select Role")));
            roleSelect.SelectByText("Employee");
            Thread.Sleep(2000);

            // Select Manager (only if role is not 'Manager')
            if (driver.FindElements(By.Name("Select Manager")).Count > 0)
            {
                var managerSelect = new SelectElement(driver.FindElement(By.Name("Select Manager")));
                managerSelect.SelectByText("Rashmi Mechineni");
                Thread.Sleep(2000);
            }


            button = driver.FindElement(By.XPath("//button[text()='Add User']"));
            Thread.Sleep(1000);
            button.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            var userElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//td[contains(text(),'Priya')]")));
            Assert.True(userElement.Displayed);
            Thread.Sleep(2000);

            // Click Edit button
            var editButton = driver.FindElement(By.XPath("//button[text()='Edit']"));
            editButton.Click();
            Thread.Sleep(2000);

            // Edit the user's last name
            var lastNameField = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("Lastname")));
            lastNameField.Clear();
            lastNameField.SendKeys("Madhu");

            var submitButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("submit-button")));
            submitButton.Click();
            Thread.Sleep(2000);

            // Assert that the user's new last name is displayed
            var updatedUserElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//td[contains(text(),'Priya')]")));
            Assert.True(updatedUserElement.Displayed);

            // Click Delete button
            var deleteButton = driver.FindElement(By.XPath("//button[text()='Delete']"));
            deleteButton.Click();
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(2000);

            Assert.True(driver.FindElement(By.XPath("//button[text()='Logout']")).Displayed);
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[text()='Logout']")).Click();
            Thread.Sleep(2000);

            Assert.Equal("http://localhost:3000/", driver.Url);

            driver.Navigate().GoToUrl("http://localhost:3000/login");
            Thread.Sleep(1000);
            driver.FindElement(By.Name("Email")).SendKeys("shubham@gmail.com");
            Thread.Sleep(2000);
            driver.FindElement(By.Name("Password")).SendKeys("shubham");
            Thread.Sleep(2000);
            driver.FindElement(By.ClassName("btn1")).Click();
            Thread.Sleep(3000);


            Assert.True(driver.FindElement(By.ClassName("button")).Displayed);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement createButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.ClassName("button")));
            Assert.True(createButton.Displayed);

            // Now attempt to click it
            createButton.Click();

            driver.FindElement(By.Name("projectId")).SendKeys("DWF");
            Thread.Sleep(2000);
            driver.FindElement(By.Name("reasonForTravel")).SendKeys("Project Presentation");
            Thread.Sleep(2000);
            driver.FindElement(By.Name("fromDate")).SendKeys("24-12-2024");
            Thread.Sleep(1000);
            driver.FindElement(By.Name("toDate")).SendKeys("02-01-2025");
            Thread.Sleep(2000);
            driver.FindElement(By.Name("fromLocation")).SendKeys("India");
            Thread.Sleep(2000);
            driver.FindElement(By.Name("toLocation")).SendKeys("UK");
            Thread.Sleep(2000);

            driver.FindElement(By.XPath("//button[text()='Submit Request']")).Click();
            // driver.FindElement(By.ClassName("btns")).Click();
            Thread.Sleep(1000);

            var alert = driver.SwitchTo().Alert();
            Assert.Equal("Travel Request submitted successfully!", alert.Text);
            alert.Accept();
            Thread.Sleep(1000);

            Assert.True(driver.FindElement(By.XPath("//button[text()='Logout']")).Displayed);
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[text()='Logout']")).Click();
            Thread.Sleep(2000);

            Assert.Equal("http://localhost:3000/", driver.Url);

            driver.Navigate().GoToUrl("http://localhost:3000/login");
            Thread.Sleep(1000);

            driver.FindElement(By.Name("Email")).SendKeys("rashmi@gmail.com");
            Thread.Sleep(2000);
            driver.FindElement(By.Name("Password")).SendKeys("rashmi@123");
            Thread.Sleep(2000);
            driver.FindElement(By.ClassName("btn1")).Click();
            Thread.Sleep(2000);

            Assert.True(driver.FindElement(By.ClassName("reject-button")).Displayed);
            Thread.Sleep(2000);

            driver.FindElement(By.ClassName("reject-button")).Click();
            Thread.Sleep(2000);
            IAlert commentAlert = driver.SwitchTo().Alert();
            commentAlert.SendKeys("Give the proper reason for travel");
            commentAlert.Accept();
            Thread.Sleep(2000);
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(2000);

            Assert.True(driver.FindElement(By.ClassName("approve-button")).Displayed);
            Thread.Sleep(2000);
            driver.FindElement(By.ClassName("approve-button")).Click();
            Thread.Sleep(2000);

            IAlert cmtAlert = driver.SwitchTo().Alert();
            cmtAlert.SendKeys("Approved");
            cmtAlert.Accept();
            Thread.Sleep(2000);
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(2000);

            Assert.True(driver.FindElement(By.XPath("//button[text()='Logout']")).Displayed);
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[text()='Logout']")).Click();
            Thread.Sleep(2000);

            Assert.Equal("http://localhost:3000/", driver.Url);

            driver.Navigate().GoToUrl("http://localhost:3000/login");
            Thread.Sleep(1000);
            Thread.Sleep(1000);
                driver.FindElement(By.Name("Email")).SendKeys("sushan@gmail.com");
                Thread.Sleep(2000);
                driver.FindElement(By.Name("Password")).SendKeys("sushan@123");
                Thread.Sleep(2000);
                driver.FindElement(By.ClassName("btn1")).Click();
                Thread.Sleep(2000);

            Assert.True(driver.FindElement(By.XPath("//button[text()='Return to Manager']")).Displayed);
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[text()='Return to Manager']")).Click();
            Thread.Sleep(1000);
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(3000);
            Assert.True(driver.FindElement(By.XPath("//button[text()='Return to Employee']")).Displayed);
            Thread.Sleep(1000);

            driver.FindElement(By.XPath("//button[text()='Return to Employee']")).Click();
            Thread.Sleep(1000);
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(2000);



            // Wait until the "Book Ticket" button is displayed
            IWebElement bookTicketButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[text()='Book Ticket']")));

            // Click the "Book Ticket" button
            bookTicketButton.Click();

            // Wait until the alert is present
             alert = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());

            // Verify the alert text
            Assert.Equal("Ticket booked successfully!", alert.Text);

            // Accept the alert
            alert.Accept();
            Thread.Sleep(2000);

            Assert.True(driver.FindElement(By.XPath("//button[text()=' Close Request']")).Displayed);
            Thread.Sleep(2000);

            driver.FindElement(By.XPath("//button[text()=' Close Request']")).Click();
            Thread.Sleep(1000);
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(2000);
           Assert.True(driver.FindElement(By.XPath("//button[text()='Download Ticket']")).Displayed);
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//button[text()='Download Ticket']")).Click();
            Thread.Sleep(3000);


            Assert.True(driver.FindElement(By.XPath("//button[text()='Logout']")).Displayed);
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[text()='Logout']")).Click();
            Thread.Sleep(2000);

            Assert.Equal("http://localhost:3000/", driver.Url);

            driver.Navigate().GoToUrl("http://localhost:3000/login");
            Thread.Sleep(1000);
            driver.Close();

        }
        }
    }
