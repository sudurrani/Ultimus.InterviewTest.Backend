using System.ComponentModel.DataAnnotations;

namespace Ultimus.Domain.Entities
{
    public class CustomerAddress
    {
        [Key]
        public Guid rowguid { get; set; }  // Primary key is of type Guid
        public int CustomerId { get; set; }

        public int AddressId { get; set; }

        public string AddressType { get; set; } = null!;        
        
        public DateTime ModifiedDate { get; set; }

        public virtual Address Address { get; set; } = null!;

        public virtual Customer Customer { get; set; } = null!;
    }
}
