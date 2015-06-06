using Nubank.Models;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Nubank.API.Responses
{
    [DataContract]
    public class BillsResponse : List<BillsResponseItem>
    {
        public List<Bill> Bills { get; private set; } = new List<Bill>();

        [OnDeserialized]
        /// <summary>
        /// Convert a BillsResponse to a single List of Bills
        /// </summary>
        private void OnDeserialized(StreamingContext context)
        {
            foreach (var billResponse in this)
                foreach(var bill in billResponse.Bills)
                    Bills.Add(bill);
        }
    }
}