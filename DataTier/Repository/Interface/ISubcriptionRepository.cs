using DataTier.View.Subcription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier.Repository.Interface
{
    public interface ISubcriptionRepository
    {
        List<SubcriptionViewModel> GetAllSub();
    }
}
