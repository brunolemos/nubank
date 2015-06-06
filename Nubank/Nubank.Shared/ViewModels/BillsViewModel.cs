using Newtonsoft.Json;
using Nubank.API.Responses;
using Nubank.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage;

namespace Nubank.ViewModels
{
    public class BillsViewModel : ViewModelBase
    {
        public List<Bill> Bills { get { return bills; } private set { bills = value; NotifyPropertyChanged("Bills"); } }
        private List<Bill> bills;

        public BillsViewModel()
        {
            Init();
        }

        public async Task Init()
        {
            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///bills.json"));
            string json = await FileIO.ReadTextAsync(file);
            Bills = JsonConvert.DeserializeObject<BillsResponse>(json).Bills;
        }
    }
}