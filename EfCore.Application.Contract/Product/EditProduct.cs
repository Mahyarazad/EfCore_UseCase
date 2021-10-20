namespace EfCore.Application.Contract.Product
{
    public class EditProduct : CreateProduct
    {
        public int ProductId { get; set; }
        public string categoryName { get; set; }
    }
}