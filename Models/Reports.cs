﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hack24_2018_API.Models
{
	public class Reports
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string EstablishmentId { get; set; }

		public int UsesStraws { get; set; }
	}
}
