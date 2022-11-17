using Microsoft.AspNetCore.Mvc;
using WebShop.DataTransferObjects;
using WebShop.Services;

namespace WebShop.Controllers
{

	[ApiController]
	[Route("[controller]")]
	public class OrderController
	{

		private OrderService _orderService;

		public OrderController()
		{
			_orderService = new OrderService();
		}

		[HttpGet]
		[Route("")]
		public List<OrderItemDTO> GetOrders()
		{
			return _orderService.GetOrders();
		}

		[HttpGet]
		[Route("totalprice")]
		public double GetTotalPrice()
		{
			return _orderService.GetTotalPrice();
		}

		[HttpPost]
		[Route("")]
		public void AddOrder(ItemData order)
		{
			_orderService.AddOrder(order);
		}

		[HttpPut]
		[Route("{id}")]
		public void UpdateOrder(int id, ItemData order)
		{
			_orderService.UpdateOrder(id, order);
		}

		[HttpDelete]
		[Route("{id}")]
		public void DeleteOrder(int id)
		{
			_orderService.DeleteOrder(id);
		}


		public class ItemData
		{
			public int ItemId { get; set; }
			public int Quantity { get; set; }
		}
	}
}
