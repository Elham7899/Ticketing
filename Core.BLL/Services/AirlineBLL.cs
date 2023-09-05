using System.Text.RegularExpressions;
using Ticketing.BLL.Contract.Contract;
using Ticketing.BLL.Contract.Results;
using Ticketing.BLL.Resouces;
using Ticketing.DAL.Contract.Contract;
using Ticketing.DAL.Contract.Models;
using Ticketing.DTOModels.Models;
using Ticketing.Models.Models;

namespace Ticketing.BLL.Services;

public class AirlineBLL : IAirlineBLL
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IAirlineDAL _airlineDAL;
	private readonly IAirplaneDAL _airplaneDAL;
	private readonly ICountryDAL _countryDAL;

	public AirlineBLL(IUnitOfWork unitOfWork, IAirlineDAL airlineDAL, IAirplaneDAL airplaneDAL, ICountryDAL countryDAL)
	{
		_unitOfWork = unitOfWork;
		_airlineDAL = airlineDAL;
		_airplaneDAL = airplaneDAL;
		_countryDAL = countryDAL;
	}

	public async Task<Result> SetAirLineInfo(AirlineDTO airLineDTO)
	{
		var country = await _countryDAL.GetCountry(airLineDTO.CountryId);

		if (country == null)
		{
			return new Result(BusinessMessages.CountryDoesNotExist);
		}

		var airline = new Airline() { Country = country, Name = airLineDTO.Name };

		await _airlineDAL.Insert(airline);

		await _unitOfWork.Comit();

		return new Result();
	}

	public async Task<Result> SetAirPlanesOfAirLine(int airlineId, LinePlaneDTO linePlaneDTO)
	{

		string? continent = await _airlineDAL.SelectContinentOfAirline(airlineId);

		int companyID = await _airlineDAL.SelectAirplaneCompany(linePlaneDTO.AirplaneModelId);

		if (continent == null)
			return new Result(BusinessMessages.NoContinentForThisId);

		if (companyID == 0)
			return new Result(BusinessMessages.NoCompanyForThisModelId);

		if (continent != BusinessRulesMessages.Europe && continent != BusinessRulesMessages.America && airlineId != 9 && companyID == 2)
			return new Result(BusinessRulesMessages.EroupeanJapaneseHaveBoeing);

		if (continent == BusinessRulesMessages.America && companyID == 1)
			return new Result(BusinessRulesMessages.AmericanairlinesonlyhaveBoeing);

		int i = await _airlineDAL.CountOfPlane(airlineId);

		if (continent == "America" || airlineId == 12)
		{
			if (200 - i - 1 < 0)
				return new Result(string.Format(BusinessRulesMessages.AmericanAndQatarAirwaysHaveMaximum200lanes, i));
		}
		else
		{
			if (150 - i - 1 < 0)
				return new Result(string.Format(BusinessRulesMessages.airlinecanhavemaximumof150planes, i));
		}

		var airline = await _airlineDAL.GetAirline(airlineId);
		var airplane = await _airplaneDAL.GetAirplane(airlineId);

		if (airline == null || airplane == null)
		{
			return new Result(BusinessMessages.AirplaenAirlineNotExist);
		}

		

		bool A = await _airlineDAL.SelectRegisterationNumber(linePlaneDTO.RegistrationNumber);

		if (A == true)
			return new Result(BusinessMessages.IsAlreadyExists);

		var linePlane = new LinePlane();
		linePlane.Airworthiness = linePlaneDTO.Airworthiness;
		linePlane.RegistrationNumber = linePlaneDTO.RegistrationNumber;
		linePlane.Airline = airline;
		linePlane.Airplane = airplane;
		linePlane.Cabins = linePlaneDTO.Cabins.Select(c => new Cabin() { CabinClass = c.CabinClass, Seat = c.Seat }).ToList();

		await _airlineDAL.InsertAirplaneOfAirline(linePlane);

		await _unitOfWork.Comit();

		Regex regex = new Regex("^[N][0-9]{1,5}?$|^[N][0-9]{4}[A-Za-z]?$");
		if (continent == "America" && regex.IsMatch(linePlaneDTO.RegistrationNumber) == false)
			return new Result(BusinessMessages.RegistrationNumberNotCorrect);

		regex = new Regex("^[G][-][A-Z]{4}$");
		if (airlineId == 5 && regex.IsMatch(linePlaneDTO.RegistrationNumber) == false)
			return new Result(BusinessMessages.RegistrationNumberNotCorrect);

		regex = new Regex("^[A-Za-z]{5}$");
		if (airlineId != 5 && continent != BusinessRulesMessages.America && regex.IsMatch(linePlaneDTO.RegistrationNumber) == false)
			return new Result(BusinessMessages.RegistrationNumberNotCorrect);

		var r = linePlane.Id;

		return new Result();
	}

	public async Task<Result> SelectAirplaneOfLine(int id)
	{
		return new Result(await _airplaneDAL.SelectAirplaneOfAirline(id));
	}

	public async Task<Result<LinePlane>> ChangeAirworthiness(int id, Airworthiness airworthiness)
	{
		var lineplane = await _airlineDAL.GetLinePlane(id);

		if (lineplane == null)
			return new Result<LinePlane>(BusinessMessages.AirworthinessDoesNotUpdate);

		lineplane.Airworthiness = airworthiness;

		await _unitOfWork.Comit();

		return new Result<LinePlane>();
	}
}
