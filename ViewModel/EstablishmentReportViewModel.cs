using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hack24_2018_API.ViewModel
{
	public class EstablishmentReportViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public bool Straws { get; set; }
	}
}
