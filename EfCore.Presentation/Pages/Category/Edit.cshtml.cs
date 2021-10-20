using EfCore.Application.Contract.Category;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CategoryViewModel = EfCore.Domain.CategoryAgg.CategoryViewModel;

namespace EfCore.Presentation.Pages.Category
{
    public class EditModel : PageModel
    {
        public CategoryViewModel CurrentCategory;
        private readonly ICategoryApplication _categoryApplication;

        public EditModel(ICategoryApplication categoryApplication)
        {
            _categoryApplication = categoryApplication;
        }
        public void OnGet(int id)
        {
            CurrentCategory = _categoryApplication.GetDetail(id);
        }

        public RedirectToPageResult OnPost(EditCategory command, string name, int id)
        {
            _categoryApplication.Edit(command, name, id);
            return RedirectToPage("/category/index");
        }
    }
}
