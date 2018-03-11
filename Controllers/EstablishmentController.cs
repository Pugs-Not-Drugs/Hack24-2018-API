using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hack24_2018_API.Services.Establishment;
using Hack24_2018_API.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Tweetinvi;
using Tweetinvi.Models;

namespace Hack24_2018_API.Controllers
{
	public class EstablishmentController : Controller
	{
		private IEstablishmentService _establishmentService;
		private IConfiguration _configuration;

		public EstablishmentController(IEstablishmentService establishmentService, IConfiguration configuration)
		{
			_establishmentService = establishmentService;
			_configuration = configuration;
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

			var top = establishmnets.Where(e => e.Reports.Count >= 10).OrderBy(e => ((float)e.Reports.Count(r => r.UsesStraws == 0) / (float)e.Reports.Count()) * 100).Take(5).ToList();

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

		[HttpGet("api/establishment/{id}")]
		public async Task<IActionResult> Get(string id)
		{
			var result = await _establishmentService.Get(id);

			if (result == null)
				return NotFound();

			return Ok(new AllEstablishmentsViewModel
			{
				Id = result.Id,
				Name = result.BusinessName,
				Longitude = result.Longitude,
				Latitude = result.Latitude,
				HappyStraws = result.Reports.Count(r => r.UsesStraws == 0),
				SadStraws = result.Reports.Count(r => r.UsesStraws == 1)
			});
		}


		[HttpPost("api/establishment/add")]
		public async Task<IActionResult> AddEstablishment(EstablishmentReportViewModel model)
		{
			var creds = new TwitterCredentials(_configuration["ConsumerKey"], _configuration["ConsumerSecret"], _configuration["AccessToken"], _configuration["AccessTokenSecret"]);

			if (string.IsNullOrEmpty(model.Id))
				return BadRequest();

			await _establishmentService.AddNewEstablishment(model.Id, model.Name, model.Latitude, model.Longitude);
			await _establishmentService.AddReport(model.Id, model.Straws);

			var tweet = Auth.ExecuteOperationWithCredentials(creds, () =>
			{
				if(model.Straws == 1) 
					return Tweet.PublishTweet($"Shame! {model.Name} in Nottingham are still using plastic straws :( #refusethestraw #hack24 #savetheturtles");

				return Tweet.PublishTweet($"Another one bites the dust! {model.Name} in Nottingham are no longer using plastic straws #refusethestraw #hack24 #savetheturtles");
			});

			return Ok(model);
		}
	}
}