using CalculatorSolid.Filters.Meeting;
using CalculatorSolid.Models;
using CalculatorSolid.Models.Types;
using CalculatorSolid.Repository;
using CalculatorSolid.Service;

var meetings = new List<Meeting>();


var repo = new MeetingRepository();

var service = new MeetingService(repo);

while (true)
{
    Console.WriteLine("1 - Create meeting");
    Console.WriteLine("2 - Delete a meeting");
    Console.WriteLine("3 - Add person to meeting");
    Console.WriteLine("4 - Remove person from meeting");
    Console.WriteLine("5 - List all meetings / Filtering");

    var readData = Console.ReadLine();

    if (readData == "1") CommandAdd();

    if (readData == "2") CommandDelete();

    if (readData == "3") CommandAddToMeeting();

    if (readData == "4") CommandRemoveFromMeeting();

    if (readData == "5") CommandListFilter();
}

void CommandAdd()
{
    Console.WriteLine("Name: ");
    var name = Console.ReadLine();
    Console.WriteLine("ResponsiblePerson: ");
    var ResponsiblePerson = Console.ReadLine();
    Console.WriteLine("Description: ");
    var Description = Console.ReadLine();
    Console.WriteLine("Category : ");
    var Category = int.Parse(Console.ReadLine());
    Console.WriteLine("Type : ");
    var Type = int.Parse(Console.ReadLine());
    Console.WriteLine("StartDate : ");
    var StartDate = DateTime.Parse(Console.ReadLine());
    Console.WriteLine("EndDate : ");
    var EndDate = DateTime.Parse(Console.ReadLine());

    var meeting = new Meeting(name, ResponsiblePerson, Description, (Category)Category, (MeetingType)Type,
        StartDate, EndDate, new List<string>());

    service.Add(meeting);

    Console.WriteLine("added - " + name);
}

void CommandDelete()
{
    Console.WriteLine("Name:");
    var name = Console.ReadLine();

    var meeting = service.Get(name);
    service.Delete(meeting);
}

void CommandAddToMeeting()
{
    Console.WriteLine("Meeting Name:");
    var name = Console.ReadLine();

    Console.WriteLine("Person:");
    var person = Console.ReadLine();

    Console.WriteLine("Time:");
    var time = DateTime.Parse(Console.ReadLine());

    var meeting = service.Get(name);
    service.AddPersonToMeeting(name, person, time);
}

void CommandRemoveFromMeeting()
{
    Console.WriteLine("Meeting Name:");
    var name = Console.ReadLine();

    Console.WriteLine("Person:");
    var person = Console.ReadLine();

    service.RemovePersonFromMeeting(name, person);
}

void CommandListFilter()
{
    Console.WriteLine("1 - List All");
    Console.WriteLine("- Filtering - ");
    Console.WriteLine("2 - by desc");
    Console.WriteLine("3 - by responsible person");
    Console.WriteLine("4 - by Category");
    Console.WriteLine("5 - by Meeting Type");
    Console.WriteLine("6 - by Date");
    Console.WriteLine("7 - by Number of Atendees");

    var key = Console.ReadLine();

    if (key == "1") ListAllMeetings();

    if (key == "2") CommandFilterByDesc();

    if (key == "3") CommandFilterByResponsiblePerson();

    if (key == "4") CommandFilterByCategory();

    if (key == "5") CommandFilterByMeetingType();

    if (key == "6") CommandFilterByDate();

    if (key == "7") CommandFilterByAttendeesCount();
}

void ListAllMeetings()
{
    var allMeetings = service.GetAll();

    PrintAllMeetings(allMeetings);
}

void CommandFilterByDesc()
{
    Console.WriteLine("Enter desc:");

    var desc = Console.ReadLine();
    var allMeetings = service.GetAll();

    var filter = new FiltererByDescription(desc);

    var results = filter.ApplyFilter(allMeetings);

    PrintAllMeetings(results);
}

void CommandFilterByResponsiblePerson()
{
    Console.WriteLine("Enter responsible person:");
    var respPerson = Console.ReadLine();
    var allMeetings = service.GetAll();

    var filter = new FiltererByResponsiblePerson(respPerson);

    var results = filter.ApplyFilter(allMeetings);

    PrintAllMeetings(results);
}

void CommandFilterByCategory()
{
    Console.WriteLine("Enter responsible person:");

    var inputCategory = (Category)int.Parse(Console.ReadLine());
    var allMeetings = service.GetAll();

    var filter = new FiltererByCategory(inputCategory);

    var results = filter.ApplyFilter(allMeetings);

    PrintAllMeetings(results);
}

void CommandFilterByMeetingType()
{
    Console.WriteLine("Enter meeting type:");

    var inputMeetingType = (MeetingType)int.Parse(Console.ReadLine());
    var allMeetings = service.GetAll();

    var filter = new FiltererByType(inputMeetingType);

    var results = filter.ApplyFilter(allMeetings);

    PrintAllMeetings(results);
}

void CommandFilterByDate()
{
    Console.WriteLine("1 - StartDate");
    Console.WriteLine("2 - StartDate and EndDate");

    var inputKey = Console.ReadLine();
    if (inputKey == "1")
    {
        Console.WriteLine("Enter startDate:");
        var inputStartdate = DateTime.Parse(Console.ReadLine());

        var allMeetings = service.GetAll();

        var filter = new FiltererByDates(inputStartdate);
        var results = filter.ApplyFilter(allMeetings);

        PrintAllMeetings(results);
    }
    else if (inputKey == "2")
    {
        Console.WriteLine("Enter startDate:");
        var inputStartdate = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Enter endDate:");
        var inputEnddate = DateTime.Parse(Console.ReadLine());
        var allMeetings = service.GetAll();

        var filter = new FiltererByDates(inputStartdate, inputEnddate);
        var results = filter.ApplyFilter(allMeetings);

        PrintAllMeetings(results);
    }
}

void CommandFilterByAttendeesCount()
{
    Console.WriteLine("Enter count");
    var inputCount = int.Parse(Console.ReadLine());

    var allMeetings = service.GetAll();
    var filter = new FiltererByAtendeeCount(inputCount);

    var results = filter.ApplyFilter(allMeetings);

    PrintAllMeetings(results);
}


void PrintAllMeetings(List<Meeting> allMeetings)
{
    foreach (var meeting in allMeetings) Console.WriteLine(meeting);
}