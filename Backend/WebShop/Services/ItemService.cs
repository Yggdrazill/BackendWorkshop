using Database.Entities;
using WebShop.DataTransferObjects;
using WebShop.Repositories;

namespace WebShop.Services
{
	public class ItemService
	{
		private readonly ItemRepository _itemRepository;
		private readonly EventLogService _eventLogService;

		public ItemService()
		{
			_itemRepository = new ItemRepository();
			_eventLogService = new EventLogService();
		}


		public List<ItemDTO> GetItems()
		{
			return _itemRepository.GetItems();
		}

		public ItemDTO GetItem(int id)
		{
			return _itemRepository.GetItem(id);
		}

		public void CreateItem(ItemDTO item)
		{

			_eventLogService.LogMessage($"Creating new item {item.Name}");
			_itemRepository.CreateItem(item);
		}

		public void UpdateItem(int id, ItemDTO item)
		{
			_itemRepository.UpdateItem(id, item);
		}


		public void DeleteItem(int id)
		{
			_eventLogService.LogMessage($"Deleting item with id {id}");
			_itemRepository.DeleteItem(id);
		}

	}
}
