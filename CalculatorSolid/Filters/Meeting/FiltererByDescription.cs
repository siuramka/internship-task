namespace CalculatorSolid.Filters.Meeting;

public class FiltererByDescription : IFiltererCondition
{
    private readonly string _description;

    public FiltererByDescription(string description)
    {
        _description = description;
    }

    public List<Models.Meeting> ApplyFilter(List<Models.Meeting> meetings)
    {
        return meetings.Where(meeting => meeting.Description.Contains(_description)).ToList();
    }
}