namespace CalculatorSolid.Filters.Meeting;

public class FiltererByAtendeeCount : IFiltererCondition
{
    private readonly int _atendeeCount;

    public FiltererByAtendeeCount(int atendeeCount)
    {
        _atendeeCount = atendeeCount;
    }

    public List<Models.Meeting> ApplyFilter(List<Models.Meeting> meetings)
    {
        return meetings.Where(meeting => meeting.Atendees.Count > _atendeeCount).ToList();
    }
}