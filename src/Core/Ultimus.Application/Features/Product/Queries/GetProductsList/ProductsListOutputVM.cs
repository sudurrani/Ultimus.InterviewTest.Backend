namespace Ultimus.Application.Features.Product.Queries.GetProductsList
{
    public class ProductsListOutputVM
    {        
        public string Name { get; set; } = null!;
        public string ProductNumber { get; set; } = null!;
        public int? ProductCategoryId { get; set; }
        public string Category { get; set; } = null!;
     
        public decimal ListPrice { get; set; }        
        public DateTime? SellEndDate { get; set; }
        

    }
}
