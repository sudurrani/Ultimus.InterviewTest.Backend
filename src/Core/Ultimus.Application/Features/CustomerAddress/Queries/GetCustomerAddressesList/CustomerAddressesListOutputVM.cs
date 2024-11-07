using System.Text.Json.Serialization;

namespace Ultimus.Application.Features.CustomerAddress.Queries.GetCustomerAddressesList
{
    public class CustomerAddressesListOutputVM
    {
        public int CustomerId { get; set; }

        public int AddressId { get; set; }

        public string AddressType { get; set; } = null!;

        [JsonIgnore]
        public Guid Rowguid { get; set; }

        public DateTime ModifiedDate { get; set; }

        //public Ultimus.Domain.Entities.Address Address { get; set; } = null!;
    }
}
