using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hack24_2018_API.Services.Report
{
	public interface IReportService
	{
		Task<float> TotalOfNoStraw();
		Task<float> Count();
	}
}
