using CalculatorSolid.Filters.Meeting;
using CalculatorSolid.Models;
using CalculatorSolid.Repository;

namespace CalculatorSolid.Service;

//Could add DTO's, interfaces etc but no time al dont want to over engineer it also since the requirements dont say that the code should be open to addition.
public class MeetingService
{
    private readonly MeetingRepository _meetingRepository;

    public MeetingService(MeetingRepository meetingRepository)
    {
        _meetingRepository = meetingRepository;
    }

    public List<Meeting?> GetAll()
    {
        return _meetingRepository.GetAll();
    }

    public Meeting? Get(string name)
    {
        return _meetingRepository.Get(name);
    }

    public void Add(Meeting meeting)
    {
        _meetingRepository.Create(meeting);
    }

    public void Delete(Meeting meeting)
    {
        _meetingRepository.Delete(meeting);
    }

    public void RemovePersonFromMeeting(string meetingName, string person)
    {
        var tempMeeting = _meetingRepository.Get(meetingName);
        var updatedMeeting = new Meeting(tempMeeting);

        if (CanRemovePersonFromMeeting(updatedMeeting, person))
        {
            updatedMeeting.Atendees.Remove(person);
            _meetingRepository.Update(tempMeeting, updatedMeeting);
        }
    }

    private bool CanRemovePersonFromMeeting(Meeting meeting, string person)
    {
        return !meeting.Atendees.Contains(person) && meeting.ResponsiblePerson != person;
    }

    public void AddPersonToMeeting(string meetingName, string person, DateTime time)
    {
        var tempMeeting = _meetingRepository.Get(meetingName);
        var updatedMeeting = new Meeting(tempMeeting);

        if (CanAddPersonToMeeting(person, time, updatedMeeting))
        {
            updatedMeeting.Atendees.Add(person);
            _meetingRepository.Update(tempMeeting, updatedMeeting);
        }
    }

    private bool CanAddPersonToMeeting(string person, DateTime time, Meeting meeting)
    {
        var hasOtherMeetings = _meetingRepository.GetAll().Any(otherMeeting =>
            time >= otherMeeting.StartDate && time <= otherMeeting.EndDate);

        var alreadyInMeeting = meeting.Atendees.Contains(person);

        return meeting.ResponsiblePerson != person && !alreadyInMeeting && !hasOtherMeetings;
    }

    public List<Meeting> Filter(IFiltererCondition filtererCondition)
    {
        var meetings = _meetingRepository.GetAll();
        return filtererCondition.ApplyFilter(meetings);
    }
}