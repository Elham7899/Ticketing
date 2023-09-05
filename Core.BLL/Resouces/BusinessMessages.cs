using Ticketing.Models.Core;

namespace Ticketing.BLL.Resouces;

public static class BusinessMessages
{
	public static ErrorModel CountryDoesNotExist { get; private set; } = new ErrorModel("E001", BusinessRulesMessages.CountryDoesNotExist);

	public static ErrorModel airlinecanhavemaximumof150planes { get; private set; } = new ErrorModel("E002", BusinessRulesMessages.airlinecanhavemaximumof150planes);

	public static ErrorModel AirplaenAirlineNotExist { get; private set; } = new ErrorModel("E003", BusinessRulesMessages.AirplaenAirlineNotExist);

	public static ErrorModel AirworthinessDoesNotUpdate { get; private set; } = new ErrorModel("E004", BusinessRulesMessages.AirworthinessDoesNotUpdate);

	public static ErrorModel America { get; private set; } = new ErrorModel("E005", BusinessRulesMessages.America);

	public static ErrorModel AmericanairlinesonlyhaveBoeing { get; private set; } = new ErrorModel("E006", BusinessRulesMessages.AmericanairlinesonlyhaveBoeing);

	public static ErrorModel AmericanAndQatarAirwaysHaveMaximum200lanes { get; private set; } = new ErrorModel("E007", BusinessRulesMessages.AmericanAndQatarAirwaysHaveMaximum200lanes);

	public static ErrorModel ConectionString { get; private set; } = new ErrorModel("E008", BusinessRulesMessages.ConectionString);

	public static ErrorModel CompanyDoesNotExist { get; private set; } = new ErrorModel("E009", BusinessRulesMessages.CompanyDoesNotExist);

	public static ErrorModel EroupeanJapaneseHaveBoeing { get; private set; } = new ErrorModel("E010", BusinessRulesMessages.EroupeanJapaneseHaveBoeing);

	public static ErrorModel Europe { get; private set; } = new ErrorModel("E011", BusinessRulesMessages.Europe);

	public static ErrorModel HomeInformationIsRequired { get; private set; } = new ErrorModel("E012", BusinessRulesMessages.HomeInformationIsRequired);

	public static ErrorModel IncorectPassword { get; private set; } = new ErrorModel("E013", BusinessRulesMessages.IncorectPassword);

	public static ErrorModel IncorrectEmail { get; private set; } = new ErrorModel("E014", BusinessRulesMessages.IncorrectEmail);

	public static ErrorModel InvalidAddress { get; private set; } = new ErrorModel("E015", BusinessRulesMessages.InvalidAddress);

	public static ErrorModel InvalidDate { get; private set; } = new ErrorModel("E016", BusinessRulesMessages.InvalidDate);

	public static ErrorModel InvalidLocation { get; private set; } = new ErrorModel("E017", BusinessRulesMessages.InvalidLocation);

	public static ErrorModel InvalidPostalCode { get; private set; } = new ErrorModel("E018", BusinessRulesMessages.InvalidPostalCode);

	public static ErrorModel IsAlreadyExists { get; private set; } = new ErrorModel("E019", BusinessRulesMessages.IsAlreadyExists);

	public static ErrorModel Lessthan5char { get; private set; } = new ErrorModel("E020", BusinessRulesMessages.Lessthan5char);

	public static ErrorModel NoCompanyForThisModelId { get; private set; } = new ErrorModel("E021", BusinessRulesMessages.NoCompanyForThisModelId);

	public static ErrorModel NoContinentForThisId { get; private set; } = new ErrorModel("E022", BusinessRulesMessages.NoContinentForThisId);

	public static ErrorModel PhoneNumberIsInvalid { get; private set; } = new ErrorModel("E023", BusinessRulesMessages.PhoneNumberIsInvalid);

	public static ErrorModel RegistrationNumberNotCorrect { get; private set; } = new ErrorModel("E024", BusinessRulesMessages.RegistrationNumberNotCorrect);

	public static ErrorModel Success { get; private set; } = new ErrorModel("E025", BusinessRulesMessages.Success);

	public static ErrorModel UnableToAddMoreThan2Information { get; private set; } = new ErrorModel("E026", BusinessRulesMessages.UnableToAddMoreThan2Information);

	public static ErrorModel UserIDDoesNotExist { get; private set; } = new ErrorModel("E027", BusinessRulesMessages.UserIDDoesNotExist);

	public static ErrorModel UsernameIsExist { get; private set; } = new ErrorModel("E028", BusinessRulesMessages.UsernameIsExist);

	public static ErrorModel UsernameMustBeMorethan5 { get; private set; } = new ErrorModel("E029", BusinessRulesMessages.UsernameMustBeMorethan5);

	public static ErrorModel UserNameNotExist { get; private set; } = new ErrorModel("E030", BusinessRulesMessages.UserNameNotExist);

	public static ErrorModel UsersCanNotHaveMoreThan1HomeAddress { get; private set; } = new ErrorModel("E031", BusinessRulesMessages.UsersCanNotHaveMoreThan1HomeAddress);

	public static ErrorModel WrongGender { get; private set; } = new ErrorModel("E032", BusinessRulesMessages.WrongGender);

}
