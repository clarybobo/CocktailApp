using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CocktailApp.Models
{
    public class Cocktail
    {

        public string? IdDrink { get; set; }
        public string? StrDrink { get; set; }
        public string? StrDrinkThumb { get; set; }
        public string? StrIngredient1 { get; set; }
        public string? StrIngredient2 { get; set; }
        public string? StrIngredient3 { get; set; }
        public string? StrIngredient4 { get; set; }
        public string? StrMeasure1 { get; set; }
        public string? StrMeasure2 { get; set; }
        public string? StrMeasure3 { get; set; }
        public string? StrMeasure4 { get; set; }
        public string? StrInstructions { get; set; }

        //[JsonPropertyName("idDrink")]


        //[JsonPropertyName("idDrink")]
        //public string Id { get; set; }

        //[JsonPropertyName("strDrink")]
        //public string Drink { get; set; }

        //[JsonPropertyName("strInstructions")]
        //public string Instructions { get; set; }

        //[JsonPropertyName("strDrinkThumb")]
        //public string ImageUrl { get; set; }
        ////TODO: lägg till så alla 15 ingredienser finns med

        //[JsonPropertyName("strIngredient1")]
        //public string Ingredient1 { get; set; }

        //[JsonPropertyName("strIngredient2")]
        //public string Ingredient2 { get; set; }

        //[JsonPropertyName("strIngredient3")]
        //public string Ingredient3 { get; set; }

        //[JsonPropertyName("strIngredient4")]
        //public string Ingredient4 { get; set; }

        //[JsonPropertyName("strMeasure1")]
        //public string Measure1 { get; set; }

        //[JsonPropertyName("strMeasure2")]
        //public string Measure2 { get; set; }

        //[JsonPropertyName("strMeasure3")]
        //public string Measure3 { get; set; }

        //[JsonPropertyName("strMeasure4")]
        //public string Measure4 { get; set; }
    }

}

