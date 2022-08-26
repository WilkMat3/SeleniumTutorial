using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace Framework.Selenium
{
    public static class Driver
    {
        [ThreadStatic]
        private static IWebDriver _driver;
         [ThreadStatic]
        public static Wait Wait;

        public static string Title => Current.Title;
        public static void Init()
        {
           
            _driver = DriverFactory.Build(FW.Config.Driver.Browser);
             Wait = new Wait(FW.Config.Driver.WaitSeconds);
        }
    
        public static IWebDriver Current => _driver ?? throw new NullReferenceException("_driver is null");

        public static void GoTo(string url){
            if(!url.StartsWith("http")){
                url = $"http://{url}";
            }
                FW.Log.Info(url);
                Current.Navigate().GoToUrl(url);
        }
        public static Element FindElement(By by, string elmentName){
            var element = Wait.Until(drvr => drvr.FindElement(by));
            return new Element(element, elmentName)
            {
                FoundBy = by
            };
        }

        public static Elements FindElements(By by){
            return new Elements(Current.FindElements(by)){
                FoundBy = by
            };
        }

        public static void Quit(){
            FW.Log.Info("Close Browser");
            Current.Close();
            Current.Dispose();
        }
        public static void TakeScreenshot( string imgName){
            var ss = ((ITakesScreenshot)Current).GetScreenshot();
            var ssFilename  = Path.Combine(FW.CurrentTestDirectory.FullName, imgName);
            ss.SaveAsFile($"{ssFilename}.png", ScreenshotImageFormat.Png);
        }
    }


}