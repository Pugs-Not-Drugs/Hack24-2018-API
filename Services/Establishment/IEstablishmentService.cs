using System.Threading.Tasks;

namespace Hack24_2018_API.Services.Establishment
{
	public interface IEstablishmentService
	{
		Task AddNewEstablishment(string id, string businessName, string latitude, string longitude);
		Task AddReport(string id, int usesStraw);
	}
}
