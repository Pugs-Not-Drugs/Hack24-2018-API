﻿using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hack24_2018_API.Services.Establishment
{
	public interface IEstablishmentService
	{
		Task AddNewEstablishment(string id, string businessName, string latitude, string longitude);
		Task AddReport(string id, int usesStraw);
		Task<IEnumerable<Models.Establishment>> All();
		Task<Models.Establishment> Get(string id);
	}
}
