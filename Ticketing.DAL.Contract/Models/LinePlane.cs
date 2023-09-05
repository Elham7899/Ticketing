using Ticketing.DAL.Contract.Models;
using Ticketing.Models.Models;

public class LinePlane
{
    public int Id { get; set; }

    public Airline? Airline { get; set; }

    public Airplane? Airplane { get; set; }

    public Airworthiness Airworthiness { get; set; }

    public string? RegistrationNumber { get; set; }

    public List<Cabin>? Cabins { get; set; }
}
