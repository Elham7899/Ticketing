using System.ComponentModel.DataAnnotations;
using Ticketing.Models.Models;

namespace Ticketing.DTOModels.Models;

public class InformationDTO
{
	[Required]
	[MinLength(11)]
	[MaxLength(11)]
	public string? PhoneNumber { get; set; }

	[Required]
	[MinLength(20)]
	[MaxLength(50)]
	public string? Address { get; set; }

	[Required]
	[MinLength(10)]
	[MaxLength(10)]
	public string? PostalCode { get; set; }

	public Location Location { get; set; }
}
