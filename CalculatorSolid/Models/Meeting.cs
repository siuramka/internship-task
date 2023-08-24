using System.Text.Json.Serialization;
using CalculatorSolid.Models.Types;

namespace CalculatorSolid.Models;

public class Meeting : IEquatable<Meeting>
{
    public Meeting(Meeting newMeeting)
    {
        Name = newMeeting.Name;
        ResponsiblePerson = newMeeting.ResponsiblePerson;
        Description = newMeeting.Description;
        Category = newMeeting.Category;
        MeetingType = newMeeting.MeetingType;
        StartDate = newMeeting.StartDate;
        EndDate = newMeeting.EndDate;
        Atendees = newMeeting.Atendees;
    }

    [JsonConstructor]
    public Meeting(string name, string responsiblePerson, string description, Category category,
        MeetingType meetingType, DateTime startDate, DateTime endDate, List<string> atendees)
    {
        Name = name;
        ResponsiblePerson = responsiblePerson;
        Description = description;
        Category = category;
        MeetingType = meetingType;
        StartDate = startDate;
        EndDate = endDate;
        Atendees = atendees;
    }

    public string Name { get; set; }
    public string ResponsiblePerson { get; set; }
    public string Description { get; set; }
    public Category Category { get; set; }
    public MeetingType MeetingType { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<string> Atendees { get; set; }

    public bool Equals(Meeting? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Name == other.Name && ResponsiblePerson.Equals(other.ResponsiblePerson) &&
               Description == other.Description && Category == other.Category && MeetingType == other.MeetingType &&
               StartDate.Equals(other.StartDate) && EndDate.Equals(other.EndDate);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Meeting)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, ResponsiblePerson, Description, (int)Category, (int)MeetingType, StartDate,
            EndDate);
    }

    public override string ToString()
    {
        var attendees = Atendees != null ? string.Join(", ", Atendees) : "No attendees";

        return $"Name: {Name}\n" +
               $"Responsible Person: {ResponsiblePerson}\n" +
               $"Description: {Description}\n" +
               $"Category: {Category}\n" +
               $"Meeting Type: {MeetingType}\n" +
               $"Start Date: {StartDate}\n" +
               $"End Date: {EndDate}\n" +
               $"Attendees: {attendees}\n\n";
    }
}