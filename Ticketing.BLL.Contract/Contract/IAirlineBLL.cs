using Ticketing.BLL.Contract.Results;
using Ticketing.DTOModels.Models;
using Ticketing.Models.Models;

namespace Ticketing.BLL.Contract.Contract;

public interface IAirlineBLL
{
    Task<Result> SetAirLineInfo(AirlineDTO airLineDTO);
    Task<Result> SetAirPlanesOfAirLine(int airlineId, LinePlaneDTO linePlaneDTO);
    Task<Result> SelectAirplaneOfLine(int id);
    Task<Result<LinePlane>> ChangeAirworthiness(int id, Airworthiness airworthiness);
}
