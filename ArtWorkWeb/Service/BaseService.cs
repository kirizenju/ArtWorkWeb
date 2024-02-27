using DataTier.Models;
using DataTier.Repository.Interface;

namespace ArtWorkWeb.Service
{
    public abstract class BaseService<T> where T : class
    {
        protected IUnitOfWork<projectSWDContext> _unitOfWork;
        protected ILogger<T> _logger;

        public BaseService(IUnitOfWork<projectSWDContext> unitOfWork, ILogger<T> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;

        }
    }
}