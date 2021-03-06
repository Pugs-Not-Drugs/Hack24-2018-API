﻿using System.Collections.Generic;
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
			return await _dbContext.Establishments.Include(establishment => establishment.Reports).ToListAsync().ConfigureAwait(false);
		}

		public void Delete(Models.Establishment model)
		{
			_dbContext.Establishments.Remove(model);
		}

		public async Task<Models.Establishment> Get(string id)
		{
			return await _dbContext.Establishments.Include(establishment => establishment.Reports)
				.FirstOrDefaultAsync(e => e.Id == id);
		}

		public async Task Update(string id, Models.Establishment model)
		{
			var existingModel = await Get(id);

			existingModel.BusinessName = model.BusinessName;
			existingModel.Latitude = model.Latitude;
			existingModel.Longitude = model.Longitude;
			existingModel.Reports = model.Reports;

			await _dbContext.SaveChangesAsync();
		}
	}
}
