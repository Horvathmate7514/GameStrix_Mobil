using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GameStrix.Models;
using GameStrix.Network;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GameStrix.ViewModels
{


    public partial class CartViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Product> cartProducts = new ObservableCollection<Product>();


       





        [RelayCommand]
        async void Appearing()
        {

            string? selectedProd = await SecureStorage.GetAsync("SelectedProduct");

            if (selectedProd == null)
            {
                if (CartProducts.Count == 0)
                {
                    
                    await Shell.Current.DisplayAlert("Hiba", "A kosár tartalma üres!", "OK");

                }
              
            }
            if (selectedProd != null)
            {
                Product? product = JsonSerializer.Deserialize<Product?>(selectedProd);
                CartProducts.Add(product);
                           
            }

        }


        [RelayCommand]
        Task GoToShipping()
        {

            return Shell.Current.GoToAsync("ShippingDataPage");
        }

        [RelayCommand]
        async void DeleteFromCart()
        {
            CartProducts.Clear();
            SecureStorage.Default.RemoveAll();
            
        }



    }
}
