using Ticketing.BLL.Contract.Contract;
using Ticketing.BLL.Contract.Results;
using Ticketing.DAL.Contract.Contract;

namespace Ticketing.BLL.Services;

public class CountryBLL : ICountryBLL
{
    private readonly ICountryDAL _countryDAL;

    public CountryBLL(ICountryDAL countryDAL)
    {
        _countryDAL = countryDAL;
    }

    public async Task<Result> GetCountry()
    {
        return new Result(await _countryDAL.Select());
    }
}