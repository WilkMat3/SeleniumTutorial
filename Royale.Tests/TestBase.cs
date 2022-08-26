using Framework;
using Framework.Selenium;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Tests.Base
{
    public abstract class TestBase
    {
          [OneTimeSetUp]
        public virtual void BeforeAll(){
            FW.SetConfig();
            FW.CreateTestResultsDirectory();
        }

         [SetUp]
        public virtual void BeforeEach()
        {
            FW.SetLogger();
            Driver.Init();
            Royale.Pages.PagesWrapper.Init();
            Driver.Current.Manage().Window.Maximize();
            Driver.GoTo(FW.Config.Test.Url);
            Royale.Pages.PagesWrapper.HeaderNav.DealWithGdpr();
        }
        [TearDown] 
        public virtual void AfterEach()
        {
            var outcome = TestContext.CurrentContext.Result.Outcome.Status;
            if(outcome == TestStatus.Passed){
                FW.Log.Info(" Outcome: Passed");
            }else if (outcome == TestStatus.Failed){
                 FW.Log.Info(" Outcome: Failed");
                 Driver.TakeScreenshot("test_failed");
            }else{
                FW.Log.Warning(" Outcome: " + outcome);
            }
                       Driver.Quit();
        }
    }
    
}