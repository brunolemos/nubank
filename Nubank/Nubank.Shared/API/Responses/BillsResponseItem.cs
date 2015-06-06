using Nubank.Models;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Nubank.API.Responses
{
    [DataContract]
    public class BillsResponseItem
    {
        [DataMember(Name = "bill")]
        private Bill bill;

        [DataMember(Name = "bills")]
        public List<Bill> Bills { get; private set; }

        [OnDeserialized]
        private void MoveItemToArray(StreamingContext context)
        {
            if (Bills == null) Bills = new List<Bill>();
            if (bill != null) Bills.Insert(0, bill);

            bill = null;
        }
    }
}
