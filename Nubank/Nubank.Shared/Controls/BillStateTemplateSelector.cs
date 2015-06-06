using Nubank.Models;
using Windows.ApplicationModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Nubank.Controls
{
    public class BillStateTemplateSelector : DataTemplateSelector
    {
        public DataTemplate OverdueBillItemTemplate { get; set; }
        public DataTemplate ClosedBillItemTemplate { get; set; }
        public DataTemplate OpenBillItemTemplate { get; set; }
        public DataTemplate FutureBillItemTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (DesignMode.DesignModeEnabled) return OverdueBillItemTemplate;

            BillState state = (item as Bill).State;

            switch (state)
            {
                case BillState.OVERDUE:
                    return OverdueBillItemTemplate;

                case BillState.CLOSED:
                    return ClosedBillItemTemplate;

                case BillState.OPEN:
                    return OpenBillItemTemplate;

                case BillState.FUTURE:
                    return FutureBillItemTemplate;

                default:
                    return OverdueBillItemTemplate;// base.SelectTemplateCore(item, container);
            }
        }
    }
}
