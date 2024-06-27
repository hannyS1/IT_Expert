using AutoMapper;
using TestProject.Api.Contracts.Data;
using TestProject.Api.Contracts.Web;
using TestProject.AppServices.Contracts;
using TestProject.AppServices.Repositories;

namespace TestProject.AppServices;

internal class ItemService : IItemService
{
    private readonly IItemRepository _itemRepository;
    private readonly IMapper _mapper;
    
    public ItemService(IItemRepository itemRepository, IMapper mapper)
    {
        _itemRepository = itemRepository ?? throw new ArgumentNullException(nameof(itemRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<IEnumerable<ItemResponseDto>> GetByFilterAsync(GetItemsQueryFilter filter)
    {
        var itemEntities = await _itemRepository.GetByFilterAsync(filter);
        return _mapper.Map<IEnumerable<ItemResponseDto>>(itemEntities);
    }
}