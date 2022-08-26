using Framework.Selenium;
using OpenQA.Selenium;
using SeleniumExtras;
using SeleniumExtras.WaitHelpers;

namespace Royale.Pages
{
    public class CopyDeckPage
    {
        public readonly CopyDeckPageMap Map;

        public CopyDeckPage()
        {
            Map = new CopyDeckPageMap();
        }

        public CopyDeckPage Yes(){
              
            Map.YesButton.Click();
            Driver.Wait.Until(drvr=>Map.CopiedMessage.Displayed);
            return this;
        }
            public CopyDeckPage No(){
            AcceptCookies();  
            Map.NoButton.Click();
            Driver.Wait.Until(ExpectedConditions.ElementIsVisible(Map.AppStoreButton.FoundBy));
            return this;
        }

            public void AcceptCookies()
        {
            Map.AcceptCookiesButton.Click();
           // Driver.Wait.Until(drvr => !Map.AcceptCookiesButton.Displayed);
             Driver.Wait.Until(WaitConditions.ElementNotDisplayed(Map.AcceptCookiesButton));
        }

        public void OpenAppStore()
        {
            Map.AppStoreButton.Click();
        }
        public void OpenGooglePlay()
        {
            Map.GoooglePlayButton.Click();
        }
    }

    public class CopyDeckPageMap
    {
        public Element YesButton => Driver.FindElement(By.Id("button-open"), "yes button");
        public Element AppStoreButton => Driver.FindElement(By.XPath("//a[text()='App Store']"), "app store button");
        public Element GoooglePlayButton => Driver.FindElement(By.XPath("//a[text()='Google Play']"), "Google play button");
        public Element NoButton => Driver.FindElement(By.Id("not-installed"), "not installed button");
        public Element CopiedMessage => Driver.FindElement(By.CssSelector(".notes.active")," notes active");
        public Element AcceptCookiesButton => Driver.FindElement(By.CssSelector("a.cc-btn.cc-dismiss"), " cookies accept button");
    }
}