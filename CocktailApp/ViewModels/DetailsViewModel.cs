using CocktailApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CocktailApp.ViewModels
{

    [QueryProperty("Cocktail", "Cocktail")] 
    public partial class DetailsViewModel: BaseViewModel
    {
        [ObservableProperty]
        Cocktail cocktail;
    }
}
