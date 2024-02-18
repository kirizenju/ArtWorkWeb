using DataTier.Models;
using DataTier.Repository.Interface;

namespace ArtWorkWeb.Service
{
    public abstract class BaseService<T> where T : class
    {
        protected IUnitOfWork<ArtWorkDBContext> _unitOfWork;
        protected ILogger<T> _logger;

        public BaseService(IUnitOfWork<ArtWorkDBContext> unitOfWork, ILogger<T> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;

        }
    }
}