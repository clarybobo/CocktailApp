using CocktailApp.Models;
using CocktailApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace CocktailApp.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        private readonly CocktailService cocktailService;

        [ObservableProperty]
        ObservableCollection<Cocktail> cocktails = new ObservableCollection<Cocktail>();

        //[ObservableProperty]
        //Cocktail cocktailDetails; 

        public MainViewModel(CocktailService cocktailService)
        {
            this.cocktailService = cocktailService;
        }

        [RelayCommand]
        async Task Get()
        {
            Cocktails.Clear();
            var cocktailList = await cocktailService.GetCocktails();
            foreach (var cocktail in cocktailList)
            {
                Cocktails.Add(cocktail);
            }

        }

        //[RelayCommand]
        //async Task ViewDetails(string cocktailId)
        //{
        //    var cocktail = await cocktailService.GetCocktailDetailsAsync(cocktailId);
        //    cocktailDetails = cocktail;
        //}

        //[RelayCommand]
        //Task Get()
        //{

        //}
    }
}


//public List<string> IngredientsWithMeasurements
//{
//    get
//    {
//        var ingredients = new List<string>
//        {
//            FomatIngredients()
//        };
//    }
//}

//public string FormatIngredients(string ingredient, string measure)
//{
//    if (string.IsNullOrEmpty(ingredient)) return null;
//    return !string.IsNullOrEmpty(measure) ? $"{measure} {ingredient}" : ingredient;         

//}