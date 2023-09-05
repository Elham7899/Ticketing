using Moq;
using Ticketing.BLL.Resouces;
using Ticketing.BLL.Services;
using Ticketing.DAL.Contract.Contract;
using Ticketing.DAL.Contract.Models;
using Ticketing.DTOModels.Models;

namespace Ticketing.BLL.Tests;

public class InformationBLLTest
{
	private readonly InformationBLL _informationBLL;

	private List<InformationDTO> _informationDTO;

	private readonly Mock<IUnitOfWork> _unitOfWork;
	private readonly Mock<IUserDAL> _userDAL;

	public InformationBLLTest()
	{
		_unitOfWork = new Mock<IUnitOfWork>();
		_userDAL = new Mock<IUserDAL>();

		_informationDTO = new List<InformationDTO>()
		{
			new InformationDTO()
			{
				 PostalCode = "1234567891",
				 PhoneNumber = "09122688734",
				 Location = Models.Models.Location.Work,
				 Address="Tehransar/bolvarasli/khiabanShahed"
			}
		};

		_informationBLL = new InformationBLL(_unitOfWork.Object, _userDAL.Object);
	}

	[Fact]
	public async Task IfUserNameDoesNotExistReturnMessageUserNameDoesNotExist()
	{
		_userDAL.Setup(u => u.GetUser(It.IsAny<int>())).ReturnsAsync(() => { return null; });

		var result = await _informationBLL.Register(It.IsAny<int>(), _informationDTO);

		Assert.True(result.ErrorModel.Code == BusinessMessages.UserNameNotExist.Code);
	}

	[Fact]
	public async Task IfUserHasNoInformationReturnMessageHomeIsRequired()
	{
		_userDAL.Setup(u => u.GetUser(It.IsAny<int>())).ReturnsAsync(() => { return new User(); });

		_userDAL.Setup(u => u.GetInfo(It.IsAny<int>())).Returns(() => { return Task.FromResult(0); });

		var result = await _informationBLL.Register(It.IsAny<int>(), _informationDTO);

		Assert.True(result.ErrorModel.Code == BusinessMessages.HomeInformationIsRequired.Code);
	}

	[Fact]
	public async Task IfUserHasOneInformationReturnMessageUserCantHaveMoreThanOneHome()
	{
		_userDAL.Setup(u => u.GetUser(It.IsAny<int>())).ReturnsAsync(() => { return new User(); });

		_userDAL.Setup(u => u.GetInfo(It.IsAny<int>())).Returns(() => { return Task.FromResult(1); });

		_informationDTO = new List<InformationDTO>() { new InformationDTO() { Location = Models.Models.Location.Home } };

		var result = await _informationBLL.Register(It.IsAny<int>(), _informationDTO);

		Assert.True(result.ErrorModel.Code == BusinessMessages.UsersCanNotHaveMoreThan1HomeAddress.Code);
	}

	[Fact]
	public async Task IfUserHasTwoInformationReturnMessageUserCannotHaveMoreThanTwoInformation()
	{
		_userDAL.Setup(u => u.GetUser(It.IsAny<int>())).ReturnsAsync(() => { return new User(); });

		_userDAL.Setup(u => u.GetInfo(It.IsAny<int>())).Returns(() => { return Task.FromResult(2); });

		var result = await _informationBLL.Register(It.IsAny<int>(), _informationDTO);

		Assert.True(result.ErrorModel.Code == BusinessMessages.UnableToAddMoreThan2Information.Code);
	}
}
