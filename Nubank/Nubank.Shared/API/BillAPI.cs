using Nubank.API.Responses;
using Nubank.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nubank.API
{
    public abstract class BillAPI : BaseAPI
    {
        protected const string SAMPLE_BILLS_URL = "https://s3-sa-east-1.amazonaws.com/mobile-challenge/bill/bill.json";

        public static async Task<List<Bill>> GetBills()
        {
            return (await TryGetDeserializedAsync<BillsResponse>(SAMPLE_BILLS_URL))?.Bills;
        }
    }
}
