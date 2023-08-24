using CalculatorSolid.Models.Types;

namespace CalculatorSolid.Filters.Meeting;

public class FiltererByCategory : IFiltererCondition
{
    private readonly Category _category;

    public FiltererByCategory(Category category)
    {
        _category = category;
    }

    public List<Models.Meeting> ApplyFilter(List<Models.Meeting> meetings)
    {
        return meetings.Where(meeting => meeting.Category == _category).ToList();
    }
}