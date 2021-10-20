using System;
using EfCore.Domain.CategoryAgg;
namespace EfCore.Domain.ProductAgg
{
    public class Product
    {
        public Product(string productName, string productDescription, double unitPrice, int categoryId)
        {
            ProductName = productName;
            ProductDescription = productDescription;
            UnitPrice = unitPrice;
            CategoryId = categoryId;
            CreationTime = DateTime.Now;
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public DateTime CreationTime { get; set; }
        public double UnitPrice { get; set; }
        public bool IsDeleted { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public void Remove()
        {
            IsDeleted = true;
        }
        public void Restore()
        {
            IsDeleted = false;
        }

        public void EditProduct(string alterName, string alterDescription, double alterPrice, int alterCategoryId)
        {
            ProductName = alterName;
            ProductDescription = alterDescription;
            UnitPrice = alterPrice;
            CategoryId = alterCategoryId;
        }


    }
}
