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
            var cocktails = await cocktailService.GetCocktails();
            if (cocktails.Count != 0)
            {
                Cocktails.Clear();
                foreach (var cocktail in cocktails)
                {
                    Cocktails.Add(cocktail);
                }
            }

        }


        //private async void LoadCocktail(Cocktail cocktail)
        //{
        //    if (cocktail is null || string.IsNullOrEmpty(cocktail.IdDrink)) return;

        //    var fullCocktail = await cocktailService.ViewDetails(cocktail.IdDrink);
        //    if (fullCocktail != null)
        //    {
        //        Cocktails.Clear();
        //        Cocktails.Add(fullCocktail);
        //    }
        //}

        //[RelayCommand]
        //async Task Get()
        //{
        //    Cocktails.Clear();
        //    var cocktailList = await cocktailService.GetCocktails();
        //    foreach (var cocktail in cocktailList)
        //    {
        //        Cocktails.Add(cocktail);
        //    }
        //}

        [RelayCommand]
        async Task Search()
        {
            Cocktails.Clear();
            var results = await cocktailService.Search(SearchQuery);
            foreach (var result in results)
            {
                Cocktails.Add(result);
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
    }
}
