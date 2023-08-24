namespace CalculatorSolid.Filters.Meeting;

public class FiltererByDates : IFiltererCondition
{
    private readonly DateTime? _endDate;
    private readonly DateTime _startDate;

    public FiltererByDates(DateTime startDate)
    {
        _startDate = startDate;
    }

    public FiltererByDates(DateTime startDate, DateTime endDate)
    {
        _startDate = startDate;
        _endDate = endDate;
    }

    public List<Models.Meeting> ApplyFilter(List<Models.Meeting> meetings)
    {
        if (_endDate.HasValue)
            return meetings.Where(meeting => meeting.StartDate >= _startDate && meeting.StartDate <= _endDate.Value)
                .ToList();
        return meetings.Where(meeting => meeting.StartDate >= _startDate).ToList();
    }
}