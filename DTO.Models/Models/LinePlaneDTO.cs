using Ticketing.Models.Models;

namespace Ticketing.DTOModels.Models;

public class LinePlaneDTO
{
    public int AirlineId { get; set; }

    public int AirplaneModelId { get; set; }

    public Airworthiness Airworthiness { get; set; }

    public string? RegistrationNumber { get; set; }

    public List<CabinDTO> Cabins { get; set; }
}
