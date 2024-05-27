using GameStrix.ViewModels;

namespace GameStrix.Views
{
    public partial class MainPage : ContentPage
    {
        MainViewModel viewModel = new MainViewModel();
        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            this.BindingContext = vm;
        }

      
    }

}
