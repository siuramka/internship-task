using CalculatorSolid.Models;
using CalculatorSolid.Models.Types;
using CalculatorSolid.Repository;
using CalculatorSolid.Service;

namespace CalculatorSolid.Test;

/// <summary>
///     tests should be independent, small, easy to mantain
/// </summary>
public class Tests
{
    private MeetingService _meetingService;

    [SetUp]
    public void Setup()
    {
        _meetingService = new MeetingService(new MeetingRepository());
    }

    [Test]
    public void GetAllMeetings()
    {
        var meetings = _meetingService.GetAll().Any();
        Assert.True(meetings);
    }

    [Test]
    public void CreateMeeting()
    {
        var newMeeting = GenerateMeeting();
        _meetingService.Add(newMeeting);

        var wasAdded = _meetingService.GetAll().Contains(newMeeting);

        Assert.True(wasAdded);
    }

    [Test]
    public void DeleteMeeting()
    {
        var newMeeting = GenerateMeeting();

        _meetingService.Add(newMeeting);
        _meetingService.Delete(newMeeting);

        var wasRemoved = !_meetingService.GetAll().Contains(newMeeting);

        Assert.True(wasRemoved);
    }

    [Test]
    public void GetMeeting()
    {
        var newMeeting = GenerateMeeting();
        _meetingService.Add(newMeeting);
        var foundMeeting = _meetingService.Get(newMeeting.Name);

        Assert.NotNull(foundMeeting);
    }

    private Meeting GenerateMeeting()
    {
        var name = Guid.NewGuid().ToString();
        var newMeeting = new Meeting(name, "TestPerson", "TestDescription", Category.Hub, MeetingType.Live,
            DateTime.Now, DateTime.Now.AddHours(1), new List<string>());
        return newMeeting;
    }
}