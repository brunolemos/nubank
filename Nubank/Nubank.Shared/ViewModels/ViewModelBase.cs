using Nubank.Common;
using Nubank.Utils;

namespace Nubank.ViewModels
{
    public class ViewModelBase : Notifiable
    {
        public LocalizedResources LocalizedResources { get { return LocalizedResources.Instance; } }
    }
}
