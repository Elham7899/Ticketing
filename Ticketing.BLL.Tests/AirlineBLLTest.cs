using Moq;
using Ticketing.BLL.Resouces;
using Ticketing.BLL.Services;
using Ticketing.DAL.Contract.Contract;
using Ticketing.DAL.Contract.Models;
using Ticketing.DTOModels.Models;
using Ticketing.Models.Models;

namespace Ticketing.BLL.Tests;

public class AirlineBLLTest
{
	private readonly AirlineBLL _airlineBLL;

	private readonly AirlineDTO _airlineDTO;

	private readonly LinePlaneDTO _lineplaneDTO;

	private readonly Mock<IUnitOfWork> _unitOfWork;
	private readonly Mock<IAirlineDAL> _airlineDAL;
	private readonly Mock<IAirplaneDAL> _airplaneDAL;
	private readonly Mock<ICountryDAL> _countryDAL;

	public AirlineBLLTest()
	{
		_unitOfWork = new Mock<IUnitOfWork>();
		_airplaneDAL = new Mock<IAirplaneDAL>();
		_airlineDAL = new Mock<IAirlineDAL>();
		_countryDAL = new Mock<ICountryDAL>();

		_airlineDTO = new AirlineDTO() { Name = "Airbus" };

		_lineplaneDTO = new LinePlaneDTO();

		_airlineBLL = new AirlineBLL(_unitOfWork.Object, _airlineDAL.Object, _airplaneDAL.Object, _countryDAL.Object);
	}

	[Fact]
	public async Task IfCountryIsNullReturnMessageCountryIsNull()
	{
		_countryDAL.Setup(c => c.GetCountry(It.IsAny<int>())).ReturnsAsync(() => { return null; });

		var result = await _airlineBLL.SetAirLineInfo(_airlineDTO);

		Assert.True(result.ErrorModel.Code == BusinessMessages.CountryDoesNotExist.Code);
	}

	[Fact]
	public async Task IfContinentIsNullReturnMessageContinentIsNull()
	{
		_airlineDAL.Setup(x => x.SelectContinentOfAirline(It.IsAny<int>())).ReturnsAsync(() => { return null; });

		var result = await _airlineBLL.SetAirPlanesOfAirLine(1, _lineplaneDTO);

		Assert.True(result.ErrorModel.Code == BusinessMessages.NoContinentForThisId.Code);
	}

	[Fact]
	public async Task IfCompanyIdIsZeroReturnMessageNoCompanyForThisModelId()
	{
		_airlineDAL.Setup(x => x.SelectContinentOfAirline(It.IsAny<int>())).ReturnsAsync(() => { return ""; });

		_airlineDAL.Setup(a => a.SelectAirplaneCompany(It.IsAny<int>())).Returns(() => { return Task.FromResult(0); });

		var result = await _airlineBLL.SetAirPlanesOfAirLine(It.IsAny<int>(), _lineplaneDTO);

		Assert.True(result.ErrorModel.Code == BusinessMessages.NoCompanyForThisModelId.Code);
	}

	[Fact]
	public async Task IfAirlineOrAirplaneReurnMessageAirlineORAirplaneDoesNotExist()
	{
		_airlineDAL.Setup(x => x.SelectContinentOfAirline(It.IsAny<int>())).ReturnsAsync(() => { return ""; });

		_airlineDAL.Setup(a => a.SelectAirplaneCompany(It.IsAny<int>())).Returns(() => { return Task.FromResult(1); });

		_airlineDAL.Setup(a => a.GetAirline(It.IsAny<int>())).ReturnsAsync(() => { return null; });

		_airplaneDAL.Setup(a => a.GetAirplane(It.IsAny<int>())).ReturnsAsync(() => { return null; });

		var result = await _airlineBLL.SetAirPlanesOfAirLine(It.IsAny<int>(), _lineplaneDTO);

		Assert.True(result.ErrorModel.Code == BusinessMessages.AirplaenAirlineNotExist.Code);
	}


	[Fact]
	public async Task IfRegisterationNumberIsNotExistReturnMessageRegistrationNumberIsNotExist()
	{
		_airlineDAL.Setup(x => x.SelectContinentOfAirline(It.IsAny<int>())).ReturnsAsync(() => { return ""; });

		_airlineDAL.Setup(a => a.SelectAirplaneCompany(It.IsAny<int>())).Returns(() => { return Task.FromResult(1); });

		_airlineDAL.Setup(a => a.GetAirline(It.IsAny<int>())).ReturnsAsync(() => { return new Airline(); });

		_airplaneDAL.Setup(a => a.GetAirplane(It.IsAny<int>())).ReturnsAsync(() => { return new Airplane(); });

		_airlineDAL.Setup(a => a.SelectRegisterationNumber(It.IsAny<string>())).Returns(() => { return Task.FromResult(true); });

		var result = await _airlineBLL.SetAirPlanesOfAirLine(It.IsAny<int>(), _lineplaneDTO);

		Assert.True(result.ErrorModel.Code == BusinessMessages.IsAlreadyExists.Code);
	}

	[Fact]
	public async Task IfLineplaneDoesNotExistReturnMessageAirworthinethIsNotUpdate()
	{
		_airlineDAL.Setup(l => l.GetLinePlane(It.IsAny<int>())).ReturnsAsync(() => { return null; });

		var result = await _airlineBLL.ChangeAirworthiness(It.IsAny<int>(), Airworthiness.Grounded);

		Assert.True(result.ErrorModel.Code == BusinessMessages.AirworthinessDoesNotUpdate.Code);
	}

}
