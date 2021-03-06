﻿using System;
using Hack24_2018_API.Extensions;
using Hack24_2018_API.Helpers;
using Hack24_2018_API.Models;
using Hack24_2018_API.Repositories.Establishment;
using Hack24_2018_API.Repositories.Reports;
using Hack24_2018_API.Services.Establishment;
using Hack24_2018_API.Services.Report;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Hack24_2018_API
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<EcoNottsDbContext>(options =>
			{
				options.UseSqlServer($@"Server = tcp:econotts.database.windows.net, 1433; 
					Initial Catalog = EcoNotts;
					Persist Security Info = False; 
					User ID = { Configuration["DBUsername"] };
					Password ={ Configuration["DBPassword"] }; 
					MultipleActiveResultSets = False; 
					Encrypt = True; 
					TrustServerCertificate = False; 
					Connection Timeout = 30;");
			});

			services.AddTransient<IEstablishmentRepository, EstablishmentRepository>();
			services.AddTransient<IReportRepository, ReportRepository>();
			services.AddTransient<IEstablishmentService, EstablishmentService>();
			services.AddTransient<IReportService, ReportService>();
			services.AddMvc();
			services.AddSwagger(CommonHelpers.GetVersionNumber());
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			app.UseDeveloperExceptionPage();
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseSwagger($"/swagger/v{CommonHelpers.GetVersionNumber()}/swagger.json",
$"dwCheckApi {CommonHelpers.GetVersionNumber()}");

			app.UseMvc();

		}
	}
}
