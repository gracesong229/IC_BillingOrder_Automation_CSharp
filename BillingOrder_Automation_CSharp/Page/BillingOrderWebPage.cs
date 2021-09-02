using Commons.Model;
using OpenQA.Selenium;

namespace WebAutomation.Page
{
    public class BillingOrderWebPage
    {

        IWebDriver browser;

        public BillingOrderWebPage(IWebDriver driver)
        {
            browser = driver;
        }

        public void FirstName(string value) => browser.FindElement(By.Id("wpforms-24-field_0")).SendKeys(value);
        public void LastName(string value) => browser.FindElement(By.Id("wpforms-24-field_0-last")).SendKeys(value);
        public void Email(string value) => browser.FindElement(By.Id("wpforms-24-field_1")).SendKeys(value);
        public void Phone(string value) => browser.FindElement(By.Id("wpforms-24-field_2")).SendKeys(value);
        public void AddressLine1(string value) => browser.FindElement(By.Id("wpforms-24-field_3")).SendKeys(value);
        public void AddressLine2(string value) => browser.FindElement(By.Id("wpforms-24-field_3-address2")).SendKeys(value);
        public void City(string value) => browser.FindElement(By.Id("wpforms-24-field_3-postal")).SendKeys(value);

        public void FillOrderForm(BillingOrder order)
        {
            FirstName(order.FirstName);
            LastName(order.LastName);
            Email(order.Email);
            AddressLine1(order.AddressLine1);
            AddressLine2(order.AddressLine2);

        }

        public void Login()
        {
            browser.FindElement(By.Id("wpforms-locked-24-field_form_locker_password")).SendKeys("Testing");
            browser.FindElement(By.Id("wpforms-locked-24-field_form_locker_password")).SendKeys(Keys.Enter);
        }

        internal void Validate()
        {
            //do validation here...
        }

        public void Submit() => browser.FindElement(By.Id("wpforms-submit-24")).Click();
    }
}