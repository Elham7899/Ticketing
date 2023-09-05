namespace Ticketing.DAL.Contract.Models;

public class Airplane
{
    public int Id { get; set; }

    public string? Model { get; set; }

    public Company? Company { get; set; }
}
