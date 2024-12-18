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
        ObservableCollection<Cocktail> cocktails = new();


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

            foreach (var cocktail in basicCocktails)
            {
                if (!Cocktails.Any(c => c.IdDrink == cocktail.IdDrink))
                {
                    Cocktails.Add(cocktail); 
                }
            }
        }

        [RelayCommand]
        async Task Search()
        {           
            if (string.IsNullOrWhiteSpace(SearchQuery))
            {
                Cocktails.Clear();
                var basicCocktails = await cocktailService.GetCocktails();

                foreach (var cocktail in basicCocktails)
                {
                    Cocktails.Add(cocktail); 
                }
            }
            else
            {
                var results = await cocktailService.Search(SearchQuery);
                Cocktails.Clear();

                foreach (var result in results)
                {
                    Cocktails.Add(result); 
                }
            }
        }

        [RelayCommand]
        partial void OnSearchQueryChanged(string value) 
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                LoadCocktails();
            }
        }

        [RelayCommand]
        async Task ViewDetails(Cocktail cocktail)
        {            
            if (cocktail is null) return;

            var fullDetails = await cocktailService.ViewDetails(cocktail.IdDrink);
            if (fullDetails != null)
            {                
                await Shell.Current.GoToAsync($"{nameof(DetailPage)}",
                    true,
                    new Dictionary<string, object>
                    {
                { "Cocktail", fullDetails}
                    });
            }
        }
    }
}
