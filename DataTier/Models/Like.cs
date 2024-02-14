using System;
using System.Collections.Generic;

namespace DataTier.Models
{
    public partial class Like
    {
        public int IdLike { get; set; }
        public int UserId { get; set; }
        public int ArtworkId { get; set; }

        public virtual Artwork Artwork { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
