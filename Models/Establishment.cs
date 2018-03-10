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
		public int Id { get; set; }

		public string BusinessName { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }

		public List<Reports> Reports { get; set; } 
	}
}
