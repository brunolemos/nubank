using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;

namespace Nubank.Controls
{
    public class FixedPivot : Pivot
    {
        protected PivotHeaderPanel PivotHeaderPanel { get; private set; }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

#if WINDOWS_PHONE_APP
            this.PivotHeaderPanel = (PivotHeaderPanel)this.GetTemplateChild("Header");
#else
            this.PivotHeaderPanel = (PivotHeaderPanel)this.GetTemplateChild("StaticHeader");
#endif

            this.Loaded += (s, e) => UpdateHeaderItemsOpacity();
            this.DataContextChanged += (s, e) => UpdateHeaderItemsOpacity();
            this.SelectionChanged += (s, e) => UpdateHeaderItemsOpacity();
        }

        private void UpdateHeaderItemsOpacity()
        {
            if (PivotHeaderPanel == null) return;

            for (int i = 0; i < PivotHeaderPanel.Children.Count; i++)
                if ((PivotHeaderPanel.Children[i] as PivotHeaderItem).ContentTemplateRoot != null)
                    (PivotHeaderPanel.Children[i] as PivotHeaderItem).ContentTemplateRoot.Opacity = this.SelectedIndex == i ? 1 : 0.4;
        }
    }
}
