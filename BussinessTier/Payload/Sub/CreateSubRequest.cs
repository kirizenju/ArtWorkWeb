using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessTier.Payload.Sub
{
    public class CreateSubRequest
    {
        public decimal Amount { get; set; }
        public string? DesSubscription { get; set; }
        public string? SubscriptionName { get; set; }
    }
}
