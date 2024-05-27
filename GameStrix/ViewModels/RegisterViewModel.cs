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
    public partial class RegisterViewModel : ObservableObject
    {
        [ObservableProperty]
        string fullName;

        [ObservableProperty]
        string email;

        [ObservableProperty]
        string password;

        [ObservableProperty]
        string address;

        [ObservableProperty]
        string phoneNumber;

        [RelayCommand]
        void Register()
        {
            if(String.IsNullOrWhiteSpace(FullName))
            {
                Shell.Current.DisplayAlert("Hiba!", "A teljes nevet kötelező megadni!", "Ok");
                return;
            }
            if (String.IsNullOrWhiteSpace(Email) || !Email.Contains("@"))
            {
                Shell.Current.DisplayAlert("Hiba!", "Az email cím nem megfelelő!", "Ok");
                return;
            }
            if (String.IsNullOrWhiteSpace(Password) || Password.Length < 8)
            {
                Shell.Current.DisplayAlert("Hiba!", "A jelszónak legalább 8 karakter hosszúnak kell lennie!", "Ok");
                return;
            }
            if (String.IsNullOrWhiteSpace(Address))
            {
                Shell.Current.DisplayAlert("Hiba!", "A cím megadása kötelező!", "Ok");
                return;
            }
            if (String.IsNullOrWhiteSpace(PhoneNumber))
            {
                Shell.Current.DisplayAlert("Hiba!", "A telefonszám megadása kötelező!", "Ok");
                return;
            }
            UserRootObject? userRObj = API.Register(FullName, Email, Password, Address, PhoneNumber);
            if (userRObj != null)
            {
                Shell.Current.DisplayAlert("Megerősítés!", "Sikeres regisztráció! Lépjen be!", "Ok");
                
                return;
            }
            Shell.Current.DisplayAlert("Hiba!", "Sikertelen regisztráció, próbálja meg később!", "Ok");
            return;
        }
    }
}
