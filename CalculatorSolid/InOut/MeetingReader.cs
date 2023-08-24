using System.Text.Json;
using CalculatorSolid.Models;

namespace CalculatorSolid.InOut;

public static class MeetingReader
{
    private static readonly string DataPath = "data.json";

    public static List<Meeting> GetAllMeetings()
    {
        var jsonData = File.ReadAllText(DataPath);
        var deserializedMeetings = JsonSerializer.Deserialize<List<Meeting>>(jsonData);

        return new List<Meeting>(deserializedMeetings);
    }
}