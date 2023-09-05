using System.ComponentModel.DataAnnotations;
using Ticketing.DTOModels.ValidationAttributes;
using Ticketing.Models.Models;

namespace Ticketing.DTOModels.Models;

public class UserDTO
{
	[Required]
	public string? FirstName { get; set; }

	[Required]
	public string? LastName { get; set; }

	[Required]
	public string? Email { get; set; }

	[Required]
	public string? Password { get; set; }

	[Required]
	[MinLength(5)]
	public string? UserName { get; set; }

	public Gender Gender { get; set; }

	public int NationalityId { get; set; }

	[Required]
	[BirthDateValidation]
	public DateTime? Birthday { get; set; }

	public bool? Status { get; set; }

	public List<InformationDTO> ContactInformation { get; set; }
}
