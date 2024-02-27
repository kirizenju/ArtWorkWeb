using System;
using System.Collections.Generic;

namespace DataTier.Models
{
    public partial class PreOrder
    {
        public int IdPreOrder { get; set; }
        public int UserId { get; set; }
        public string DescPreOrder { get; set; } = null!;
        public string Status { get; set; } = null!;
        public int ArtworkId { get; set; }

        public virtual Artwork Artwork { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
