using System;
using System.Runtime.Serialization;

namespace Nubank.Models
{
    [DataContract]
    public class Summary : ModelBase
    {
        [DataMember(Name = "due_date")]
        public DateTime DueDate { get; private set; }

        [DataMember(Name = "open_date")]
        public DateTime OpenDate { get; private set; }

        [DataMember(Name = "close_date")]
        public DateTime CloseDate { get; private set; }

        [DataMember(Name = "past_balance")]
        public double PastBalance { get; private set; }

        [DataMember(Name = "total_balance")]
        public double TotalBalance { get; private set; }

        [DataMember(Name = "interest")]
        public double Interest { get; private set; }

        [DataMember(Name = "total_cumulative")]
        public double TotalCumulative { get; private set; }

        [DataMember(Name = "paid")]
        public double Paid { get; private set; }

        [DataMember(Name = "minimum_payment")]
        public double MinimumPayment { get; private set; }
    }
}
