using System.Reflection;

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
