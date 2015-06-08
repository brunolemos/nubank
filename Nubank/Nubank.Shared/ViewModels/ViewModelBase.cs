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
            //just to remove compile warning
            await Task.Delay(0);

#if WINDOWS_PHONE_APP
            StatusBar.GetForCurrentView().ProgressIndicator.Text = msg;
            await StatusBar.GetForCurrentView().ProgressIndicator.ShowAsync();
#endif
        }

        protected async Task HideLoadingIndicator()
        {
            await Task.Delay(0500);

#if WINDOWS_PHONE_APP
            await StatusBar.GetForCurrentView().ProgressIndicator.HideAsync();
#endif
        }
    }
}
