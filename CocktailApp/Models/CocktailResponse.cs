using System.Text.Json.Serialization;

namespace CocktailApp.Models
{
    public class CocktailResponse
    {
        [JsonPropertyName("drinks")] // Binder egenskapen till JSON-nyckeln "drinks"
        public List<Cocktail> CocktailList { get; set; } // Här lagras listan av cocktails
    }
}
