using Nubank.Models;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Nubank.API.Responses
{
    [DataContract]
    public class BillsResponse : List<BillsResponseItem>
    {
        /// <summary>
        /// Convert a BillsResponse to a single List of Bills
        /// </summary>
        public List<Bill> GetBills()
        {
            List<Bill> bills = new List<Bill>();

            foreach (var billResponse in this)
                foreach(var bill in billResponse.Bills)
                    bills.Add(bill);

            return bills;
        }
    }
}