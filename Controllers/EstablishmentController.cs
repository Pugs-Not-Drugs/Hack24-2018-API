using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hack24_2018_API.Services.Establishment;
using Hack24_2018_API.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hack24_2018_API.Controllers
{
    public class EstablishmentController : Controller
    {
		private IEstablishmentService _establishmentService;

		public EstablishmentController(IEstablishmentService establishmentService)
		{
			_establishmentService = establishmentService;
		}

		[HttpPost("api/establishment/add")]
		public async Task<IActionResult> AddEstablishment(EstablishmentReportViewModel model)
		{
			if (!string.IsNullOrEmpty(model.Id))
				return BadRequest();

			await _establishmentService.AddNewEstablishment(model.Id, model.Name, model.Latitude, model.Longitude);
			await _establishmentService.AddReport(model.Id, model.Straws);

			return Ok(model);
		}
    }
}