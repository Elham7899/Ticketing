namespace Ticketing.DAL.Contract.Models;

public class Airline
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public Country? Country { get; set; }
}
