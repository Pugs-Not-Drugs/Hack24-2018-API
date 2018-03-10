using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hack24_2018_API.Models
{
	public class Reports
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }

		public string EstablishmentId { get; set; }
		public Establishment Establishment { get; set; }

		public int UsesStraws { get; set; }
	}
}
