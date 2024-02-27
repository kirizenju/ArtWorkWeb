using System;
using System.Collections.Generic;

namespace DataTier.Models
{
    public partial class Subscription
    {
        public Subscription()
        {
            Transactions = new HashSet<Transaction>();
        }

        public int IdSubscription { get; set; }
        public decimal Amount { get; set; }
        public string? DesSubscription { get; set; }
        public string? SubscriptionName { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
