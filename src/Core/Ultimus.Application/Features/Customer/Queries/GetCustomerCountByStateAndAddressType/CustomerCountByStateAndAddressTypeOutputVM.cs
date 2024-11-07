namespace Ultimus.Application.Features.Customer.Queries.GetCustomerCountByStateAndAddressType
{
    public class CustomerCountByStateAndAddressTypeOutputVM
    {
        public string? AddressType { get; set; }
        public string? State { get; set; }
        public int? TotalCount { get; set; }
    }
}
