﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hack24_2018_API.Services.Establishment;
using Hack24_2018_API.ViewModel;
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

		[HttpGet("api/establishment/all")]
		public async Task<IActionResult> All()
		{
			var result = new List<AllEstablishmentsViewModel>();
			var establishmnets = await _establishmentService.All();

			foreach (var establishment in establishmnets)
			{
				result.Add(new AllEstablishmentsViewModel
				{
					Id = establishment.Id,
					Name = establishment.BusinessName,
					Longitude = establishment.Longitude,
					Latitude = establishment.Latitude,
					HappyStraws = establishment.Reports.Count(r => r.UsesStraws == 0),
					SadStraws = establishment.Reports.Count(r => r.UsesStraws == 1)
				});
			}

			return Ok(result);
		}

		[HttpGet("api/establishment/top")]
		public async Task<IActionResult> Top()
		{
			var result = new List<AllEstablishmentsViewModel>();
			var establishmnets = await _establishmentService.All();

			var top = establishmnets.OrderBy(e => ((float)e.Reports.Count(r => r.UsesStraws == 0) / (float)e.Reports.Count()) * 100).Take(5).ToList();

			top.ForEach(x => result.Add(new AllEstablishmentsViewModel
			{
				Id = x.Id,
				Name = x.BusinessName,
				Latitude = x.Latitude,
				Longitude = x.Longitude,
				Percentage = ((float)x.Reports.Count(r => r.UsesStraws == 0) / (float) x.Reports.Count()) * 100
			}));

			return Ok(result);
		}

		[HttpPost("api/establishment/add")]
		public async Task<IActionResult> AddEstablishment(EstablishmentReportViewModel model)
		{
			if (string.IsNullOrEmpty(model.Id))
				return BadRequest();

			await _establishmentService.AddNewEstablishment(model.Id, model.Name, model.Latitude, model.Longitude);
			await _establishmentService.AddReport(model.Id, model.Straws);

			return Ok(model);
		}
	}
}