using DemoEcommerce.Client.Views.Desktop;

namespace DemoEcommerce.Client
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AddProductPage), typeof(AddProductPage));

        }
    }
}
