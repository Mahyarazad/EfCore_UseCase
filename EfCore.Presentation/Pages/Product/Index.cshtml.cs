using System.Collections.Generic;
using System.Threading.Tasks;
using EfCore.Application.Contract.Category;
using EfCore.Application.Contract.Product;
using EfCore.Domain.ProductAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductViewModel = EfCore.Domain.ProductAgg.ProductViewModel;

namespace EfCore.Presentation.Pages.Product
{
    public class ProductIndex : PageModel
    {
        public SelectList CategoryList;
        public List<Domain.ProductAgg.ProductViewModel> Products;
        private readonly IProductApplication _productApplication;
        private readonly ICategoryApplication _categoryApplication;

        public ProductIndex(IProductApplication productApplication, ICategoryApplication categoryApplication)
        {
            _categoryApplication = categoryApplication;
            _productApplication = productApplication;
        }
        public void OnGet(ProductSearchModel name)
        {
            CategoryList = new SelectList(_categoryApplication.GetAll(), "CategoryId", "CategoryName");
            Products = _productApplication.Search(name);
        }

        public RedirectToPageResult OnPostDelete(DeleteProduct command, int id)
        {
            _productApplication.Delete(command, id);
            return RedirectToPage("/product/index");
        }
        public RedirectToPageResult OnPostRestore(RestoreProduct command, int id)
        {
            _productApplication.Restore(command, id);
            return RedirectToPage("/product/index");
        }
    }
}
