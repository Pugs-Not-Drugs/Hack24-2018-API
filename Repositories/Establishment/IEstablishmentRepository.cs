﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hack24_2018_API.Repositories.Establishment
{
	public interface IEstablishmentRepository
	{
		Task<IEnumerable<Models.Establishment>> All();
		Task<Models.Establishment> Get(string id);
		Task AddEstablishment(Models.Establishment model);
		Task Update(string bingId, Models.Establishment model);
		void Delete(Models.Establishment model);
	}
}
