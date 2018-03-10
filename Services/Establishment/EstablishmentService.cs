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
		public async Task AddNewEstablishment(string id, string businessName, string latitude, string longitude)
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

		public async Task AddReport(string id, int usesStraw)
		{
			var result = await _establishmentRepository.Get(id);

			if(result != null)
			{
				result.Reports.Add(new Models.Reports
				{
					EstablishmentId = result.Id,
					UsesStraws = usesStraw
				});
			}

			await _establishmentRepository.Update(id, result);
		}
	}
}
