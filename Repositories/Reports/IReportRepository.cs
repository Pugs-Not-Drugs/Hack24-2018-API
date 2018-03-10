using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hack24_2018_API.Repositories.Reports
{
	public interface IReportRepository
	{
		Task<IEnumerable<Models.Reports>> All();
		Task<Models.Reports> Get(int bingId);
		Task AddEstablishment(Models.Reports model);
		void Delete(Models.Reports model);
	}
}
