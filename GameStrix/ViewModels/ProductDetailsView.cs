using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GameStrix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GameStrix.ViewModels
{
    [QueryProperty(nameof(SelectedProduct), "SelectedProduct")]


    public partial class ProductDetailsView : ObservableObject
    {
        [ObservableProperty]
        Product? selectedProduct;

        [RelayCommand]
        void AddToCart()
        {


         
            if (SelectedProduct != null)
            {
                SecureStorage.SetAsync("SelectedProduct", JsonSerializer.Serialize(SelectedProduct));
                Shell.Current.DisplayAlert("Siker", "Termék siekeresen hozzáadva a kosárhoz", "OK");

            }
        }
    }
}
