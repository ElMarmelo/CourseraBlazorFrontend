using UdemyEventEase.Interfaces;

namespace UdemyEventEase.Models;

public class EventModel: IEventInterface
{
    public string EventTitle { get; set; } = "Title hasn't been defined";
    public DateTime EventDate { get; set; }
    public string Location { get; set; } = string.Empty;
    public int EventId { get; set; }
    public List<string> Attendees { get; set; } = [];
}   