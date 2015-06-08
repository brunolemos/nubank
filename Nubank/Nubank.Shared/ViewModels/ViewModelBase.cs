using System;
using Nubank.Common;
using Nubank.Utils;
using System.Threading.Tasks;
using Windows.UI.ViewManagement;

namespace Nubank.ViewModels
{
    public class ViewModelBase : Notifiable
    {
        public LocalizedResources LocalizedResources { get { return LocalizedResources.Instance; } }

        protected async Task ShowLoadingIndicator(string msg = "Carregando...")
        {
#if WINDOWS_PHONE_APP
            StatusBar.GetForCurrentView().ProgressIndicator.Text = msg;
            await StatusBar.GetForCurrentView().ProgressIndicator.ShowAsync();
#endif
        }

        protected async Task HideLoadingIndicator()
        {
#if WINDOWS_PHONE_APP
            await Task.Delay(0500);
            await StatusBar.GetForCurrentView().ProgressIndicator.HideAsync();
#endif
        }
    }
}
