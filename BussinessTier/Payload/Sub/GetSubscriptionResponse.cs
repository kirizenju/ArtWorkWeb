using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BussinessTier.Payload.Sub
{
    public class GetSubscriptionResponse
    {
        public GetSubscriptionResponse() { }
        public int IdSubscription { get; set; }
        public decimal Amount { get; set; }
        public string? DesSubscription { get; set; }
        public string? SubscriptionName { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
