using CalculatorSolid.Models.Types;

namespace CalculatorSolid.Filters.Meeting;

public class FiltererByType : IFiltererCondition
{
    private readonly MeetingType _type;

    public FiltererByType(MeetingType type)
    {
        _type = type;
    }

    public List<Models.Meeting> ApplyFilter(List<Models.Meeting> meetings)
    {
        return meetings.Where(meeting => meeting.MeetingType == _type).ToList();
    }
}