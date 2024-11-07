using Ultimus.Domain.Entities;

namespace Ultimus.Application.Features.Customer.Queries.GetCustomersList
{
    public class CustomersListOutputVM
    {        

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? CompanyName { get; set; }

     

        public string? EmailAddress { get; set; }

        public string? Phone { get; set; }

        public string AddressType { get; set; }
//        public virtual ICollection<CustomerAddressVM> CustomerAddresses { get; set; } = new List<CustomerAddressVM>();
    }
}
