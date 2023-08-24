Some random task I found online


# Due to the 2-4hr time limitation. Code is limited.


- What I would have done if there was more time
    - Added null/empty checks and written such things to user.
    - Wrote more tests
    - Single responsibility for methods in Program.cs, MeetingService.cs (moved helper methods from here first of all)
    - Could have used Command Pattern for the commands, alghouh that would take alot of time probably.
    - Interfaces, abstract classes if there was a requirement for modification etc.




# Internship 2022 - .NET Developer Task

## Create a console application to manage Company internal meetings using .NET6.

### Requirements:

- Command to create a new meeting. All the meeting data should be stored in a JSON file. Application should retain data between restarts. Meeting model should contain the following properties:
  - Name
  - ResponsiblePerson
  - Description
  - Category (Fixed values - CodeMonkey / Hub / Short / TeamBuilding)
  - Type (Fixed values - Live / InPerson)
  - StartDate
  - EndDate

- Command to delete a meeting. Only the person responsible can delete the meeting.

- Command to add a person to the meeting.
  - Command should specify who is being added and at what time.
  - If a person is already in a meeting which intersects with the one being added, a warning message should be given.
  - Prevent the same person from being added twice.

- Command to remove a person from the meeting.
  - If a person is responsible for the meeting, he cannot be removed.

- Command to list all the meetings. Add the following parameters to filter the data:
  - Filter by description (if the description is “Jono .NET meetas”, searching for .NET should return this entry)
  - Filter by responsible person
  - Filter by category
  - Filter by type
  - Filter by dates (e.g meetings that will happen starting from 2022-01-01 / meetings that will happen between 2022-01-01 and 2022-02-01)
  - Filter by the number of attendees (e.g show meetings that have over 10 people attending)

- Focus on good code design and good practices, UI design should be minimalistic and simple. Besides the completion of functional requirements, we require: OOP design, unit tests and code should adhere to C# / .NET coding conventions.

- Push your code to Git (e.g. GitHub, GitLab, Bitbucket) repository and share the link with us.

Good luck!

## FAQ

**Q:** Can I use a database?
**A:** No. At this stage file storage is enough.

**Q:** Can this application be a Windows form application or a WPF application?
**A:** No. We are geeks and like using the terminal.

**Q:** Can I develop a web application?
**A:** Still no.

**Q:** How long should it take?
**A:** 2 to 4 hours. Do not spend more than that.
