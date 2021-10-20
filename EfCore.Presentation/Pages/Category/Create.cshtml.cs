using System.Collections.Generic;
using EfCore.Application.Contract.Category;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EfCore.Presentation.Pages.Category
{
    public class CreateModel : PageModel
    {
        public List<Domain.CategoryAgg.Category> Categories;
        private readonly ICategoryApplication _categoryApplication;

        public CreateModel(ICategoryApplication categoryApplication)
        {
            _categoryApplication = categoryApplication;
        }

        public RedirectToPageResult OnPost(CreateCategory command, string name)
        {
            _categoryApplication.Create(command, name);
            return RedirectToPage("/category/index");
        }

    }
}
