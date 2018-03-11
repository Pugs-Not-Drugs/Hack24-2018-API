using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using Microsoft.Extensions.Logging;

namespace Hack24_2018_API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			BuildWebHost(args).Run();
		}

		public static IWebHost BuildWebHost(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.ConfigureLogging((hostingContext, logging) =>
					{
						logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
						logging.AddConsole();
						logging.AddDebug();
					})
				.ConfigureAppConfiguration((context, config) =>
					{
						var builtConfig = config.Build();

						config.AddAzureKeyVault(builtConfig["KeyVault:SecretUri"],
							builtConfig["KeyVault:ClientId"],
							builtConfig["KeyVault:ClientSecret"]);
					})
				.UseStartup<Startup>()
				.Build();

		private static string GetKeyVaultEndpoint() => Environment.GetEnvironmentVariable("KEYVAULT_ENDPOINT");
	}
}
