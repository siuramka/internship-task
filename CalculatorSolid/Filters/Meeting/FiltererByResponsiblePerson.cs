namespace CalculatorSolid.Filters.Meeting;

public class FiltererByResponsiblePerson : IFiltererCondition
{
    private readonly string _responsiblePerson;

    public FiltererByResponsiblePerson(string responsiblePerson)
    {
        _responsiblePerson = responsiblePerson;
    }

    public List<Models.Meeting> ApplyFilter(List<Models.Meeting> meetings)
    {
        return meetings.Where(meeting => meeting.ResponsiblePerson.Equals(_responsiblePerson)).ToList();
    }
}