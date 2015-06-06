using System;
using Windows.UI.Xaml.Controls;

namespace Nubank.Controls
{
    public class ImprovedFlipView : FlipView
    {
        public ScrollViewer ScrollViewer { get; private set; }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this.ScrollViewer = (ScrollViewer)this.GetTemplateChild("ScrollingHost");
            this.ScrollViewer.ViewChanged += ScrollViewer_ViewChanged;
        }

        void ScrollViewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {
#if WINDOWS_PHONE_APP
            int index = (int)Math.Round(this.ScrollViewer.HorizontalOffset - 2);
            if (this.SelectedIndex != index) this.SelectedIndex = index;
#endif
        }
    }
}
