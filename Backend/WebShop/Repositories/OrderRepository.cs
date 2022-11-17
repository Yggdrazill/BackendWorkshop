using Database;
using Database.Entities;
using WebShop.DataTransferObjects;
using static WebShop.Controllers.OrderController;

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
						Name = x.Item.Name,
						Cost = x.Item.Cost,
						ImageId = x.Item.ImageId
					}
				}).ToList();

			return orders;
		}

		public double GetTotalPrice()
		{
			var orders = _dbContext.OrderItems.ToList();

			var list = orders.Select(x => new
			{
				Quantity = x.Quantity,
				Cost = _dbContext.Items.First(i => i.Id == x.ItemId).Cost
			});

			var totalPrice = list.Sum(x => x.Quantity * x.Cost);

			return totalPrice;
		}

		public int AddOrder(ItemData order)
		{
			var entity = new OrderItem
			{
				ItemId = order.ItemId,
				Quantity = order.Quantity
			};

			_dbContext.OrderItems.Add(entity);
			_dbContext.SaveChanges();

			return entity.Id;
		}


		public void UpdateOrder(int id, ItemData order)
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
