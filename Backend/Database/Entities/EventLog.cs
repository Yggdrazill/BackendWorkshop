using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Entities
{
	[Table("EventLog")]
	public class EventLog
	{
		public int Id { get; set; }
		public string Body { get; set; }

	}
}
