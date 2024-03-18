using ArtWorkWeb.Service.Interfaces;
using AutoMapper;
using DataTier.Repository.Interface;
using DataTier.View.Common;
using DataTier.View.Subcription;

namespace ArtWorkWeb.Service.Implement
{
    public class SubcriptionService : ISubcriptionService
    {
        private readonly ISubcriptionRepository _subcriptionRepository;
        private readonly IMapper _mapper;
        public SubcriptionService(ISubcriptionRepository subcriptionRepository, IMapper mapper)
        {
            _subcriptionRepository = subcriptionRepository;
            _mapper = mapper;
        }

        public KeyValuePair<MessageViewModel, List<SubcriptionViewModel>> GetAllSub()
        {
            var response = _subcriptionRepository.GetAllSub();
            if(response == null)
            {
                return new KeyValuePair<MessageViewModel, List<SubcriptionViewModel>>(
                    new MessageViewModel
                    {
                        StatusCode = System.Net.HttpStatusCode.NotFound,
                        Message = "No Subcription found"
                    }, null
                    );
            }
            return new KeyValuePair<MessageViewModel, List<SubcriptionViewModel>>(
                new MessageViewModel
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Message = string.Empty
                },response
                );
        }
    }
}
