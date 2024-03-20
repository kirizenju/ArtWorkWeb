using BussinessTier.Payload;
using BussinessTier.Payload.Sub;
using DataTier.Repository.Implement;

namespace ArtWorkWeb.Service.Interfaces
{
    public interface ISubService
    {
        Task<int> CreateNewSub(CreateSubRequest request);
        Task<bool> DeleteSub(int SubId);
        Task<IPaginate<GetSubscriptionResponse>> GetAllSubs(SubFilter filter, PagingModel pagingModel);
        Task<GetSubscriptionResponse> GetSubById(int SubId);
        Task<bool> UpdateSubInfo(int SubID, UpdateSubscriptionRequest request);
    }
}
