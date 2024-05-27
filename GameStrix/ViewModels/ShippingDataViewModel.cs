
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
  public partial class ShippingDataViewModel : ObservableObject
    {

        [ObservableProperty]
        string ?vezeteknev;
        [ObservableProperty]
        string? keresztnev;
        [ObservableProperty]
        string? telefonszam;

        [ObservableProperty]
        bool check;


        [ObservableProperty]
        string? cityName;

        [ObservableProperty]
        bool isLocating = false;

        [ObservableProperty]
        bool isNotLocating = true;

        bool isCheckingLocation;

        LocationData? locationData;

        CancellationTokenSource? cancelTokenSource;

        [RelayCommand]
        async Task GetCityByName()
        {
            if (!String.IsNullOrWhiteSpace(CityName))
                locationData = API.GetLocationData(CityName.Trim());
            
        }


        [RelayCommand]
        async Task GetCurrentLocation()
        {
            IsLocating = true;
            IsNotLocating = false;
            try
            {
                isCheckingLocation = true;
                GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                cancelTokenSource = new CancellationTokenSource();
                Location? location = await Geolocation.Default.GetLocationAsync(request, cancelTokenSource.Token);
                if (location != null)
                {
                    CityName = await GetGecocodeReverseData(location.Latitude, location.Longitude);
                }
            }
            catch (FeatureNotSupportedException ex)
            {
                await Shell.Current.DisplayAlert("Hiba", $"A helymeghatározás nem támogatott az eszközön!\nHibakód: {ex}", "Ok");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Hiba", $"A helyzetét nem sikerült lekérdezni!\nHibakód: {ex}", "Ok");
            }
            finally
            {
                isCheckingLocation = false;
            }
            IsLocating = false;
            IsNotLocating = !IsLocating;
        }

        private async Task<string> GetGecocodeReverseData(double latitude, double longitude)
        {
            IEnumerable<Placemark> placemarks = await Geocoding.Default.GetPlacemarksAsync(latitude, longitude);
            Placemark placemark = placemarks?.FirstOrDefault();
            if (placemark != null)
            {
                return placemark.Locality;
            }
            return null;
        }

        [RelayCommand]
        async void SendOrder()
        {
            if (String.IsNullOrWhiteSpace(Vezeteknev))
            {
                Shell.Current.DisplayAlert("Hiba", "Vezetéknév megadása kötelező!", "OK");
                return;
            }
            if (String.IsNullOrWhiteSpace(Keresztnev))
            {
                Shell.Current.DisplayAlert("Hiba", "Keresztnév megadása kötelező!", "OK");
                return;
            }
            if (String.IsNullOrWhiteSpace(Telefonszam))
            {
                Shell.Current.DisplayAlert("Hiba", "Telefonszám megadása kötelező!", "OK");
                return;
            }
            if (Check == false)
            {
                Shell.Current.DisplayAlert("Hiba", "Kérem fogadja el az ÁSZF-et!", "OK");
                return;
            }

            else
            {
                Shell.Current.DisplayAlert("Siker", "Megrendelés sikeresen leadva!", "OK");
                SecureStorage.Default.RemoveAll();
                Shell.Current.GoToAsync("/MainPage");
                return;
            }

            

        }
       
    }
}
