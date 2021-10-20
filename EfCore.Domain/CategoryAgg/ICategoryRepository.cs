using System.Collections.Generic;

namespace EfCore.Domain.CategoryAgg
{
    public interface ICategoryRepository
    {
        bool Exists(string name);
        void Create(Category category);
        void Edit(Category category);
        void SaveChanges();
        Domain.CategoryAgg.Category Get(int id);
        CategoryViewModel GetDetail(int id);
        List<CategoryViewModel> Search(string name);
        List<Domain.CategoryAgg.CategoryViewModel> GetAll();
    }

    public class CategoryViewModel
    {

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CreationTime { get; set; }
    }
}
