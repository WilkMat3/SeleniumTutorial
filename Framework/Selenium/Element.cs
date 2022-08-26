using System.Collections.ObjectModel;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
namespace Framework.Selenium
{
    public class Element : IWebElement
    {
        public readonly string Name;
        public By FoundBy{get; set;}
        private readonly IWebElement _element;

        public IWebElement Current => _element ?? throw new System.NullReferenceException("is null");
        public Element(IWebElement element, string name){
            _element = element;

            Name = name;
        }

        public string TagName => Current.TagName;

        public string Text => Current.Text;

        public bool Enabled => Current.Enabled;

        public bool Selected => Current.Selected;

        public Point Location =>Current.Location;

        public Size Size => Current.Size;

        public bool Displayed => Current.Displayed;

        public void Clear()
        {
            Current.Clear();
        }

        public void Click()
        {
            FW.Log.Step($"Click {Name}");
            Current.Click();
        }

        public IWebElement FindElement(By by)
        {
           return Current.FindElement(by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
          return Current.FindElements(by);
        }

        public string GetAttribute(string attributeName)
        {
          return Current.GetAttribute(attributeName);
        }

        public string GetCssValue(string propertyName)
        {
           return Current.GetCssValue(propertyName);
        }

        public string GetDomAttribute(string attributeName)
        {
            return Current.GetDomAttribute(attributeName);
        }

        public string GetDomProperty(string propertyName)
        {
             return  Current.GetDomProperty(propertyName);
        }

        public ISearchContext GetShadowRoot()
        {
           return Current.GetShadowRoot();
        }

        public void SendKeys(string text)
        {
            Current.SendKeys(text);
        }

        public void Submit()
        {
            Current.Submit();
        }

        public void Hover(){
            var actions= new Actions(Driver.Current);
            actions.MoveToElement(Current).Perform();
        }
    }
}