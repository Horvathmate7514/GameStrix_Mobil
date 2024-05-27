using GameStrix.ViewModels;

namespace GameStrix.Views;

public partial class RegisterPage : ContentPage
{
	public RegisterPage(RegisterViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}