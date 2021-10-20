using System.Collections.Generic;

namespace EfCore.Application.Contract.Category
{
    public interface ICategoryApplication
    {
        void Create(CreateCategory command, string name);
        void Edit(EditCategory command, string name, int id);
        List<Domain.CategoryAgg.CategoryViewModel> Search(string search);
        Domain.CategoryAgg.CategoryViewModel GetDetail(int id);
        List<Domain.CategoryAgg.CategoryViewModel> GetAll();
    }
}
