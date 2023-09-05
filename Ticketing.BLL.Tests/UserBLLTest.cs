using Moq;
using Ticketing.BLL.Resouces;
using Ticketing.BLL.Services;
using Ticketing.DAL.Contract.Contract;
using Ticketing.DAL.Contract.Models;
using Ticketing.DTOModels.Models;
using Ticketing.Models.Models;

namespace Ticketing.BLL.Tests;

public class UserBLLTest
{
	private readonly UserBLL _userBLL;

	private readonly UserDTO _userDTO;

	private readonly Mock<IUnitOfWork> _unitOfWork;
	private readonly Mock<ICountryDAL> _countryDAL;
	private readonly Mock<IUserDAL> _userDAL;

	public UserBLLTest()
	{
		_unitOfWork = new Mock<IUnitOfWork>();
		_userDAL = new Mock<IUserDAL>();
		_countryDAL = new Mock<ICountryDAL>();

		_userBLL = new UserBLL(_countryDAL.Object, _unitOfWork.Object, _userDAL.Object);

		_userDTO = new UserDTO()
		{
			Birthday = new DateTime(1399, 06, 04),
			FirstName = "Elham",
			LastName = "Ghorbanzade",
			Email = "eli@gmail.com",
			Gender = Gender.Female,
			Password = "elHam1378@",
			NationalityId = 10,
			UserName = "EliGoli",
			Status = true
		};
	}

	[Fact]
	public async Task IfCountryNotExistReturnMessageCountryDoesNotExist()
	{
		_countryDAL.Setup(x => x.GetCountry(It.IsAny<int>())).ReturnsAsync(() => { return null; });

		var result = await _userBLL.RegisterUser(_userDTO);

		Assert.True(result.ErrorModel.Code == BusinessMessages.CountryDoesNotExist.Code);
	}

	[Fact]
	public async Task IfCountryNotExistReturnMessgeCountryDoesNotExistForUpdate()
	{
		_countryDAL.Setup(x => x.GetCountry(It.IsAny<int>())).ReturnsAsync(() => { return null; });

		var result = await _userBLL.UpdateUser(It.IsAny<int>(), _userDTO);

		Assert.True(result.ErrorModel.Code == BusinessMessages.CountryDoesNotExist.Code);
	}

	[Fact]
	public async Task IfUserNameExistReturnMessageUserNameExistForUpdate()
	{
		_userDAL.Setup(x => x.GetUser(It.IsAny<int>())).ReturnsAsync(() => { return null; });

		_countryDAL.Setup(x => x.GetCountry(It.IsAny<int>())).ReturnsAsync(() => { return new Country(); });

		var result = await _userBLL.UpdateUser(It.IsAny<int>(), _userDTO);

		Assert.True(result.ErrorModel.Code == BusinessMessages.UserIDDoesNotExist.Code);
	}

	[Fact]
	public async Task IfUserNameExistReturnMessageUserNameExist()
	{
		_userDAL.Setup(x => x.UserIsExist(It.IsAny<string>())).Returns(() => { return Task.FromResult(true); });

		var result = await _userBLL.RegisterUser(_userDTO);

		Assert.True(result.ErrorModel.Code == BusinessMessages.UsernameIsExist.Code);
	}

	[InlineData("12345678")]
	[InlineData("ASDQWEAS")]
	[InlineData("qazwsxedc")]
	[InlineData("qW1234")]
	[Theory]
	public async Task IfPasswordFormatIsInvalidReturnMessagePasswordIsWrong(string password)
	{
		_userDTO.Password = password;

		var result = await _userBLL.RegisterUser(_userDTO);

		Assert.True(result.ErrorModel.Code == BusinessMessages.IncorectPassword.Code);
	}

	[InlineData("12345678")]
	[InlineData("ASDQWEAS")]
	[InlineData("qazwsxedc")]
	[InlineData("qW1234")]
	[Theory]
	public async Task IfPasswordFormatIsInvalidReturnMessagePasswordIsWrongForUpdate(string password)
	{
		_userDTO.Password = password;

		var result = await _userBLL.UpdateUser(It.IsAny<int>(), _userDTO);

		Assert.True(result.ErrorModel.Code == BusinessMessages.IncorectPassword.Code);
	}

	[InlineData("elham.gh")]
	[Theory]
	public async Task IfEmailFormatIsInvalidReturnMessageEmailIsWrong(string email)
	{
		_userDTO.Email = email;

		var result = await _userBLL.RegisterUser(_userDTO);

		Assert.True(result.ErrorModel.Code == BusinessMessages.IncorrectEmail.Code);
	}

	[InlineData("elham.gh")]
	[Theory]
	public async Task IfEmailFormatIsInvalidReturnMessageEmailIsWrongForUpdate(string email)
	{
		_userDTO.Email = email;

		var result = await _userBLL.UpdateUser(It.IsAny<int>(), _userDTO);

		Assert.True(result.ErrorModel.Code == BusinessMessages.IncorrectEmail.Code);
	}

	[Fact]
	public async Task IfUserNameDoesNotExistReturnMessageUserNameDoesNotExist()
	{
		_userDAL.Setup(u => u.GetUser(It.IsAny<int>())).ReturnsAsync(() => { return null; });

		var result = await _userBLL.DeleteUser(It.IsAny<int>());

		Assert.True(result.ErrorModel.Code == BusinessMessages.UserNameNotExist.Code);
	}
}