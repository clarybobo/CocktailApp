using CocktailApp.ViewModels;

namespace CocktailApp
{
    public partial class MainPage : ContentPage
    {        
        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }       
    }

}
