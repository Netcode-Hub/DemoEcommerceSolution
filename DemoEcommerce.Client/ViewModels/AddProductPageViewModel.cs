
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using DemoEcommerce.Client.Services;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Alerts;
using MvvmHelpers;
using DemoEcommerce.Library.ClientModels;

namespace DemoEcommerce.Client.ViewModels
{
    public partial class AddProductPageViewModel : BaseViewModel
    {
        public ObservableRangeCollection<CategoryModel> Categories { get; set; } = new();

        [ObservableProperty]
        private ProductModel _addProductModel;

        [ObservableProperty]
        ImageSource _imageSourceFile;

        [ObservableProperty]
        private CategoryModel _selectedItem;

        private readonly IProductService productService;
        public AddProductPageViewModel(IProductService productService)
        {
            Title = "Add Product";
            AddProductModel = new ProductModel();
            this.productService = productService;
            LoadCategories();
        }
        [RelayCommand]
        public async Task AddImage()
        {
            var image = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Select Product Image",
                FileTypes = FilePickerFileType.Images
            });

            if (image is null)
                return;

            string imageFormat = string.Empty;
            if (image.FileName.ToLower().Contains(".png"))
            {
                imageFormat = "image/png";
            }

            if (image.FileName.ToLower().Contains(".jpg"))
            {
                imageFormat = "image/jpg";
            }

            if (imageFormat != "" || !string.IsNullOrEmpty(imageFormat) || !string.IsNullOrWhiteSpace(imageFormat))
            {
                byte[] imageByte;
                var newFile = Path.Combine(FileSystem.CacheDirectory, image.FileName);
                var stream = await image.OpenReadAsync();
                using (MemoryStream memory = new())
                {
                    stream.CopyTo(memory);
                    imageByte = memory.ToArray();
                }
                //converting to base64string
                var convertedImage = Convert.ToBase64String(imageByte);
                AddProductModel.Image = convertedImage;
                var x = string.Format($"data:{imageFormat};base64,{convertedImage}");

                //converting from base64string to image
                var ingt = Convert.FromBase64String(convertedImage);
                MemoryStream memoryStream = new(ingt);
                ImageSourceFile = ImageSource.FromStream(() => memoryStream);
            }
            else
            {
                await Shell.Current.DisplayAlert("Älert", "Invalid image format slected", "Ok");
            }

        }


        [RelayCommand]
        public async Task SaveProductData()
        {
            if (SelectedItem is null)
                return;

            if (AddProductModel is null)
                return;

            AddProductModel.CategoryId = SelectedItem.Id;
            var result = await productService.AddProductAsync(AddProductModel);
            await DisplayToast.Maketoast(result.Message);
        }

        private async void LoadCategories()
        {
            var categories = await productService.GetCategoriesAsync();
            if (categories is null)
                return;

            if (Categories.Count > 0)
                Categories.Clear();

            foreach (var category in categories)
                Categories.Add(category);
        }

    }
}
