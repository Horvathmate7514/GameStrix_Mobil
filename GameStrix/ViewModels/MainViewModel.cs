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
    [QueryProperty(nameof(SelectedProduct), "SelectedProduct")]
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        List<Product>? products;

        [ObservableProperty]
        List<Product>? listedProducts;

        [ObservableProperty]
        List<ProductCategory>? categories;

        [ObservableProperty]
        ProductCategory? selectedCategory;

        [ObservableProperty]
        IList<KeyValuePair<int, string>>? filterConditions;

        [ObservableProperty]
        KeyValuePair<int, string> selectedFilterPair;

        [ObservableProperty]
        Product? selectedProduct;

    

        [RelayCommand]
        void Appearing()
        {
            Products = API.GetProducts();
            ListedProducts = Products.Take(8).ToList();
            Categories = API.GetCategories();
            FilterConditions = new List<KeyValuePair<int, string>>()
            {
                new KeyValuePair<int, string>(1, "Név szerint A->Z"),
                new KeyValuePair<int, string>(2, "Név szerint Z->A"),
                new KeyValuePair<int, string>(3, "Legolcsóbb elöl"),
                new KeyValuePair<int, string>(4, "Legdrágább elöl")
            };
        }

        [RelayCommand]
        void GetMoreProducts()
        {
            if (SelectedCategory == null || SelectedCategory.CategoryID == 0)
                Products.GetRange(ListedProducts.Count, ListedProducts.Count + 10 > Products.Count ? Products.Count - ListedProducts.Count : 8).ForEach(x => ListedProducts.Add(x));
        }

        [RelayCommand]
        void NavigateToDetails(Product? value)
        {
            if (SelectedProduct != null)
            {
                Dictionary<string, object> navParameters = new Dictionary<string, object>()
                {
                    {"SelectedProduct", SelectedProduct}
                };
                Shell.Current.GoToAsync("ProductDetailsPage", true, navParameters);
            }
        }

        partial void OnSelectedCategoryChanged(ProductCategory? value)
        {
            ListedProducts = Products.Where(x => x.CategoryID == value.CategoryID).ToList();
            OnSelectedFilterPairChanged(SelectedFilterPair);
        }

        partial void OnSelectedFilterPairChanged(KeyValuePair<int, string> value)
        {
            switch (value.Key)
            {
                case 1:
                    ListedProducts = ListedProducts.OrderBy(x => x.ProductName).ToList();
                    break;
                case 2:
                    ListedProducts = ListedProducts.OrderByDescending(x => x.ProductName).ToList();
                    break;
                case 3:
                    ListedProducts = ListedProducts.OrderBy(x => x.RetailPrice).ToList();
                    break;
                case 4:
                    ListedProducts = ListedProducts.OrderByDescending(x => x.RetailPrice).ToList();
                    break;
            }
        }

        [RelayCommand]
        void AddToCart()
        {

            if (SelectedProduct != null)
            {
                Dictionary<string, object> navParameters = new Dictionary<string, object>()
                {
                    {"SelectedProduct", SelectedProduct}
                };
                Shell.Current.GoToAsync("/CartPage", true, navParameters);
            }
        }

    }
}
