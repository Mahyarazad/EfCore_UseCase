namespace EfCore.Application.Contract.Product
{
    public class CreateProduct
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double UnitPrice { get; set; }
        public int CategoryId { get; set; }
    }
}