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
        public int Amount { get; private set; }

        [DataMember(Name = "title")]
        public string Title { get; private set; }

        [DataMember(Name = "index")]
        public ushort Index { get; private set; }

        [DataMember(Name = "charges")]
        public ushort Charges { get; private set; }

        [DataMember(Name = "href")]
        public Uri HREF { get; private set; }
    }
}
