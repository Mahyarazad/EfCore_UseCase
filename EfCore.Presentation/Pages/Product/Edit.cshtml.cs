using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using EfCore.Application.Contract.Category;
using EfCore.Application.Contract.Product;
using EfCore.Domain.CategoryAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductViewModel = EfCore.Domain.ProductAgg.ProductViewModel;

namespace EfCore.Presentation.Pages.Product
{
    public class EditModel : PageModel
    {

        public SelectList CategoryList;
        public ProductViewModel CurrentProduct;
        public string SelectedCategory;
        public string SelectedCategoryName;
        private readonly IProductApplication _productApplication;
        private readonly ICategoryApplication _categoryApplication;
        public EditModel(IProductApplication productApplication, ICategoryApplication categoryApplication)
        {
            _productApplication = productApplication;
            _categoryApplication = categoryApplication;
        }
        public void OnGet(int id)
        {
            CategoryList = new SelectList(_categoryApplication.GetAll(), "CategoryId", "CategoryName");
            CurrentProduct = _productApplication.GetDetail(id);
            SelectedCategory =
                CategoryList.First(item => item.Text == CurrentProduct.CategoryName).Value;
            SelectedCategoryName =
                CategoryList.First(item => item.Text == CurrentProduct.CategoryName).Text;

        }
        public RedirectToPageResult OnPost(EditProduct command, string name, int id, string description, double price, int category)
        {
            _productApplication.Edit(command, name, description, id, price, category);
            return RedirectToPage("/product/index");
        }
    }
}
