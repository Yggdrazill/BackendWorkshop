using WebShop.DataTransferObjects;
using WebShop.Repositories;

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

		public int AddOrder(OrderItemDTO order)
		{
			return _orderRepository.AddOrder(order);
		}


		public void UpdateOrder(int id, OrderItemDTO order)
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
