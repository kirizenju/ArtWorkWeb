
using BussinessTier.Payload;
using BussinessTier.Payload.ArtWork;
using DataTier.Repository.Implement;

namespace ArtWorkWeb.Service.Interfaces
{
    public interface IArtWorkService
    {
        Task<int> CreateNewArtwork(CreateArtWorkRequest request);
        Task<bool> DeleteArtWork(int artWorkId);
        Task<IPaginate<GetArtWorkResponse>> GetArtWorks(ArtWorkFilter filter, PagingModel pagingModel);
        Task<GetArtWorkResponse> GetArtWrokById(int artWorkId);
        Task<bool> UpdateArtWorkInfo(int artWorkID, UpdateArtWorkRequest request);
    }
}
