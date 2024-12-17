using System.Text.Json.Serialization;

namespace CocktailApp.Models
{
    public class CocktailResponse
    {
        [JsonPropertyName("drinks")]
        public List<Cocktail> CocktailList { get; set; } 
    }
}
