using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hack24_2018_API.ViewModel
{
	public class AllEstablishmentsViewModel
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Longitude { get; set; }
		public string Latitude { get; set; }
		public int HappyStraws { get; set; }
		public int SadStraws { get; set; }
		public float Percentage { get; set; }
	}
}
