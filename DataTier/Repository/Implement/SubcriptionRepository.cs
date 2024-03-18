using DataTier.Models;
using DataTier.Repository.Interface;
using DataTier.View.Subcription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier.Repository.Implement
{
    public class SubcriptionRepository : ISubcriptionRepository
    {
        private readonly projectSWDContext _context;
        public SubcriptionRepository(projectSWDContext context)
        {
            _context = context;
        }

        public List<SubcriptionViewModel> GetAllSub()
        {
            return _context.Subscriptions.Select(e => new SubcriptionViewModel
            {
                IdSubscription = e.IdSubscription,
                Amount = e.Amount,
                DesSubscription = e.DesSubscription,
                SubscriptionName = e.SubscriptionName,
            }).ToList();
        }
    }
}
