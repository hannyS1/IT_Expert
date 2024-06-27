using AutoMapper;
using TestProject.Api.Contracts.Data;
using TestProject.Api.Contracts.Web;
using TestProject.AppServices.Contracts;
using TestProject.AppServices.Repositories;
using TestProject.Entities;

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
        if (filter == null)
            throw new ArgumentNullException(nameof(filter));
        
        var itemEntities = await _itemRepository.GetByFilterAsync(filter);
        return _mapper.Map<IEnumerable<ItemResponseDto>>(itemEntities);
    }

    public async Task FetchData(IEnumerable<Dictionary<int, string>> data)
    {
        if (data == null)
            throw new ArgumentNullException(nameof(data));
        
        var itemEntities = data.Select(dictionaryItem => new Item
        {
            Code = dictionaryItem.First().Key,
            Value = dictionaryItem.First().Value,
        }).ToList();

        await _itemRepository.FetchData(itemEntities);
    }
}