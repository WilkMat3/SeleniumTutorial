using OpenQA.Selenium;

namespace Framework.Selenium
{
    public sealed class WaitConditions
    {
        public static Func<IWebDriver, bool> ElementDisplayed(IWebElement elment){
            bool condition(IWebDriver driver){
                return elment.Displayed;
            }
            return condition;
        }

            public static Func<IWebDriver, IWebElement> ElementIsDisplayed(IWebElement elment){
            IWebElement condition(IWebDriver driver){
                try
                {
                     return elment.Displayed ? elment : null;
                }
                catch (NoSuchElementException)
                {
                    
                    return null;
                }
                catch(ElementNotVisibleException){
                    return null;
                }
            }
            
            return condition;
        }

        public static Func<IWebDriver, bool> ElementNotDisplayed(IWebElement elment){
            bool condition(IWebDriver driver){
                try
                {
                    return !elment.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    
                    return true;
                }
            }
            return condition;
        }
        public static Func<IWebDriver, Elements> ElementsNotEmpty(Elements elements){
            Elements condition(IWebDriver driver){
                Elements _elements = Driver.FindElements(elements.FoundBy);
                return _elements.IsEmpty ? null : _elements;
            }
            return condition;
        }

         
    }

    
}