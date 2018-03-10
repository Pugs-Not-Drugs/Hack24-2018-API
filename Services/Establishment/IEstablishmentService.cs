using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hack24_2018_API.Services.Establishment
{
	public interface IEstablishmentService
	{
		Task AddNewEstablishment(int id, string businessName, double latitude, double longitude);
		Task AddReport(int bingId, bool usesStraw);
	}
}
