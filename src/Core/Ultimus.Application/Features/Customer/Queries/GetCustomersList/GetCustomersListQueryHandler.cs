using AutoMapper;
using MediatR;
using System.Linq;
using System.Net.Http.Json;
using System.Text.Json;
using Ultimus.Application.Contracts.Infrastructure.Encryption;
using Ultimus.Application.Contracts.Persistence;

namespace Ultimus.Application.Features.Customer.Queries.GetCustomersList
{
    public class GetCustomersListQueryHandler : IRequestHandler<GetCustomersListQuery, GetCustomersListQueryResponse>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IEncryptionService _encryptionService;
        private readonly IMapper _mapper;
        public GetCustomersListQueryHandler(IMapper mapper, ICustomerRepository customerRepository, IEncryptionService encryptionService)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _encryptionService = encryptionService;
        }
        public async Task<GetCustomersListQueryResponse> Handle(GetCustomersListQuery request,
            CancellationToken cancellationToken)
        {
            var getCustomersListQueryResponse = new GetCustomersListQueryResponse();
            
            var allCustomers = await _customerRepository.GetAllAsync(row => row.CustomerAddresses);
            
            if (allCustomers.Count() <= 0)
                getCustomersListQueryResponse.Message = $"No, {nameof(Customer)} found";
            else
                getCustomersListQueryResponse.Message = $"{allCustomers.Count()} {nameof(Customer)} found";

            getCustomersListQueryResponse.data = allCustomers.Select(item => new CustomersListOutputVM
            {
                FirstName = item.FirstName,
                LastName = item.LastName,
                CompanyName = item.CompanyName,
                EmailAddress = item.EmailAddress,
                Phone = item.Phone,
                AddressType = string.Join(", ", item!.CustomerAddresses.Select(a => a.AddressType))
            }).ToList();
            
            return getCustomersListQueryResponse;
        }
    }
}
