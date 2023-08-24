using CalculatorSolid.InOut;
using CalculatorSolid.Models;

namespace CalculatorSolid.Repository;

public class MeetingRepository
{
    private readonly List<Meeting> _meetings;

    public MeetingRepository()
    {
        _meetings = MeetingReader.GetAllMeetings();
    }

    public void Create(Meeting meeting)
    {
        _meetings.Add(meeting);
        SaveChanges();
    }

    public void Delete(Meeting meeting)
    {
        _meetings.Remove(meeting);
        SaveChanges();
    }

    public void Update(Meeting meeting, Meeting newMeeting)
    {
        _meetings.Remove(meeting);
        _meetings.Add(newMeeting);
        SaveChanges();
    }

    public Meeting? Get(string name)
    {
        return _meetings.Where(meeting => meeting.Name == name).FirstOrDefault();
    }

    public List<Meeting> GetAll()
    {
        return new List<Meeting>(_meetings);
    }

    public void SaveChanges()
    {
        MeetingWriter.WriteAllMeetings(_meetings);
    }
}