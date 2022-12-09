using System.Collections.Generic;
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
			// Ger 2 förslag nu men finns många sätt att göra detta på.
			// Metod 1 - 
			var orders = _orderRepository.GetOrders();
			var totalPrice = orders.Sum(x => x.Quantity * x.Item.Cost); // Viktigt att inte glömma Quantity här

			// Metod 2
			double totalPrice2 = 0;
			var costs = orders.Select(x => x.Quantity * x.Item.Cost);
			foreach (var cost in costs)
			{
				totalPrice2 += cost;
			}
			return totalPrice;
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
