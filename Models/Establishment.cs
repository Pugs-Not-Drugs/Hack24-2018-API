using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hack24_2018_API.Models
{
	public class Establishment
	{
		public Establishment()
		{
			this.Reports = new List<Reports>();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public string Id { get; set; }

		public string BusinessName { get; set; }
		public string Latitude { get; set; }
		public string Longitude { get; set; }

		public List<Reports> Reports { get; set; } 
	}
}
