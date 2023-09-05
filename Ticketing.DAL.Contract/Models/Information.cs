using Ticketing.Models.Models;

namespace Ticketing.DAL.Contract.Models;

public class Information
{
    public int Id { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public string? PostalCode { get; set; }

    public Location Location { get; set; }

  //  public int UserId { get; set; } 
}
