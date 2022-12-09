namespace WebShop.Controllers
{
	using global::WebShop.DataTransferObjects;
	using global::WebShop.Services;
	using Microsoft.AspNetCore.Mvc;

	namespace WebShop.Controllers
	{
		[ApiController]
		[Route("[controller]")]
		public class ItemController : ControllerBase
		{

			private ItemService _itemService;

			public ItemController()
			{
				_itemService = new ItemService();
			}

			[HttpGet]
			[Route("")]
			public IList<ItemDTO> GetAll()
			{
				return _itemService.GetItems();
			}

			[HttpPost]
			[Route("")]
			public void CreateItem(ItemDTO Item) // Extra endpoint för att lägg till items
			{
				_itemService.CreateItem(Item);
			}

			[HttpPut]
			[Route("{id}")]
			public void UpdateItem(int id, [FromBody] ItemDTO item) // Extra endpoint för att uppdatera items
			{
				_itemService.UpdateItem(id, item);
			}

			[HttpDelete]
			[Route("{id}")]
			public void DeleteItem(int id) // Extra endpoint för att lägga till items
			{
				_itemService.DeleteItem(id);
			}

		}

	}


}
