using System;
using System.Collections.Generic;

namespace DataTier.Models
{
    public partial class Order
    {
        public int IdOrder { get; set; }
        public int UserId { get; set; }
        public int ArtworkId { get; set; }
        public DateTime Date { get; set; }

        public virtual Artwork Artwork { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
