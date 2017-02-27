using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapid.Model.ViewModels
{
    public class ProductViewModel
    {
        public bool DiscountIndicator { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string State { get; set; }
        public decimal TaxRate { get; set; }
        public int TotalQuantity { get; set; }
        public decimal TotalAmount { get; set; }
  
    }
}
