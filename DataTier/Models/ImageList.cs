using System;
using System.Collections.Generic;

namespace DataTier.Models
{
    public partial class ImageList
    {
        public int IdImageList { get; set; }
        public string ImageUrl { get; set; } = null!;
        public int ArtworkId { get; set; }

        public virtual Artwork Artwork { get; set; } = null!;
    }
}
