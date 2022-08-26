using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support;
using Royale.Pages;
using Framework.Models;
using Framework.Selenium;
using System.Collections.Generic;
using Framework.Services;
using Framework;
using Tests.Base;

namespace Royale.Tests
{
    public class CopyDeckTest : TestBase
    {
       

        [Test, Category("copydeck")]
        public void User_can_copy_the_deck()
        {
            
           
            Pages.PagesWrapper.DeckBuilder.GoTo().AddClassManually();


           
            Pages.PagesWrapper.DeckBuilder.CopySuggestedDeck();
          
            Pages.PagesWrapper.CopyDeck.Yes();
          
            // new comment
            Assert.That(Pages.PagesWrapper.CopyDeck.Map.CopiedMessage.Displayed);
        }
              [Test, Category("copydeck")]
               public void User_opens_app_store()
        {
            
           
            Pages.PagesWrapper.DeckBuilder.GoTo().AddClassManually();


           
            Pages.PagesWrapper.DeckBuilder.CopySuggestedDeck();
          
            Pages.PagesWrapper.CopyDeck.No().OpenAppStore();
          
               
            Assert.That(Driver.Title, Is.EqualTo("Clash Royale × Supercell"));
        }
                [Test, Category("copydeck")]
                public void User_opens_google_play()
        {
            
           
            Pages.PagesWrapper.DeckBuilder.GoTo().AddClassManually();


           
            Pages.PagesWrapper.DeckBuilder.CopySuggestedDeck();
          
            Pages.PagesWrapper.CopyDeck.No().OpenGooglePlay();
          
               
            Assert.AreEqual("Clash Royale × Supercell", Driver.Title);
        }
    }
}   