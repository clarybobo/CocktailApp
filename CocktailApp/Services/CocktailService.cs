using CocktailApp.Models;
using System.Net.Http.Json;

namespace CocktailApp.Services
{
    public class CocktailService
    {
        //HttpClient httpClient;
        //List<Cocktail> cocktails = new List<Cocktail>();

        //public CocktailService(HttpClient httpClient)
        //{
        //    httpClient = new HttpClient();
        //}

        HttpClient _httpClient;
        List<Cocktail> cocktails = new List<Cocktail>();

        public CocktailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Cocktail>> GetCocktails()
        {
            //här hämtas en lista över cocktails med namn och bild
            var url = "https://www.thecocktaildb.com/api/json/v1/1/filter.php?c=Cocktail";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                //cocktails = await response.Content.ReadFromJsonAsync<List<Cocktail>>();
                //return await response.Content.ReadFromJsonAsync<List<Cocktail>>();
                //return cocktails;
                var cocktailResponse = await response.Content.ReadFromJsonAsync<CocktailResponse>();
                return cocktailResponse?.CocktailList ?? new List<Cocktail>();
            }

            Console.WriteLine($"Failed to fetch cocktails: {response.StatusCode}");
            return new List<Cocktail>();

        }

        //public async Task<Cocktail> GetCocktailDetailsAsync(string cocktailId)
        //{
        //    var url = $"https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i={cocktailId}";
        //    var response = await httpClient.GetAsync(url);

        //    if(response.IsSuccessStatusCode)
        //    {
        //        var cocktailResponse = await response.Content.ReadFromJsonAsync<CocktailResponse>();
        //        return cocktailResponse?.CocktailList?.FirstOrDefault();
        //    }
        //    return null;
        //}
    }
}

//Fortsätt api-videon kring 17 min 

//https://www.thecocktaildb.com/api/json/v1/1/filter.php?c=Cocktail
// https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i={drinkId}