using CommunityToolkit.Maui;
using DemoEcommerce.Client.Services;
using DemoEcommerce.Client.ViewModels;
using DemoEcommerce.Client.Views.Desktop;
using DemoEcommerce.Client.Views.Phone;
using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;

namespace DemoEcommerce.Client
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureSyncfusionCore()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<DesktopHomePageViewModel>();
            builder.Services.AddSingleton<DesktopHomePage>();

            builder.Services.AddSingleton<AddProductPageViewModel>();
            builder.Services.AddSingleton<AddProductPage>();

            builder.Services.AddSingleton<PhoneHomePageViewModel>();
            builder.Services.AddSingleton<PhoneHomePage>();

            
            builder.Services.AddHttpClient<IProductService, ProductService>();
            
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
