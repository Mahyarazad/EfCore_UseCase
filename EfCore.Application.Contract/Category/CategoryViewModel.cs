using System;

namespace EfCore.Application.Contract.Category
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime CreationTime { get; set; }
    }
}