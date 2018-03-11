using Hack24_2018_API.Repositories.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hack24_2018_API.Services.Report
{
	public class ReportService : IReportService
	{
		private readonly IReportRepository _reportRepository;

		public ReportService(IReportRepository reportRepository)
		{
			_reportRepository = reportRepository;
		}

		public async Task<float> Count()
		{
			return (await _reportRepository.All()).Count();
		}

		public async Task<float> TotalOfNoStraw()
		{
			return (await _reportRepository.All()).Count(r => r.UsesStraws == 0);
		}
	}
}
