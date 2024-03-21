using ArtWorkWeb.Service.Interfaces;
using AutoMapper;
using BussinessTier.Constants;
using BussinessTier.Payload;
using BussinessTier.Payload.ArtWork;
using DataTier.Models;
using DataTier.Repository.Implement;
using DataTier.Repository.Interface;
using DataTier.View.Product;

namespace ArtWorkWeb.Service.Implement
{
    public class ArWorkService : BaseService<ArWorkService>, IArtWorkService
    {
        public ArWorkService(IUnitOfWork<projectSWDContext> unitOfWork, ILogger<ArWorkService> logger, IMapper mapper,
           IHttpContextAccessor httpContextAccessor) : base(unitOfWork, logger, mapper, httpContextAccessor)
        {
        }

        public async Task<int> CreateNewArtwork(CreateArtWorkRequest request)
        {

            Artwork newArtWork = _mapper.Map<Artwork>(request);

            await _unitOfWork.GetRepository<Artwork>().InsertAsync(newArtWork);

            bool isSuccessful = await _unitOfWork.CommitAsync() > 0;

            return newArtWork.IdArtwork;
        }

        public async Task<GetArtWorkResponse> GetArtWrokById(int artWorkId)
        {
            Artwork artwork = await _unitOfWork.GetRepository<Artwork>().SingleOrDefaultAsync(
                predicate: x => x.IdArtwork.Equals(artWorkId))
                ?? throw new BadHttpRequestException(MessageConstant.ArtWork.ArtWorkNotFoundMessage);

            GetArtWorkResponse response = _mapper.Map<GetArtWorkResponse>(artwork);
            return response;
        }

        public async Task<IPaginate<GetArtWorkResponse>> GetAllArtWorks(ArtWorkFilter filter, PagingModel pagingModel)
        {
            // Example of authorizing user filter.Owner = 1;
            IPaginate<GetArtWorkResponse> response = await _unitOfWork.GetRepository<Artwork>().GetPagingListAsync(
                //selector: x => _mapper.Map<GetArtWorkResponse>(x),
                selector: a => new GetArtWorkResponse
                {
                    IdArtwork = a.IdArtwork,
                    Name = a.Name,
                    Price = a.Price,
                    Owner = a.Owner,
                    Status = a.Status,
                    CategoryName = a.CategoryName,
                    Author = a.Author,
                    ImageLists = a.ImageLists
                },
                filter: filter,
                orderBy: x => x.OrderBy(x => x.Name),
                page: pagingModel.page,
                size: pagingModel.size
                );
            return response;
        }

        public async Task<bool> UpdateArtWorkInfo(int artWorkID, UpdateArtWorkRequest request)
        {
            _logger.LogInformation($"Start updating product: {artWorkID}");


            Artwork updateArtWork = await _unitOfWork.GetRepository<Artwork>().SingleOrDefaultAsync(
                predicate: x => x.IdArtwork.Equals(artWorkID))
                ?? throw new BadHttpRequestException(MessageConstant.ArtWork.ArtWorkNotFoundMessage);

            var imgLists = await _unitOfWork.GetRepository<ImageList>().GetListAsync(predicate: x => x.ArtworkId.Equals(artWorkID));
            if (imgLists != null && imgLists.Any())
            {
                _unitOfWork.GetRepository<ImageList>().DeleteRangeAsync(imgLists);
            }
            updateArtWork.Name = string.IsNullOrEmpty(request.Name) ? updateArtWork.Name : request.Name;
            updateArtWork.Owner = request.Owner;
            updateArtWork.Price = request.Price;
            updateArtWork.Status = request.Status;
            updateArtWork.Owner = request.Owner;
            updateArtWork.Author = request.Author;
            updateArtWork.CategoryName = request.CategoryName;
            updateArtWork.ImageLists = request.ImageLists.Select(x => new ImageList
            {
                ArtworkId = updateArtWork.IdArtwork,
                ImageUrl = x.ImageUrl,
                IdImageList = x.IdImageList ?? 0
            }).ToList();


            _unitOfWork.GetRepository<Artwork>().UpdateAsync(updateArtWork);
            bool isSuccessful = await _unitOfWork.CommitAsync() > 0;
            return isSuccessful;
        }

        public async Task<bool> DeleteArtWork(int artWorkId)
        {
            Artwork artWork = await _unitOfWork.GetRepository<Artwork>().SingleOrDefaultAsync(
                predicate: x => x.IdArtwork.Equals(artWorkId))
                ?? throw new BadHttpRequestException(MessageConstant.ArtWork.ArtWorkNotFoundMessage);

            artWork.Status = "Inactive";

            _unitOfWork.GetRepository<Artwork>().UpdateAsync(artWork);
            bool isSuccessful = await _unitOfWork.CommitAsync() > 0;
            return isSuccessful;
        }

        /// <summary>
        /// Lấy ra danh sách category và số lượng sản phẩm theo category
        /// </summary>
        /// <returns></returns>
        public async Task<List<CategoryViewModel>> GetAllCategories()
        {
            var categories = await _unitOfWork.GetRepository<Artwork>().GetListAsync();
            var productByCategory = categories.GroupBy(x => x.CategoryName)
                .Select(x => new CategoryViewModel
                {
                    Name = x.Key,
                    TotalProduct = x.Count()
                }).ToList();
            return productByCategory;
        }

        public async Task<bool> ArtWorkOrder(int id)
        {
            // tạo order mới
            _ = _unitOfWork.GetRepository<Order>().InsertAsync(new Order
            {
                ArtworkId = id,
                UserId = 1,
                Date = DateTime.Now,
                OrderStatus = 1
            });

            // cập nhật lại trạng thái của sản phẩm
            Artwork artWork = (await _unitOfWork.GetRepository<Artwork>().SingleOrDefaultAsync(
                               predicate: x => x.IdArtwork.Equals(id))
                ?? throw new BadHttpRequestException(MessageConstant.ArtWork.ArtWorkNotFoundMessage)) ?? throw new BadHttpRequestException(MessageConstant.ArtWork.ArtWorkNotFoundMessage);
            artWork.Status = "Sold out";
            _unitOfWork.GetRepository<Artwork>().UpdateAsync(artWork);

            bool isSuccessful = await _unitOfWork.CommitAsync() > 0;
            return isSuccessful;
        }
    }
}
