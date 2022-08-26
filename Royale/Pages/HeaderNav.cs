


using Framework;
using Framework.Selenium;
using OpenQA.Selenium;

namespace Royale.Pages
{
    public class HeaderNav

    {
        public readonly HeaderNavMap Map;
        public HeaderNav()
        {
            Map = new HeaderNavMap();
        }
        public void GoToCardsPage()
        {
          //  FW.Log.Step("Click on cards button ");
            Map.CardsTabLink.Click();
        }

        public void DealWithGdpr()
        {
            //  FW.Log.Step("Click on accept button ");
            // need to change frame to accept cookies otherwise elements not clickable
            Driver.Wait.Until(driver => Map.GdprFrame.Displayed);
            Driver.Current.SwitchTo().Frame(Map.GdprFrame);
          
            Driver.Wait.Until((driver => Map.AcceptButton.Displayed));
            Map.AcceptButton.Click();
        }
    }


 
     public class HeaderNavMap

    {

    public Element CardsTabLink => Driver.FindElement(By.CssSelector("a[href='/cards']"),"cards icon");  
    public Element DeckBuilderLink => Driver.FindElement(By.CssSelector("a[href='/deckbuilder']"),"deckbuilder icon");
    public IWebElement GdprFrame => Driver.Current.FindElement(By.CssSelector("[title *='Consent']"));
    public IWebElement AcceptButton => Driver.Current.FindElement(By.CssSelector("[title *='Accept']"));
    
    }
}