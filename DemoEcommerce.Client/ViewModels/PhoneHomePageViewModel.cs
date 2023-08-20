using DemoEcommerce.Client.Models;
using DemoEcommerce.Client.Services;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEcommerce.Client.ViewModels
{
    public partial class PhoneHomePageViewModel : BaseViewModel
    {
        private readonly IProductService productService;

        public ObservableRangeCollection<ProductTem> Products { get; set; } = new();
        public PhoneHomePageViewModel(IProductService productService)
        {
            this.productService = productService;
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
                    var newProduct = new ProductTem();

                    if (product.Image != null)
                    {
                        //converting from base64string to image
                        var img = Convert.FromBase64String(product.Image);
                        MemoryStream memoryStream = new(img);
                        newProduct.Image = ImageSource.FromStream(() => memoryStream);
                    }

                    newProduct.Id = product.Id;
                    newProduct.Name = product.Name;
                    newProduct.Description = product.Description;
                    newProduct.Price = product.Price;
                    newProduct.Quantity = product.Quantity;
                    newProduct.CategoryId = product.CategoryId;

                    ProductsTem.Add(newProduct);
                }
            }
            catch (Exception) { }
        }
    }
}
