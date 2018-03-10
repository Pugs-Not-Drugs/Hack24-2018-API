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
    [Produces("application/json")]
    [Route("api/Establishment")]
    public class EstablishmentController : Controller
    {
		private IEstablishmentService _establishmentService;

		public EstablishmentController(IEstablishmentService establishmentService)
		{
			_establishmentService = establishmentService;
		}

		[HttpPost(Name ="Add")]
		public async Task<IActionResult> Add(EstablishmentReportViewModel model)
		{
			await _establishmentService.AddNewEstablishment(model.Id, model.Name, model.Latitude, model.Longitude);
			await _establishmentService.AddReport(model.Id, model.Straws);

			return Ok();
		}
    }
}