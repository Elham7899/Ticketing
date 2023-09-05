namespace Ticketing.Models.Models;

public enum Gender
{
    Male = 1,
    Female = 2
}

public enum Location
{
    Home = 1,
    Work = 2
}

public enum CabinClass
{
    Economy = 1,
    PremiumEconomy = 2,
    Business = 3,
    Firstclass = 4
}

public enum Airworthiness
{
    Grounded = 1,         //OutOfServis = 1,
    ClearedForTakeOff = 2 //ReadyForDeparture = 2
}