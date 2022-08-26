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

namespace Royale.Tests;

public class CardTests : TestBase
{
   
    static IList<Card> apiCards = new ApiCardService().GetAllCards();
    /*
    [Test, Category("cards")]
    [TestCaseSource ("apiCards")]
    [Parallelizable(ParallelScope.Children)]
    public void Card_is_on_Cards_Page(Card card)
    {
         
 

    
          

         var cardOnPage = Pages.Pages.Cards.GoTo().GetCardByName(card.Name);

        
        Assert.That(cardOnPage.Displayed);
    }
      */
    
      [Test, Category("cards")]
      [TestCaseSource("apiCards")]
      [Parallelizable(ParallelScope.Children)]
        public void Card_headers_are_correct_on_Card_Details_Page(Card card)
    {
         



        Pages.PagesWrapper.Cards.GoTo().GetCardByName(card.Name).Click();
        
       
    
       var cardOnPage = Pages.PagesWrapper.CardDetails.GetBaseCard();
                   if (cardOnPage.Type == "troop"){
                    cardOnPage.Type = "character";
                   } 

        //api names are a bit difeerent than names on the page         


        Assert.That(card.Name.Contains(cardOnPage.Name),"Name not matching " + card.Name +" vs " + cardOnPage.Name );
        Assert.That(card.Type.Contains(cardOnPage.Type),"Type not matching " + card.Type +" vs " + cardOnPage.Type +" name "+ card.Name + " nameOnpage " + cardOnPage.Name);
        Assert.AreEqual(card.Rarity,cardOnPage.Rarity,  cardOnPage.Name  + " c: " + card.Name +" vs " + cardOnPage.Name);

        Assert.AreEqual(card.Arena,cardOnPage.Arena, cardOnPage.Name  + " c: " + card.Name +" vs " + cardOnPage.Name);
    }


}