using Ticketing.BLL.Contract.Results;
using Ticketing.DTOModels.Models;

namespace Ticketing.BLL.Contract.Contract;

public interface IAirplaneBLL
{
    Task<Result> SetAirPlaneModel(AirplaneDTO airPlaneDTO);
}
