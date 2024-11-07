using System.Text.Json.Serialization;
using Ultimus.Domain.Entities;

namespace Ultimus.Application.Features.Customer.Queries.GetCustomersList
{
    public  class CustomerAddressVM
    {        
        public int CustomerId { get; set; }

        public int AddressId { get; set; }

        public string AddressType { get; set; } = null!;

        [JsonIgnore]
        public Guid Rowguid { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual Ultimus.Domain.Entities.Address Address { get; set; } = null!;

        
    }
}
