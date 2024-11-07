namespace Ultimus.Application.Features.Product.Queries.GetProductsList
{
    public class ProductCategoryVM
    {
        public int ProductCategoryId { get; set; }

        public int? ParentProductCategoryId { get; set; }

        public string Name { get; set; } = null!;

        public Guid Rowguid { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
