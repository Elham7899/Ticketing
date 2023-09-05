using Ticketing.Models.Models;

namespace Ticketing.DAL.Contract.Models;

public class Cabin
{
    public int Id { get; set; }

    public CabinClass CabinClass { get; set; }

    public int Seat { get; set; }
}
