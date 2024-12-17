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


        [ObservableProperty]
        string searchQuery = string.Empty;

        public MainViewModel(CocktailService cocktailService)
        {
            this.cocktailService = cocktailService;
            LoadCocktails();
        }

        private async void LoadCocktails()
        {
            var basicCocktails = await cocktailService.GetCocktails();

            if (basicCocktails.Count > 0)
            {
                Cocktails.Clear();

                // Hämta detaljer för varje drink
                foreach (var cocktail in basicCocktails)
                {
                    var fullDetails = await cocktailService.ViewDetails(cocktail.IdDrink);
                    if (fullDetails != null)
                    {
                        Cocktails.Add(fullDetails); // Lägg till drinken med alla detaljer
                    }
                }
            }
            //var basicCocktails = await cocktailService.GetCocktails();

            //if (basicCocktails.Count > 0)
            //{
            //    Cocktails.Clear();

            //    // Kör parallellt för att hämta detaljer om varje cocktail
            //    var tasks = basicCocktails.Select(async cocktail =>
            //    {
            //        var fullDetails = await cocktailService.ViewDetails(cocktail.IdDrink);
            //        return fullDetails;
            //    });

            //    var detailedCocktails = await Task.WhenAll(tasks);

            //    // Lägg till alla cocktails med fulla detaljer till listan
            //    foreach (var detailedCocktail in detailedCocktails)
            //    {
            //        if (detailedCocktail != null)
            //        {
            //            Cocktails.Add(detailedCocktail);
            //        }
            //    }
            //}
        }       

        [RelayCommand]
        async Task Search()
        {
            if (string.IsNullOrWhiteSpace(SearchQuery))
            {
                LoadCocktails(); 
                return;
            }

            Cocktails.Clear();
            var results = await cocktailService.Search(SearchQuery);
            foreach (var result in results)
            {
                Cocktails.Add(result);
            }
        }

        [RelayCommand]
        partial void OnSearchQueryChanged(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                LoadCocktails(); // Ladda om alla cocktails om sökrutan är tom
            }
        }

        [RelayCommand]
        async Task ViewDetails(Cocktail cocktail)
        {
            if (cocktail is null) return;

            await Shell.Current.GoToAsync($"{nameof(DetailPage)}",
                true,
                new Dictionary<string, object>
                {
                    { "Cocktail", cocktail}
                });
        }

        //[RelayCommand]
        //async Task GoBack()
        //{
        //    await Shell.Current.GoToAsync("..");
        //}


    }
}
