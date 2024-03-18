using DataTier.View.Common;
using DataTier.View.Subcription;

namespace ArtWorkWeb.Service.Interfaces
{
    public interface ISubcriptionService
    {
        KeyValuePair<MessageViewModel,List<SubcriptionViewModel>> GetAllSub();
    }
}
