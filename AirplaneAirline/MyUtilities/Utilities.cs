namespace Ticketing.Host.MyUtilities;

public class Utilities
{
    private static string _filePath = "C:\\Users\\Elham\\OneDrive\\Desktop\\TicketingProject\\AirplaneAirline\\Logs\\Log.txt";

    public static string WriteLoges(Exception ex)
    {
        File.AppendAllText(_filePath, $"\n{ex.Message}-{DateTime.Now}");
        File.AppendAllText(_filePath, "\n-----------------------------------------------");

        return "Internal Server Error";
    }
}
