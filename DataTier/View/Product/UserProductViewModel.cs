using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier.View.Product
{
    public class UserProductViewModel
    {
        public int IdArtwork { get; set; }
        public string? Name { get; set; }
        public int IdUser { get; set; }
        public string Username { get; set; } = null!;
        public string? CategoryName { get; set; }
        public string? Status { get; set; }
        public decimal? Price { get; set; }
        public string? Address { get; set; }
       
    }
}
