using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessTier.Payload.ArtWork
{
    public class UpdateArtWorkRequest
    {
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public int? Owner { get; set; }
        public string? Status { get; set; }
        public string? CategoryName { get; set; }
        public string? Author { get; set; }
        public virtual ICollection<ImageListCustom>? ImageLists { get; set; }
    }

    public class ImageListCustom
    {
        public int? IdImageList { get; set; }
        public string ImageUrl { get; set; } = null!;
        public int? ArtworkId { get; set; }
    }
}
