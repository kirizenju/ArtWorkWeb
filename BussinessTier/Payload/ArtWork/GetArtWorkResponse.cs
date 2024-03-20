using DataTier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessTier.Payload.ArtWork
{
    public class GetArtWorkResponse
    {
        public GetArtWorkResponse() { }
        public int IdArtwork { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public int? Owner { get; set; }
        public string? Status { get; set; }
        public string? CategoryName { get; set; }
        public string? Author { get; set; }
        public virtual ICollection<ImageList> ImageLists { get; set; }
    }
}
