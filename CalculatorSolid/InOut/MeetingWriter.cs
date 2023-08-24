using System.Text.Json;
using CalculatorSolid.Models;

namespace CalculatorSolid.InOut;

public static class MeetingWriter
{
    private static readonly string DataPath = "data.json";

    public static void WriteAllMeetings(List<Meeting> meetings)
    {
        var serializedMeetings = JsonSerializer.Serialize(meetings);
        File.WriteAllText(DataPath, serializedMeetings);
    }
}