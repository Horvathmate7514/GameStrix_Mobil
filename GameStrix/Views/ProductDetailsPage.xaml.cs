using GameStrix.ViewModels;

namespace GameStrix.Views;

public partial class ProductDetailsPage : ContentPage
{
	public ProductDetailsPage(ProductDetailsView vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}