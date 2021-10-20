
using System.Collections.Generic;
using EfCore.Application.Contract.Category;
using EfCore.Domain.CategoryAgg;
using CategoryViewModel = EfCore.Application.Contract.Category.CategoryViewModel;

namespace EfCore.Application
{
    public class CategoryApplication : ICategoryApplication
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryApplication(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void Create(CreateCategory command, string name)
        {
            if (_categoryRepository.Exists(name))
                return;
            var category = new Category(name);
            _categoryRepository.Create(category);
            _categoryRepository.SaveChanges();
        }

        public void Edit(EditCategory command, string name, int id)
        {

            var category = _categoryRepository.Get(id);
            if (category == null)
                return;
            category.Edit(name);
            _categoryRepository.SaveChanges();
        }

        public List<Domain.CategoryAgg.CategoryViewModel> Search(string search)
        {
            var res = _categoryRepository.Search(search);
            return res;
        }

        public Domain.CategoryAgg.CategoryViewModel GetDetail(int id)
        {
            return _categoryRepository.GetDetail(id);
        }
        public List<Domain.CategoryAgg.CategoryViewModel> GetAll()
        {
            return _categoryRepository.GetAll();
        }
    }
}
