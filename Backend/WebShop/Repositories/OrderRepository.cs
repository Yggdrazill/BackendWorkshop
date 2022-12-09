using Database;
using Database.Entities;
using WebShop.DataTransferObjects;

namespace WebShop.Repositories
{
	public class OrderRepository
	{
		private Context _dbContext;

		public OrderRepository()
		{
			_dbContext = new Context();
		}

		public List<OrderItemDTO> GetOrders()
		{
			var orders = _dbContext.OrderItems.Select(x =>
				new OrderItemDTO
				{
					Id = x.Id,
					Quantity = x.Quantity,
					Item = new ItemDTO
					{
						Id = x.ItemId,
						Cost = x.Item.Cost,
						Name = x.Item.Name,
						ImageId = x.Item.ImageId
					}
				}).ToList();

			return orders;
		}

		public int AddOrder(OrderItemDTO order)
		{
			var entity = new OrderItem
			{
				ItemId = order.Item.Id,
				Quantity = order.Quantity
			};

			_dbContext.OrderItems.Add(entity);
			_dbContext.SaveChanges();

			return entity.Id;
		}


		public void UpdateOrder(int id, OrderItemDTO order)
		{
			var entity = _dbContext.OrderItems.First(x => x.Id == id);

			entity.Quantity = order.Quantity;
			_dbContext.SaveChanges();
		}


		public void DeleteOrder(int id)
		{
			var entity = _dbContext.OrderItems.First(x => x.Id == id);
			_dbContext.OrderItems.Remove(entity);
			_dbContext.SaveChanges();
		}


		public void ClearShoppingCart()
		{
			_dbContext.OrderItems.RemoveRange(_dbContext.OrderItems.ToList());
			_dbContext.SaveChanges();
		}


	}
}
