using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hack24_2018_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Hack24_2018_API.Repositories.Reports
{
	public class ReportRepository : IReportRepository
	{
		private readonly EcoNottsDbContext _dbContext;

		public ReportRepository(EcoNottsDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task AddEstablishment(Models.Reports model)
		{
			_dbContext.Reports.Add(model);
			await _dbContext.SaveChangesAsync().ConfigureAwait(false);
		}

		public async Task<IEnumerable<Models.Reports>> All()
		{
			return await _dbContext.Reports.ToListAsync().ConfigureAwait(false);
		}

		public void Delete(Models.Reports model)
		{
			_dbContext.Reports.Remove(model);
		}

		public async Task<Models.Reports> Get(int bingId)
		{
			return await _dbContext.Reports.FindAsync(bingId);
		}
	}
}
