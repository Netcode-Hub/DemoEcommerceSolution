using DemoEcommerce.Client.ViewModels;

namespace DemoEcommerce.Client.Views.Desktop;

public partial class AddProductPage : ContentPage
{
    public AddProductPage(AddProductPageViewModel addProductPageViewModel)
	{
		InitializeComponent();
		BindingContext = addProductPageViewModel;
    }


}