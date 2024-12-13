using CocktailApp.ViewModels;

namespace CocktailApp;

public partial class DetailPage : ContentPage
{
	public DetailPage(DetailsViewModel detailViewModel)
	{
		InitializeComponent();
		BindingContext = detailViewModel;
	}
}