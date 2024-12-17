using CocktailApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CocktailApp.ViewModels
{

    [QueryProperty("Cocktail", "Cocktail")] 
    public partial class DetailsViewModel: BaseViewModel
    {
        
        [ObservableProperty]
        Cocktail cocktail;

        //[RelayCommand]
        //private async void GoBack()
        //{
        //    await Shell.Current.GoToAsync("//MainPage"); // Navigera tillbaka till föregående sida (MainViewPage)
        //}
    }
}
