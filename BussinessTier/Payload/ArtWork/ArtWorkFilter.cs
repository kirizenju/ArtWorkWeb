using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessTier.Payload.ArtWork
{
    public class ArtWorkFilter
    {
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public string? Status { get; set; }
        public string? CategoryName { get; set; }
    }
}
