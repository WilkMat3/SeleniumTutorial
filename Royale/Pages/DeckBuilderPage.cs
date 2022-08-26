using Framework;
using Framework.Selenium;
using OpenQA.Selenium;

namespace Royale.Pages
{
    public class DeckBuilderPage : PageBase
    {
        public readonly DeckBuilderPageMap Map;
        public DeckBuilderPage()
        {
            Map = new DeckBuilderPageMap();
        }
        public DeckBuilderPage GoTo()
        {
           
            HeaderNav.Map.DeckBuilderLink.Click();
            Driver.Wait.Until(drvr => Map.AddCardsManuallyLink.Displayed);
            return this;
        }
        public void AddClassManually()
        {
            Driver.Wait.Until(WaitConditions.ElementIsDisplayed(Map.AddCardsManuallyLink)).Click();
           // Map.AddCardsManuallyLink.Click();
             Driver.Wait.Until(WaitConditions.ElementDisplayed(Map.CopyDeckIcon));
            
        }
        public void CopySuggestedDeck()
        {
            
            Map.CopyDeckIcon.Click();
        }
    }   
    public class DeckBuilderPageMap
    {
          public Element AddCardsManuallyLink => Driver.FindElement(By.XPath("//a[text()='add cards manually']"),"add cards manually link");

         public Element CopyDeckIcon => Driver.FindElement(By.CssSelector(".copyButton"),"Copy button");
    }
}