namespace Framework.Services;
using Framework.Models;

using Newtonsoft.Json;
using RestSharp;

public class ApiCardService : ICardService
    {
        public const string CARDS_API = "https://statsroyale.com/api/cards";
        public IList<Card> GetAllCards(){
            var client = new RestClient(CARDS_API);
            var request = new RestRequest
            {
                Method = Method.Get,
                RequestFormat = DataFormat.Json
            };
            var response = client.Execute(request);
            if(response.StatusCode != System.Net.HttpStatusCode.OK){
                throw new SystemException("/cards endpoint failed with "+ response.StatusCode);
            }

            return JsonConvert.DeserializeObject<IList<Card>>(response.Content);
        }
        public Card GetCardByName(string cardName)
        {
            var cards = GetAllCards();
            return cards.FirstOrDefault(card => card.Name == cardName ); 

        }
    }
