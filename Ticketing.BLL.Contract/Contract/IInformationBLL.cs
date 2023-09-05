using Ticketing.BLL.Contract.Results;
using Ticketing.DTOModels.Models;

namespace Ticketing.BLL.Contract.Contract;

public interface IInformationBLL
{
    Task<Result> Register(int Id, List<InformationDTO> information);
}
