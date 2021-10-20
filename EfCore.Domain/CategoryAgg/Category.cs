using System;
using System.Collections.Generic;
using EfCore.Domain.ProductAgg;

namespace EfCore.Domain.CategoryAgg
{
    public class Category
    {

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime CreationTime { get; set; }
        public List<Product> Products { get; set; }
        public Category(string categoryName)
        {
            CategoryName = categoryName;
            CreationTime = DateTime.Now;
            Products = new List<Product>();

        }

        public void Edit(string alterName)
        {
            CategoryName = alterName;
        }
    }

}

