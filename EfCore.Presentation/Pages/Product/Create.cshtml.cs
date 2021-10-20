using System.Collections.Generic;
using EfCore.Application.Contract.Category;
using EfCore.Application.Contract.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EfCore.Presentation.Pages.Product
{
    public class CreateModel : PageModel
    {
        public string SelectedCategory;
        public SelectList CategoryList;
        private readonly IProductApplication _productApplication;
        private readonly ICategoryApplication _categoryApplication;

        public CreateModel(IProductApplication productApplication, ICategoryApplication categoryApplication)
        {
            _productApplication = productApplication;
            _categoryApplication = categoryApplication;
        }

        public void OnGet(CreateProduct command)
        {
            CategoryList = new SelectList(_categoryApplication.GetAll(), "CategoryId", "CategoryName");
        }
        public RedirectToPageResult OnPost(CreateProduct command, string name)
        {
            _productApplication.Create(command, command.ProductName);
            return RedirectToPage("/product/index");
        }

    }
}
