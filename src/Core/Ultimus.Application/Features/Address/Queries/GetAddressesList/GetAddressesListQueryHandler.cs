using AutoMapper;
using MediatR;
using Ultimus.Application.Contracts.Persistence;
using Ultimus.Application.Features.Address.Queries.GetAddressesList;
using Ultimus.Application.Features.CustomerAddress.Queries.GetCustomerAddressesList;


namespace Ultimus.Application.Features.Address.Queries.GetAddressesListList
{
    public class GetAddressesListListQueryHandler : IRequestHandler<GetAddressesListQuery, GetAddressesListQueryResponse>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;        
        public GetAddressesListListQueryHandler(IMapper mapper, IAddressRepository addressRepository)
        {
            _mapper = mapper;
            _addressRepository = addressRepository;
        }
        public async Task<GetAddressesListQueryResponse> Handle(GetAddressesListQuery request, CancellationToken cancellationToken)
        {
            var getAddressesListQueryResponse = new GetAddressesListQueryResponse();

            var addAddresses = await _addressRepository.GetAllAsync();

            if (addAddresses.Count() <= 0)
                getAddressesListQueryResponse.Message = $"No, {nameof(Address)} found";
            else
                getAddressesListQueryResponse.Message = $"{addAddresses.Count()} {nameof(Address)} found";

            getAddressesListQueryResponse.data = _mapper.Map<List<AddressesListOutputVM>>(addAddresses);
            return getAddressesListQueryResponse;
        }
    }
}
