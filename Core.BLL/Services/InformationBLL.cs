using Ticketing.BLL.Contract.Contract;
using Ticketing.BLL.Contract.Results;
using Ticketing.BLL.Resouces;
using Ticketing.DAL.Contract.Contract;
using Ticketing.DAL.Contract.Models;
using Ticketing.DTOModels.Models;
using Ticketing.Models.Models;

namespace Ticketing.BLL.Services;

public class InformationBLL : IInformationBLL
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IUserDAL _userDAL;

	public InformationBLL(IUnitOfWork unitOfWork, IUserDAL userDAL)
	{
		_unitOfWork = unitOfWork;
		_userDAL = userDAL;
	}

	public async Task<Result> Register(int Id, List<InformationDTO> information)
	{
		var user = await _userDAL.GetUser(Id);

		if (user == null)
			return new Result(BusinessMessages.UserNameNotExist);

		foreach (InformationDTO info in information)
		{
			if (Enum.IsDefined(typeof(Location), info.Location) == false)
				return new Result(BusinessRulesMessages.InvalidLocation);

			int i = await _userDAL.GetInfo(Id);

			if (i == 0 && info.Location != Location.Home)
			{
				if (information.Count == 1 || (information.Count == 2 && information[1].Location != Location.Home))
					return new Result(BusinessRulesMessages.HomeInformationIsRequired);
			}

			if (i == 1 && info.Location == Location.Home && information.Count == 1 || i == 1 && information.Count == 2 && information[0].Location == Location.Home)
				return new Result(BusinessMessages.UsersCanNotHaveMoreThan1HomeAddress);
			else if (i == 2)
				return new Result(BusinessMessages.UnableToAddMoreThan2Information);

			var information1 = new Information() { Address = info.Address, Location = info.Location, PhoneNumber = info.PhoneNumber, PostalCode = info.PostalCode };

			user.ContactInformation.Add(information1);

			await _unitOfWork.Comit();
		}
		return new Result();
	}
}