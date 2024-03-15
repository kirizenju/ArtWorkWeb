using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Login_Signup.Models
{
    public class OrderUpdateModel
    {
        public string CustomerName { get; set; }
        public string CustomerNumber { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerAddress { get; set; }
        // Các thuộc tính khác bạn muốn cập nhật
    }
}
