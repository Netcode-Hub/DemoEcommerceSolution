using DemoEcommerce.Client.Views.Desktop;
using DemoEcommerce.Client.Views.Phone;

namespace DemoEcommerce.Client
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AddProductPage), typeof(AddProductPage));
            Routing.RegisterRoute(nameof(ViewCartPage), typeof(ViewCartPage));
        }
    }
}
