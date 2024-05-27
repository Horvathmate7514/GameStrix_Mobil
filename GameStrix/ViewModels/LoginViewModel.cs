using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GameStrix.Models;
using GameStrix.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStrix.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        [ObservableProperty]
        string email;

        [ObservableProperty]
        string password;

        [RelayCommand]
        void Login()
        {
            if (string.IsNullOrEmpty(Email))
            {
                Shell.Current.DisplayAlert("Hiba!", "Az email címet kötelező megadni!", "Ok");
                return;
            }
            if (string.IsNullOrEmpty(Password))
            {
                Shell.Current.DisplayAlert("Hiba!", "A jelszót kötelező megadni!", "Ok");
                return;
            }
            UserRootObject? userRObj= API.Login(Email, Password);
            if (userRObj != null)
            {
                Shell.Current.DisplayAlert("Megerősítés!", "Sikeres belépés!", "Ok");
                SecureStorage.SetAsync("token", userRObj.token);
                
                return;
            }
        }
    }
}
