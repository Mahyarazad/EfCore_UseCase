namespace EfCore.Application.Contract.Product
{
    public class DeleteProduct
    {
        public int ProductId { get; set; }
    }

    public class RestoreProduct : DeleteProduct
    {
    }
}