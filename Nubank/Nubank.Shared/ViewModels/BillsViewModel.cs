using Nubank.API;
using Nubank.Models;
using System.Collections.Generic;

namespace Nubank.ViewModels
{
    public sealed class BillsViewModel : ViewModelBase
    {
        public List<Bill> Bills { get { return bills; } private set { bills = value; NotifyPropertyChanged("Bills"); } }
        private List<Bill> bills;

        public BillsViewModel()
        {
            LoadBills();
        }

        private async void LoadBills()
        {
            Bills = await BillAPI.GetBills();
        }
    }
}