

using System.Collections.Generic;
using EfCore.Domain.CategoryAgg;

namespace EfCore.Domain.ProductAgg
{
    public interface IProductRepository
    {
        bool Exists(string name);
        void Create(Product product);
        void Edit(Product product);
        void SaveChanges();
        void Delete(Product product);
        Domain.ProductAgg.Product Get(int id);
        ProductViewModel GetDetail(int id);
        List<ProductViewModel> Search(ProductSearchModel searchModel);

    }

    public class ProductViewModel
    {

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double UnitPrice { get; set; }
        public string CreationTime { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class ProductSearchModel
    {
        public string ProductName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
