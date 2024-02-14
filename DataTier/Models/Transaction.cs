using System;
using System.Collections.Generic;

namespace DataTier.Models
{
    public partial class Transaction
    {
        public int IdPayment { get; set; }
        public int UserId { get; set; }
        public int SubscriptionId { get; set; }
        public DateTime Date { get; set; }

        public virtual Subscription Subscription { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
