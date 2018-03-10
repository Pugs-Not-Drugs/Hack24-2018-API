using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Hack24_2018_API.Helpers
{
	public static class CommonHelpers
	{
		public static string GetVersionNumber()
		{
			return Assembly.GetEntryAssembly()
			  .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
			  .InformationalVersion;
		}
	}
}
