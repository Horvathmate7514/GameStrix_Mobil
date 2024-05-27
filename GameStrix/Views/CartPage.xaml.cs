using GameStrix.ViewModels;

namespace GameStrix.Views;

public partial class CartPage : ContentPage
{
	public CartPage(CartViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}

   
}