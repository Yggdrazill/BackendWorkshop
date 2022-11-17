using WebShop.DataTransferObjects;
using WebShop.Repositories;
using static WebShop.Controllers.OrderController;

namespace WebShop.Services
{
	public class OrderService
	{
		private readonly OrderRepository _orderRepository;

		public OrderService()
		{
			_orderRepository = new OrderRepository();
		}

		public List<OrderItemDTO> GetOrders()
		{
			return _orderRepository.GetOrders();
		}

		public double GetTotalPrice()
		{
			return _orderRepository.GetTotalPrice();
		}

		public int AddOrder(ItemData order)
		{
			return _orderRepository.AddOrder(order);
		}


		public void UpdateOrder(int id, ItemData order)
		{
			_orderRepository.UpdateOrder(id, order);
		}

		public void DeleteOrder(int id)
		{
			_orderRepository.DeleteOrder(id);
		}

		public void ClearShoppingCart()
		{
			_orderRepository.ClearShoppingCart();
		}

	}
}
