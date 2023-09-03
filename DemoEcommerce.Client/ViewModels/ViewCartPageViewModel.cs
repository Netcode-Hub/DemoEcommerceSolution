using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DemoEcommerce.Client.Services;
using DemoEcommerce.Library.ClientModels;
using MvvmHelpers;

namespace DemoEcommerce.Client.ViewModels
{
    public partial class ViewCartPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private int numberOfItemsR;

        [ObservableProperty]
        private decimal discountR;

        [ObservableProperty]
        private decimal taxR;

        [ObservableProperty]
        private string grandTotalR;

        [ObservableProperty]
        private string payableAmountR;

        [ObservableProperty]
        private bool showCartEmptyLabel;

        [ObservableProperty]
        private bool showCartLabel;

        private readonly ICartService cartService;
        public ObservableRangeCollection<CartModel> MyCartModel { get; set; } = new();
        public ViewCartPageViewModel(ICartService cartService)
        {
            this.cartService = cartService;
            Title = "My Cart";
            ShowCartEmptyLabel = false;
            ShowCartLabel = false;
        }

        [RelayCommand]
        private async Task LoadMyCart()
        {
            ShowCartLabel = false;
            var myCarts = await cartService.GetMyCartAsync();
            if (MyCartModel.Count > 0)
                MyCartModel.Clear();

            if (myCarts is null)
            {
                ShowCartEmptyLabel = true;
                return;
            }
            MyCartModel.AddRange(myCarts);
            GetCheckSummary();
            ShowCartLabel = true;
            ShowCartEmptyLabel = false;
        }

        private void GetCheckSummary()
        {
            NumberOfItemsR = MyCartModel.Select(_ => _.OrderQuantity).Sum();
            decimal grandTotal = (decimal)MyCartModel.Select(_ => _.SubTotal).Sum();

            TaxR = 3M;
            DiscountR = 0.5M;

            decimal TaxAmount = TaxR > 0 ? (TaxR / 100) * grandTotal : 0;
            decimal DiscountAmount = DiscountR > 0 ? (DiscountR / 100) * grandTotal : 0;
            decimal payableAmount = (grandTotal + TaxAmount) - DiscountAmount;

            GrandTotalR = grandTotal.ToString("GHS 0.00");
            PayableAmountR = payableAmount.ToString("GHS 0.00");


        }
    }
}
