using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier.View.Subcription
{
    public class SubcriptionViewModel
    {
        public int IdSubscription { get; set; }
        public decimal Amount { get; set; }
        public string? DesSubscription { get; set; }
        public string? SubscriptionName { get; set; }
    }
}
