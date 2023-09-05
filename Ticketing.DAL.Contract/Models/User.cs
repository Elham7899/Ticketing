using Ticketing.Models.Models;

namespace Ticketing.DAL.Contract.Models;

public class User
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? UserName { get; set; }

    public Gender Gender1 { get; set; }

    public Country? Nationality { get; set; }

    public DateTime? Birthday { get; set; }

    public bool? Status { get; set; }

    public List<Information>? ContactInformation { get; set; }
}
