using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DemoEcommerce.Client.Services;
using DemoEcommerce.Library.ClientModels;
using MvvmHelpers;
using Windows.Devices.Display.Core;

namespace DemoEcommerce.Client.ViewModels
{
    public partial class PhoneHomePageViewModel : BaseViewModel
    {
        private readonly IProductService productService;
        private readonly ICartService cartService;
        [ObservableProperty]
        private bool contentDisabled;
        public ObservableRangeCollection<ProductModel> Products { get; set; } = new();
        public PhoneHomePageViewModel(IProductService productService, ICartService cartService)
        {
            this.productService = productService;
            this.cartService = cartService;
            Title = "Available Products";
            GetProducts();
        }

        private async void GetProducts()
        {
            try
            {
                var products = await productService.GetProductsAsync();
                if (products is null)
                    return;

                if (Products.Count > 0)
                    Products.Clear();

                foreach (var product in products)
                {
                    string ProductDescription = product.Description.Count() > 40 ? product.Description.Substring(0, 40) + "..." : product.Description;
                    Products.Add(new ProductModel() { Id = product.Id, 
                        CategoryId = product.CategoryId,
                        Image = product.Image, 
                        Name = product.Name, 
                        Price = product.Price, 
                        Quantity = product.Quantity, 
                        Description = ProductDescription });
                }


            }
            catch (Exception) { }
        }


        [RelayCommand]
        private async Task AddToCart(ProductModel selectedProduct)
        {
            if (selectedProduct is null) return;

            try
            {
                string result = await Shell.Current.DisplayPromptAsync("Specify Quantity", $"How many of | {selectedProduct.Name} | do you need?", initialValue: "1", maxLength: selectedProduct.Quantity.ToString().Length, keyboard: Keyboard.Numeric);
                if (string.IsNullOrEmpty(result) || string.IsNullOrWhiteSpace(result)) return;

                int userQuantity = int.Parse(result); 
                if (userQuantity > selectedProduct.Quantity)
                {
                    await Shell.Current.DisplayAlert("Alert", "Sorry, Your quantity is out of stock", "Ok");
                    return;
                }

                if (userQuantity >= 1)
                {
                    ContentDisabled = true;
                    var response = await cartService.AddToCartAsync(new CartModel()
                    {
                        ProductId = selectedProduct.Id,
                        ProductImage = selectedProduct.Image,
                        ProductName = selectedProduct.Name,
                        ProductPrice = selectedProduct.Price,
                        OrderQuantity = userQuantity
                    });

                    bool complete = await DisplayToast.Maketoast(response.Message);
                    if (complete)
                    {
                        await Task.Delay(2000);
                        ContentDisabled = false;
                    }
                    await Shell.Current.DisplayAlert("Success", response.Message, "Ok");
                }
            }
            catch (Exception) { await Shell.Current.DisplayAlert("Alert", "Invalid entry", "Ok"); }
        }
    }
}
