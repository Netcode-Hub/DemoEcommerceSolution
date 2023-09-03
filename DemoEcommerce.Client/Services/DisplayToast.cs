using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
namespace DemoEcommerce.Client.Services
{
    public class DisplayToast
    {
        public static async Task<bool> Maketoast(string message)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            ToastDuration duration = ToastDuration.Short;
            double fontSize = 18;
            var toast = Toast.Make(message, duration, fontSize);
            await toast.Show(cancellationTokenSource.Token);
            return true;
        }
    }
}
