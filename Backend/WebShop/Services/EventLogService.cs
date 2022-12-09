using WebShop.Repositories;

namespace WebShop.Services
{
	public class EventLogService
	{
		private readonly EventLogRepository _eventLogRepository;

		public EventLogService()
		{
			_eventLogRepository = new EventLogRepository();
		}

		public void LogMessage(string message)
		{
			_eventLogRepository.LogMessage(message);
		}

	}
}
