using Nubank.API;
using Nubank.Common;
using Nubank.Models;
using System.Collections.Generic;

namespace Nubank.ViewModels
{
    public sealed class BillsViewModel : ViewModelBase
    {
        public List<Bill> Bills { get { return bills; } private set { if (value != null) { bills = value; NotifyPropertyChanged("Bills"); } } }
        private List<Bill> bills;

        public RelayCommand LoadBillsCommand { get; private set; }

        public BillsViewModel()
        {
            LoadBillsCommand = new RelayCommand(LoadBills);

            LoadBills();
        }

        private async void LoadBills()
        {
            await ShowLoadingIndicator();
            Bills = await BillAPI.GetBills();
            await HideLoadingIndicator();
        }
    }
}