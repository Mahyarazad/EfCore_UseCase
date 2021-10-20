using System;

namespace EfCore.Application.Contract.Product
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public DateTime CreationTime { get; set; }
    }
}