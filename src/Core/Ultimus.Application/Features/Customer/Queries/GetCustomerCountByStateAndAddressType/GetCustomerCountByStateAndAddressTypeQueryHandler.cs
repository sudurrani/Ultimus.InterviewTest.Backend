using AutoMapper;
using MediatR;
using Ultimus.Application.Contracts.Persistence;
using Ultimus.Application.Features.Address.Queries.GetAddressesList;
using Ultimus.Domain.Entities;

namespace Ultimus.Application.Features.Customer.Queries.GetCustomerCountByStateAndAddressType
{
    public class GetCustomerCountByStateAndAddressTypeQueryHandler : IRequestHandler<GetCustomerCountByStateAndAddressTypeQuery, GetCustomerCountByStateAndAddressTypeQueryResponse>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerAddressRepository _customerAddressRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;
        public GetCustomerCountByStateAndAddressTypeQueryHandler(IMapper mapper, ICustomerRepository customerRepository, ICustomerAddressRepository customerAddressRepository
            , IAddressRepository addressRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _customerAddressRepository = customerAddressRepository;
            _addressRepository = addressRepository;
        }
        public async Task<GetCustomerCountByStateAndAddressTypeQueryResponse> Handle(GetCustomerCountByStateAndAddressTypeQuery request,
            CancellationToken cancellationToken)
        {
            var getCustomersListQueryResponse = new GetCustomerCountByStateAndAddressTypeQueryResponse();


            var customers = await _customerRepository.GetAllAsync();
            var customerAddresses = await _customerAddressRepository.GetAllAsync();
            var addresses = await _addressRepository.GetAllAsync();

            var customerCountByStateAndAddressType = customers
                                                             .Join(customerAddresses, c => c.CustomerID, ca => ca.CustomerId, (c, ca) => new { c, ca })
                                                             .Join(addresses, ca => ca.ca.AddressId, a => a.AddressId, (ca, a) => new { ca, a })
                                                             .GroupBy(x => new { x.ca.ca.AddressType, x.a.StateProvince })
                                                             .Select(g => new CustomerCountByStateAndAddressTypeOutputVM
                                                             {
                                                                 AddressType = g.Key.AddressType,
                                                                 State = g.Key.StateProvince,
                                                                 TotalCount = g.Count()
                                                             })
                                                             .ToList();


            if (customerCountByStateAndAddressType.Count() <= 0)
                getCustomersListQueryResponse.Message = $"No, {nameof(Customer)} found";
            else
                getCustomersListQueryResponse.Message = $"{customerCountByStateAndAddressType.Count()} {nameof(Customer)} found";

            getCustomersListQueryResponse.data = customerCountByStateAndAddressType;
                //_mapper.Map<List<CustomerCountByStateAndAddressTypeOutputVM>>(customerCountByStateAndAddressType);
            return getCustomersListQueryResponse;
        }
    }
}
