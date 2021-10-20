using System.Collections.Generic;
using EfCore.Application.Contract.Product;
using EfCore.Domain.CategoryAgg;
using EfCore.Domain.ProductAgg;
using ProductViewModel = EfCore.Domain.ProductAgg.ProductViewModel;

namespace EfCore.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;
        public ProductApplication(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public void Create(CreateProduct command, string name)
        {
            if (_productRepository.Exists(name))
                return;
            var product = new Product(command.ProductName, command.ProductDescription, command.UnitPrice,
                command.CategoryId);
            _productRepository.Create(product);
            _productRepository.SaveChanges();
        }
        public void Restore(RestoreProduct command, int id)
        {
            var product = _productRepository.Get(id);
            if (product == null)
                return;
            product.Restore();
            _productRepository.SaveChanges();
        }

        public void Edit(EditProduct command, string name, string description, int id, double price, int categoryId)
        {
            var product = _productRepository.Get(id);
            if (product == null)
                return;
            product.EditProduct(name, description, price, categoryId);
            _productRepository.SaveChanges();
        }
        public void Delete(DeleteProduct command, int id)
        {
            var product = _productRepository.Get(id);
            if (product == null)
                return;
            product.Remove();
            _productRepository.SaveChanges();
        }
        public List<Domain.ProductAgg.ProductViewModel> Search(ProductSearchModel searchModel)
        {
            return _productRepository.Search(searchModel);
        }
        public Domain.ProductAgg.ProductViewModel GetDetail(int id)
        {
            return _productRepository.GetDetail(id);
        }
    }
}
