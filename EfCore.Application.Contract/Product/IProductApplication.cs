using System.Collections.Generic;

namespace EfCore.Application.Contract.Product
{
    public interface IProductApplication
    {
        void Create(CreateProduct command, string name);
        void Delete(DeleteProduct command, int id);
        void Restore(RestoreProduct command, int id);
        void Edit(EditProduct command, string name, string description, int id, double price, int category);
        Domain.ProductAgg.ProductViewModel GetDetail(int id);
        List<Domain.ProductAgg.ProductViewModel> Search(Domain.ProductAgg.ProductSearchModel searchModel);
    }
}
