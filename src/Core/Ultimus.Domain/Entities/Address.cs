namespace Ultimus.Domain.Entities
{
    public class Address
    {
        public int AddressId { get; set; }
        public string AddressLine1 { get; set; } = null!;
        public string? AddressLine2 { get; set; }
        public string City { get; set; } = null!;
        public string StateProvince { get; set; } = null!;
        public string CountryRegion { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; } = new List<CustomerAddress>();

    }
}
