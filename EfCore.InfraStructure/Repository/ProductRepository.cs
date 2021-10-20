using System.Collections.Generic;
using System.Linq;
using EfCore.Application.Contract.Product;
using EfCore.Domain.CategoryAgg;
using EfCore.Domain.ProductAgg;
using Microsoft.EntityFrameworkCore;
using ProductViewModel = EfCore.Domain.ProductAgg.ProductViewModel;


namespace EfCore.InfraStructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly EfContext _efContext;

        public ProductRepository(EfContext efContext)
        {
            _efContext = efContext;
        }

        public bool Exists(string name)
        {
            return _efContext.Products.Any(x => x.ProductName == name);
        }

        public void Create(Product product)
        {
            _efContext.Products.Add(product);
            SaveChanges();
        }
        public void Edit(Product product)
        {
            var target = product.ProductName;
            SaveChanges();
        }
        public void Delete(Product product)
        {
            var target = product.ProductName;
            SaveChanges();
        }
        public void Restore(Product product)
        {
            var target = product.ProductName;
            SaveChanges();
        }
        public Product Get(int id)
        {
            return _efContext.Products.FirstOrDefault(x => x.ProductId == id);
        }

        public ProductViewModel GetDetail(int id)
        {

            return _efContext.Products
                .Select(x => new ProductViewModel
                {
                    UnitPrice = x.UnitPrice,
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    ProductDescription = x.ProductDescription,
                    CreationTime = x.CreationTime.ToString(),
                    IsDeleted = x.IsDeleted,
                    CategoryName = x.Category.CategoryName,
                    CategoryId = x.Category.CategoryId
                })
                .FirstOrDefault(x => x.ProductId == id);

        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            var query = _efContext.Products
                .Include(x => x.Category)
                .Select(x => new ProductViewModel
                {
                    UnitPrice = x.UnitPrice,
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    ProductDescription = x.ProductDescription,
                    CreationTime = x.CreationTime.ToString(),
                    IsDeleted = x.IsDeleted,
                    CategoryName = x.Category.CategoryName

                });
            if (searchModel.IsDeleted == true)
            {
                query = query.Where(x => x.IsDeleted == true);
            }
            if (!string.IsNullOrWhiteSpace(searchModel.ProductName))
            {
                query = query.Where(x => x.ProductName.Contains(searchModel.ProductName));
            }

            return query.OrderByDescending(x => x.ProductId).ToList();
        }

        public void SaveChanges()
        {
            _efContext.SaveChanges();
        }
    };

}
