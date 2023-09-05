using Ticketing.BLL.Contract.Contract;
using Ticketing.BLL.Contract.Results;
using Ticketing.BLL.Resouces;
using Ticketing.DAL.Contract.Contract;
using Ticketing.DAL.Contract.Models;
using Ticketing.DTOModels.Models;

namespace Ticketing.BLL.Services;

public class AirplaneBLL : IAirplaneBLL
{
    private readonly IAirplaneDAL _airplaneDAL;

    private readonly ICompanyDAL _companyDAL;

    public AirplaneBLL(IAirplaneDAL airplaneDAL, ICompanyDAL countryDAL)
    {
        _airplaneDAL = airplaneDAL;

        _companyDAL = countryDAL;
    }

    public async Task<Result> SetAirPlaneModel(AirplaneDTO airPlaneDTO)
    {
        var company = await _companyDAL.Get(airPlaneDTO.CompanyId);

        if (company == null)
        {
            return new Result(BusinessRulesMessages.CompanyDoesNotExist);
        }

        var airplane = new Airplane() { Company = company, Id = airPlaneDTO.Id, Model = airPlaneDTO.Model };

        await _airplaneDAL.Insert(airplane);

        return new Result();
    }
}
