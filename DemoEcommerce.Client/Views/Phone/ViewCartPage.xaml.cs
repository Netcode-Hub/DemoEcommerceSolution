using DemoEcommerce.Client.ViewModels;

namespace DemoEcommerce.Client.Views.Phone;

public partial class ViewCartPage : ContentPage
{
    private readonly ViewCartPageViewModel viewCartPageViewModel;

    public ViewCartPage(ViewCartPageViewModel viewCartPageViewModel)
	{
		InitializeComponent();
		BindingContext = viewCartPageViewModel;
        this.viewCartPageViewModel = viewCartPageViewModel;
    }

    protected override void OnAppearing()
    {
        viewCartPageViewModel.LoadMyCartCommand.Execute(this);
    }
}