using CocktailApp.Models;
using System.Net.Http.Json;

namespace CocktailApp.Services
{
    public class CocktailService
    {
        HttpClient _httpClient;
        List<Cocktail> cocktails = new List<Cocktail>();

        public CocktailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Cocktail>> GetCocktails()
        {        
            var url = "https://www.thecocktaildb.com/api/json/v1/1/filter.php?c=Cocktail";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {              
                var cocktailResponse = await response.Content.ReadFromJsonAsync<CocktailResponse>();
                return cocktailResponse?.CocktailList ?? new List<Cocktail>();
            }
            Console.WriteLine($"Failed to fetch cocktails: {response.StatusCode}");
            return new List<Cocktail>();

        }

        public async Task<List<Cocktail>> Search(string query)
        {
            var url = $"https://www.thecocktaildb.com/api/json/v1/1/search.php?s={query}";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var cocktailResponse = await response.Content.ReadFromJsonAsync<CocktailResponse>();
                return cocktailResponse?.CocktailList ?? new List<Cocktail>();
            }

            Console.WriteLine($"Failed to fetch cocktails for query: {response.StatusCode}");
            return new List<Cocktail>();
        }

        public async Task<Cocktail> ViewDetails(string id)
        {
            var url = $"https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i={id}";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var cocktailResponse = await response.Content.ReadFromJsonAsync<CocktailResponse>();
                return cocktailResponse?.CocktailList?.FirstOrDefault();
            }
            return null;
        }
     
    }
}