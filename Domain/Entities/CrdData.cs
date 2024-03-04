using Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CrdData : BaseEntity<long>
    {
        public string caller_id { get; set; }
        public string recipient { get; set; }
        public DateTime call_date { get; set; }
        public DateTime end_time { get; set; }
        public int duration { get; set; }
        public decimal cost { get; set; }
        public string reference { get; set; }
        public string currency { get; set; }

        public CrdData(long id, string caller_id, string recipient, DateTime call_date, DateTime end_time,
            int duration, decimal cost, string reference, string currency) : base(id)
        {
            this.caller_id = caller_id;
            this.recipient = recipient;
            this.call_date = call_date;
            this.end_time = end_time;
            this.duration = duration;
            this.cost = cost;
            this.reference = reference;
            this.currency = currency;
        }
    }
}
