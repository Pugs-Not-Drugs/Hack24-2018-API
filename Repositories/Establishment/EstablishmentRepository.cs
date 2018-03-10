using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hack24_2018_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Hack24_2018_API.Repositories.Establishment
{
	public class EstablishmentRepository : IEstablishmentRepository
	{
		private readonly EcoNottsDbContext _dbContext;

		public EstablishmentRepository(EcoNottsDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task AddEstablishment(Models.Establishment model)
		{
			_dbContext.Establishments.Add(model);
			await _dbContext.SaveChangesAsync().ConfigureAwait(false);
		}

		public async Task<IEnumerable<Models.Establishment>> All()
		{
			return await _dbContext.Establishments.ToListAsync().ConfigureAwait(false);
		}

		public void Delete(Models.Establishment model)
		{
			_dbContext.Establishments.Remove(model);
		}

		public async Task<Models.Establishment> Get(int bingId)
		{
			return await _dbContext.Establishments.FindAsync(bingId);
		}

		public async Task Update(int bingId, Models.Establishment model)
		{
			var existingModel = await Get(bingId);

			existingModel.BusinessName = model.BusinessName;
			existingModel.Latitude = model.Latitude;
			existingModel.Longitude = model.Longitude;
			existingModel.Reports = model.Reports;

			await _dbContext.SaveChangesAsync();
		}
	}
}
