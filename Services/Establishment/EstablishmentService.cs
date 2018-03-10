using Hack24_2018_API.Repositories.Establishment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hack24_2018_API.Services.Establishment
{
	public class EstablishmentService : IEstablishmentService
	{
		private readonly IEstablishmentRepository _establishmentRepository;

		public EstablishmentService(IEstablishmentRepository establishmentRepository)
		{
			_establishmentRepository = establishmentRepository;
		}
		public async Task AddNewEstablishment(int id, string businessName, double latitude, double longitude)
		{
			var result = await _establishmentRepository.Get(id);
			if(result == null)
			{
				result = new Models.Establishment
				{
					Id = id,
					BusinessName = businessName,
					Latitude = latitude,
					Longitude = longitude
				};

				await _establishmentRepository.AddEstablishment(result);
			}
		}

		public async Task AddReport(int bingId, bool usesStraw)
		{
			var result = await _establishmentRepository.Get(bingId);

			if(result != null)
			{
				result.Reports.Add(new Models.Reports
				{
					EstablishmentId = result.Id,
					UsesStraws = usesStraw
				});
			}

			await _establishmentRepository.Update(bingId, result);
		}
	}
}
