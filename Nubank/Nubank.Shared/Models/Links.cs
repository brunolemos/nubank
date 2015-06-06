using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Nubank.Models
{
    [DataContract]
    public class Links : Dictionary<string, LinkContent> { }

    [DataContract]
    public class LinkContent
    {
        [DataMember(Name = "href")]
        public string HREF { get; private set; }
    }
}
