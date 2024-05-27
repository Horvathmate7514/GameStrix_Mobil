using GameStrix.ViewModels;

namespace GameStrix.Views;

public partial class ShippingDataPage : ContentPage
{
	public ShippingDataPage(ShippingDataViewModel vm)
	{
		InitializeComponent();
        this.BindingContext = vm;
    }
}