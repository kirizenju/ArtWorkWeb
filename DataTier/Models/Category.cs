using System;
using System.Collections.Generic;

namespace DataTier.Models
{
    public partial class Category
    {
        public Category()
        {
            Artworks = new HashSet<Artwork>();
        }

        public int IdCategory { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Artwork> Artworks { get; set; }
    }
}
