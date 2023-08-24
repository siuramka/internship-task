namespace CalculatorSolid.Filters.Meeting;

public interface IFiltererCondition
{
    List<Models.Meeting> ApplyFilter(List<Models.Meeting> meetings);
}