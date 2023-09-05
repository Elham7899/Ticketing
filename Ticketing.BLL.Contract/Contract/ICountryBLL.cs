using Ticketing.BLL.Contract.Results;

namespace Ticketing.BLL.Contract.Contract;

public interface ICountryBLL
{
    Task<Result> GetCountry();
}
