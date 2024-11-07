﻿namespace Ultimus.Domain.Entities
{
    public class ProductCategory
    {
        public int ProductCategoryId { get; set; }

        public int? ParentProductCategoryId { get; set; }

        public string Name { get; set; } = null!;

        public Guid Rowguid { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
