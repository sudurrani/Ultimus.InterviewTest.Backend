using AutoMapper;
using MediatR;
using System.Collections.Generic;
using Ultimus.Application.Contracts.Persistence;


namespace Ultimus.Application.Features.CustomerAddress.Queries.GetCustomerAddressesList
{
    public class GetCustomerAddressesListQueryHandler : IRequestHandler<GetCustomerAddressesListQuery, GetCustomerAddressesListQueryResponse>
    {
        private readonly ICustomerAddressRepository _customerAddressRepository;
        private readonly IMapper _mapper;
        public GetCustomerAddressesListQueryHandler(IMapper mapper, ICustomerAddressRepository customerAddressRepository)
        {
            _mapper = mapper;
            _customerAddressRepository = customerAddressRepository;
        }
        public async Task<GetCustomerAddressesListQueryResponse> Handle(GetCustomerAddressesListQuery request,
            CancellationToken cancellationToken)
        {
            var getCustomerAddressesListQueryResponse = new GetCustomerAddressesListQueryResponse();

            var allCustomerAddresses = await _customerAddressRepository.GetAllAsync();

    

            if (allCustomerAddresses.Count() <= 0)
                getCustomerAddressesListQueryResponse.Message = $"No, {nameof(CustomerAddress)} found";
            else
                getCustomerAddressesListQueryResponse.Message = $"{allCustomerAddresses.Count()} {nameof(CustomerAddress)} found";

            var response = _mapper.Map<List<CustomerAddressesListOutputVM>>(allCustomerAddresses);

            var distinctNames = response.Select(x => x.AddressType)
                                        .Distinct()
                                        .ToList();

            getCustomerAddressesListQueryResponse.data = distinctNames;
            return getCustomerAddressesListQueryResponse;
        }
    }
}
