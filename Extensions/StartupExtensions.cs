using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Hack24_2018_API.Extensions
{
	public static class StartupExtensions
	{
		public static void AddSwagger(this IServiceCollection serviceCollection, string versionNumberString,
		bool includeXmlDocumentation = true)
		{
			// Register the Swagger generator, defining one or more Swagger documents
			serviceCollection.AddSwaggerGen(c =>
			{
				c.SwaggerDoc($"v{versionNumberString}",
				  new Info
				  {
					  Title = "dwCheckApi",
					  Version = $"v{versionNumberString}",
					  Description = "A simple APi to get the details on Books, Characters and Series within a canon of novels",
					  Contact = new Contact
					  {
						  Name = "Jamie Taylor",
						  Email = "",
						  Url = "https://dotnetcore.gaprogman.com"
					  }
				  }
				);

				if (!includeXmlDocumentation) return;
				// Set the comments path for the Swagger JSON and UI.
				var basePath = PlatformServices.Default.Application.ApplicationBasePath;
				var xmlPath = Path.Combine(basePath, "dwCheckApi.xml");
				if (File.Exists(xmlPath))
				{
					c.IncludeXmlComments(xmlPath);
				}
			});
		}

		public static void UseSwagger(this IApplicationBuilder applicationBuilder,
	string swaggerUrl, string swaggerDescription)
		{
			// Enable middleware to serve generated Swagger as a JSON endpoint.
			applicationBuilder.UseSwagger();

			// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying
			// the Swagger JSON endpoint.
			applicationBuilder.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint(swaggerUrl, swaggerDescription);
			});
		}
	}
}
