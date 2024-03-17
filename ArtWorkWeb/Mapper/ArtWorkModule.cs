using AutoMapper;
using BussinessTier.Payload.ArtWork;
using DataTier.Models;

namespace ArtWorkWeb.Mapper
{
    public class ArtWorkModule:Profile
    {
        public ArtWorkModule()
        {
            CreateMap<CreateArtWorkRequest, Artwork>();

            CreateMap<Artwork, GetArtWorkResponse>();
        }
    }
}
