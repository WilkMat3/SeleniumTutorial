namespace Framework.Models
{
    public class InMemoryCardService : ICardService
    {
        public Card GetCardByName(string cardName)
        {
            switch (cardName)
            {
                case "Ice Spirit":
                    return new IceSpiritCard();
                case "Barbarian Hut":
                    return new BarbarianHutCard();
                default:
                throw new System.ArgumentException("Card is not available " + cardName);
            }
        }
    }
}