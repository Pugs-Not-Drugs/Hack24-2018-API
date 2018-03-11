using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hack24_2018_API.Repositories.Reports;
using Hack24_2018_API.Services.Report;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hack24_2018_API.Controllers
{
	[Route("api/Percentage")]
	public class PercentageController : Controller
	{
		private readonly IReportService _reportService;

		public PercentageController(IReportService reposrtService)
		{
			_reportService = reposrtService;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var current = await _reportService.TotalOfNoStraw();
			var maximum = await _reportService.Count();

			return Ok(new { Percentage = (current / maximum) * 100 });
		}
	}
}