using Database;
using Database.Entities;

namespace WebShop.Repositories
{
	public class EventLogRepository
	{
		private Context _dbContext;

		public EventLogRepository()
		{
			_dbContext = new Context();
		}


		public void LogMessage(string message)
		{
			var eventLogMessage = new EventLog
			{
				Body = message
			};

			_dbContext.EventLogs.Add(eventLogMessage);
			_dbContext.SaveChanges();
		}
	}
}
