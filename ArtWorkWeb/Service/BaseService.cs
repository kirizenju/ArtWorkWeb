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

        protected ILogger<ArWorkService> logger;
        protected IMapper _mapper;
        protected IHttpContextAccessor httpContextAccessor;

        public BaseService(IUnitOfWork<projectSWDContext> unitOfWork, ILogger<T> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;

        }

        protected BaseService(IUnitOfWork<projectSWDContext> unitOfWork, ILogger<ArWorkService> logger, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this._unitOfWork = unitOfWork;
            this.logger = logger;
            this._mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
        }
    }
}