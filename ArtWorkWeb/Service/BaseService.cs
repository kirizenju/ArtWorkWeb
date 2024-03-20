using ArtWorkWeb.Service.Implement;
using AutoMapper;
using DataTier.Models;
using DataTier.Repository.Interface;

namespace ArtWorkWeb.Service
{
    public abstract class BaseService<T> where T : class
    {
        protected IUnitOfWork<projectSWDContext> _unitOfWork;
        protected ILogger<T> _logger;
        protected IMapper _mapper;
        protected IHttpContextAccessor _httpContextAccessor;

        protected BaseService(IUnitOfWork<projectSWDContext> unitOfWork, ILogger<T> logger, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}