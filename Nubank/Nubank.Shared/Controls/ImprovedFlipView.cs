using System;
using Windows.UI.Xaml.Controls;

namespace Nubank.Controls
{
    public class ImprovedFlipView : FlipView
    {
        public ScrollViewer ScrollViewer { get; private set; }
        private bool isIndirectManupulation { get; set; }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this.ScrollViewer = (ScrollViewer)this.GetTemplateChild("ScrollingHost");
            this.ScrollViewer.ViewChanged += OnViewChanged;
            this.SelectionChanged += OnSelectionChanged;
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = (int)Math.Round(this.ScrollViewer.HorizontalOffset - 2);
            isIndirectManupulation = this.SelectedIndex != index && Math.Abs(this.SelectedIndex - this.ScrollViewer.HorizontalOffset - 2) >= 1;
        }

        void OnViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {
#if WINDOWS_PHONE_APP
            int index = (int)Math.Round(this.ScrollViewer.HorizontalOffset - 2);

            if (!isIndirectManupulation && this.SelectedIndex != index)
                this.SelectedIndex = index;

            if (this.SelectedIndex == index && (e.IsIntermediate || Math.Abs(this.SelectedIndex - this.ScrollViewer.HorizontalOffset - 2) < 0.1))
                isIndirectManupulation = false;
#endif
        }
    }
}
