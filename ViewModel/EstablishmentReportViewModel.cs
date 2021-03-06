﻿using Newtonsoft.Json;

namespace Hack24_2018_API.ViewModel
{
	public class EstablishmentReportViewModel
	{
		[JsonProperty]
		public string Id { get; set; }
		[JsonProperty]
		public string Name { get; set; }
		[JsonProperty]
		public string Latitude { get; set; }
		[JsonProperty]
		public string Longitude { get; set; }
		[JsonProperty]
		public int Straws { get; set; }
	}
}
