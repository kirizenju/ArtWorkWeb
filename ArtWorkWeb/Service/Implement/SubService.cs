
using AutoMapper;
using BussinessTier.Constants;
using BussinessTier.Payload.Sub;
using BussinessTier.Payload;
using DataTier.Models;
using DataTier.Repository.Implement;
using DataTier.Repository.Interface;
using ArtWorkWeb.Service;
using ArtWorkWeb.Service.Interfaces;

namespace SubWeb.Service.Implement
{
    public class SubService : BaseService<SubService>, ISubService
    {
        public SubService(IUnitOfWork<projectSWDContext> unitOfWork, ILogger<SubService> logger, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, logger, mapper, httpContextAccessor)
        {
        }
        public async Task<int> CreateNewSub(CreateSubRequest request)
        {

            Subscription newSub = _mapper.Map<Subscription>(request);

            await _unitOfWork.GetRepository<Subscription>().InsertAsync(newSub);

            bool isSuccessful = await _unitOfWork.CommitAsync() > 0;

            return newSub.IdSubscription;
        }

        public async Task<GetSubscriptionResponse> GetSubById(int SubId)
        {
            Subscription Sub = await _unitOfWork.GetRepository<Subscription>().SingleOrDefaultAsync(
                predicate: x => x.IdSubscription.Equals(SubId))
                ?? throw new BadHttpRequestException(MessageConstant.Sub.SubNotFoundMessage);

            GetSubscriptionResponse response = _mapper.Map<GetSubscriptionResponse>(Sub);
            return response;
        }

        public async Task<IPaginate<GetSubscriptionResponse>> GetAllSubs(SubFilter filter, PagingModel pagingModel)
        {
            IPaginate<GetSubscriptionResponse> response = await _unitOfWork.GetRepository<Subscription>().GetPagingListAsync(
                selector: x => _mapper.Map<GetSubscriptionResponse>(x),
                filter: filter,
                orderBy: x => x.OrderBy(x => x.SubscriptionName),
                page: pagingModel.page,
                size: pagingModel.size
                );
            return response;
        }

        public async Task<bool> UpdateSubInfo(int SubID, UpdateSubscriptionRequest request)
        {
            _logger.LogInformation($"Start updating product: {SubID}");


            Subscription updateSub = await _unitOfWork.GetRepository<Subscription>().SingleOrDefaultAsync(
                predicate: x => x.IdSubscription.Equals(SubID))
                ?? throw new BadHttpRequestException(MessageConstant.Sub.SubNotFoundMessage);

            updateSub.SubscriptionName = string.IsNullOrEmpty(request.SubscriptionName) ? updateSub.SubscriptionName : request.SubscriptionName;
            updateSub.DesSubscription = request.DesSubscription;
            updateSub.Amount = request.Amount;

            _unitOfWork.GetRepository<Subscription>().UpdateAsync(updateSub);
            bool isSuccessful = await _unitOfWork.CommitAsync() > 0;
            return isSuccessful;
        }

        public async Task<bool> DeleteSub(int SubId)
        {
            Subscription Sub = await _unitOfWork.GetRepository<Subscription>().SingleOrDefaultAsync(
                predicate: x => x.IdSubscription.Equals(SubId))
                ?? throw new BadHttpRequestException(MessageConstant.Sub.SubNotFoundMessage);


            _unitOfWork.GetRepository<Subscription>().DeleteAsync(Sub);
            bool isSuccessful = await _unitOfWork.CommitAsync() > 0;
            return isSuccessful;
        }
    }
}
