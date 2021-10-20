using System.Collections.Generic;
using System.Linq;
using EfCore.Application.Contract.Category;
using EfCore.Domain.CategoryAgg;
using CategoryViewModel = EfCore.Domain.CategoryAgg.CategoryViewModel;


namespace EfCore.InfraStructure.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly EfContext _efContext;

        public CategoryRepository(EfContext efContext)
        {
            _efContext = efContext;
        }

        public bool Exists(string name)
        {
            return _efContext.Categories.Any(x => x.CategoryName == name);
        }

        public void Create(Category category)
        {
            _efContext.Categories.Add(category);
            SaveChanges();
        }
        public void Edit(Category category)
        {
            var target = category.CategoryName;
            SaveChanges();
        }

        public Category Get(int id)
        {
            return _efContext.Categories.FirstOrDefault(x => x.CategoryId == id);
        }

        public CategoryViewModel GetDetail(int id)
        {
            return _efContext.Categories
                .Select(x => new CategoryViewModel { CategoryId = x.CategoryId, CategoryName = x.CategoryName })
                .FirstOrDefault(x => x.CategoryId == id);

        }

        public List<CategoryViewModel> Search(string name)
        {
            var query = _efContext.Categories.Select(x => new CategoryViewModel
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName,
                CreationTime = x.CreationTime.ToString()
            });

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(x => x.CategoryName.Contains(name));
            }

            return query.OrderByDescending(x => x.CategoryId).ToList();
        }

        public void SaveChanges()
        {
            _efContext.SaveChanges();
        }

        public List<CategoryViewModel> GetAll()
        {
            return _efContext.Categories.Select(x => new CategoryViewModel
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName
            }).ToList();
        }
    };

}
