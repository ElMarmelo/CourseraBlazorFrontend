namespace UdemyEventEase.Interfaces;

public interface IEventInterface
{
    string EventTitle { get; set; }
    DateTime EventDate { get; set; }
    string Location { get; set; }
    int EventId { get; set; }
    List<string> Attendees { get; set; }
}