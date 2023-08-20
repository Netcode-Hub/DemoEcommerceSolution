using DemoEcommerce.Client.ViewModels;

namespace DemoEcommerce.Client.Views.Phone;

public partial class PhoneHomePage : ContentPage
{
	public PhoneHomePage(PhoneHomePageViewModel phoneHomePageViewModel)
	{
		InitializeComponent();
		BindingContext = phoneHomePageViewModel;
	}
}