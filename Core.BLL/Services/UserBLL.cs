using System.Text.RegularExpressions;
using Ticketing.BLL.Contract.Contract;
using Ticketing.BLL.Contract.Results;
using Ticketing.BLL.Resouces;
using Ticketing.DAL.Contract.Contract;
using Ticketing.DAL.Contract.Models;
using Ticketing.DTOModels.Models;
using Ticketing.Models.Models;

namespace Ticketing.BLL.Services;

public class UserBLL : IUserBLL
{
	private readonly IUnitOfWork _unitOfWork;

	private readonly ICountryDAL _countryDAL;

	private readonly IUserDAL _userDAL;

	public UserBLL(ICountryDAL countryDAL, IUnitOfWork unitOfWork, IUserDAL userDAL)
	{
		_countryDAL = countryDAL;

		_unitOfWork = unitOfWork;

		_userDAL = userDAL;
	}

	public async Task<Result> RegisterUser(UserDTO userDTO)
	{
		if (Enum.IsDefined(typeof(Gender), userDTO.Gender) == false)
			return new Result(BusinessMessages.WrongGender);

		if (Regex.IsMatch(userDTO.Email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$") == false)
			return new Result(BusinessMessages.IncorrectEmail);

		if (Regex.IsMatch(userDTO.Password, @"(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$") == false)
			return new Result(BusinessMessages.IncorectPassword);

		if (await _userDAL.UserIsExist(userDTO.UserName))
			return new Result(BusinessMessages.UsernameIsExist);

		var country = await _countryDAL.GetCountry(userDTO.NationalityId);

		if (country == null)
		{
			return new Result(BusinessMessages.CountryDoesNotExist);
		}

		var user = new User()
		{
			UserName = userDTO.UserName,
			FirstName = userDTO.FirstName,
			LastName = userDTO.LastName,
			Email = userDTO.Email,
			Password = userDTO.Password,
			Birthday = userDTO.Birthday,
			Gender1 = userDTO.Gender,
			Nationality = country,
			Status = userDTO.Status,
			ContactInformation = userDTO.ContactInformation.Select(n => new Information()
			{
				PhoneNumber = n.PhoneNumber,
				Address = n.Address,
				Location = n.Location,
				PostalCode = n.PostalCode
			}).ToList()
		};

		var id = await _userDAL.Insert(user);

		await _unitOfWork.Comit();

		return new Result();
	}

	public async Task<Result> UpdateUser(int id, UserDTO userDTO)
	{
		if (userDTO.Birthday > DateTime.Now)
			return new Result(BusinessMessages.InvalidDate);

		if (Enum.IsDefined(typeof(Gender), userDTO.Gender) == false)
			return new Result(BusinessMessages.WrongGender);

		if (Regex.IsMatch(userDTO.Email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$") == false)
			return new Result(BusinessMessages.IncorrectEmail);

		if (Regex.IsMatch(userDTO.Password, @"(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$") == false)
			return new Result(BusinessMessages.IncorectPassword);

		var country = await _countryDAL.GetCountry(userDTO.NationalityId);

		if (country == null)
		{
			return new Result(BusinessMessages.CountryDoesNotExist);
		}

		var user = await _userDAL.GetUser(id);

		if(user == null)
		{
			return new Result(BusinessMessages.UserIDDoesNotExist);
		}

		user.UserName = userDTO.UserName;
		user.FirstName = userDTO.FirstName;
		user.LastName = userDTO.LastName;
		user.Email = userDTO.Email;
		user.Password = userDTO.Password;
		user.Birthday = userDTO.Birthday;
		user.Gender1 = userDTO.Gender;
		user.Status = userDTO.Status;
		user.Nationality = country;
		user.ContactInformation = userDTO.ContactInformation.Select(c => new Information()
		{
			Address = c.Address,
			Location = c.Location,
			PhoneNumber =
			c.PhoneNumber,
			PostalCode = c.PostalCode
		}).ToList();

		_userDAL.Delete(id);

		await _unitOfWork.Comit();

		return new Result();
	}

	public async Task<Result> DeleteUser(int id)
	{
		var user = await _userDAL.GetUser(id);

		if (user == null)
		{
			return new Result(
			BusinessMessages.UserNameNotExist);
		}

		_userDAL.Delete(id);

		await _unitOfWork.Comit();

		return new Result();
	}

	public async Task<Result<User>> GetUser(int id)
	{
		var user = await _userDAL.Select(id);

		if (user == null)
		{
			return new Result<User>(BusinessMessages.UserNameNotExist);
		}

		return new Result<User>(await _userDAL.Select(id));
	}
}
