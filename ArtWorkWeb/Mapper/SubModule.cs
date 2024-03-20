using BussinessTier.Payload.ArtWork;
using BussinessTier.Payload.Sub;
using DataTier.Models;
using AutoMapper;

namespace ArtWorkWeb.Mapper
{
    public class SubModule:Profile
    {
        public SubModule()
        {
            CreateMap<CreateSubRequest, Subscription>();

            CreateMap<Subscription, GetSubscriptionResponse>();
        }
    }
}
