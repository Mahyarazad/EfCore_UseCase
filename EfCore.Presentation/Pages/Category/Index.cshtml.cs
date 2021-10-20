using System.Collections.Generic;
using EfCore.Application.Contract.Category;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EfCore.Presentation.Pages.Category
{
    public class CategoryIndex : PageModel
    {
        public List<Domain.CategoryAgg.CategoryViewModel> Categories;
        private readonly ICategoryApplication _categoryApplication;

        public CategoryIndex(ICategoryApplication categoryApplication)
        {
            this._categoryApplication = categoryApplication;
        }

        public void OnGet(string name)
        {
            Categories = _categoryApplication.Search(name);
        }
    }
}
