using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Nubank.Models
{
    /// <summary>
    /// Bill states:
    /// overdue: paid;
    /// closed: ready for payment but not yet paid;
    /// open: not yet closed, charges are still being added;
    /// future: installments/'parcelas' that will be charged to bills in future months.
    /// </summary>
    public enum BillState
    {
        OVERDUE,
        CLOSED,
        OPEN,
        FUTURE
    };

    [DataContract]
    public class Bill : ModelBase
    {
        [DataMember(Name = "id")]
        public string ID { get; private set; }

        [DataMember(Name = "state")]
        public BillState State { get; private set; }

        [DataMember(Name = "barcode")]
        public string Barcode { get; private set; }

        [DataMember(Name = "summary")]
        public Summary Summary { get; private set; }

        [DataMember(Name = "linha_digitavel")]
        public string TypefulLine { get; private set; }

        [DataMember(Name = "line_items")]
        public List<BillItem> Items { get; private set; }

        [DataMember(Name = "_links")]
        public Links Links { get; private set; }
    }
}
