using DemoEcommerce.Library.ClientModels;

namespace DemoEcommerce.Client
{
    public partial class App : Application
    {
        public static List<CartModel> MyCart { get; set; } = new List<CartModel>();
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
