using System;
using System.Runtime.Serialization;

namespace Nubank.Models
{
    [DataContract]
    public class BillItem : ModelBase
    {
        [DataMember(Name = "post_date")]
        public DateTime PostDate { get; private set; }

        [DataMember(Name = "amount")]
        public double Amount { get; private set; }

        [DataMember(Name = "title")]
        public string Title { get; private set; }

        [DataMember(Name = "index")]
        public short Index { get; private set; }

        [DataMember(Name = "charges")]
        public short Charges { get; private set; }

        [DataMember(Name = "href")]
        public string HREF { get; private set; }
    }
}
