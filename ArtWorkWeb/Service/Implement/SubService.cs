using ArtWorkWeb.Service.Interfaces;
using AutoMapper;
using DataTier.Models;
using DataTier.Repository.Interface;
using Microsoft.AspNetCore.Http;

namespace ArtWorkWeb.Service.Implement
{
    public class SubService : BaseService<SubService>, ISubService
    {
        public SubService(IUnitOfWork<projectSWDContext> unitOfWork, ILogger<SubService> logger, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, logger, mapper, httpContextAccessor)
        {
        }
    }
}
