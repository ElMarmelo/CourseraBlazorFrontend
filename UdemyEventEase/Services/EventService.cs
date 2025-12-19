using UdemyEventEase.Models;

namespace UdemyEventEase.Services;

public class EventService
{
    private readonly List<EventModel> _eventList = 
    [
        new EventModel { EventId = 1, EventTitle = "Rock Concert", Location = "Stadium", EventDate = DateTime.Now },
        new EventModel { EventId = 2, EventTitle = "Tech Talk", Location = "Zoom", EventDate = (DateTime.Now.AddDays(1)) },
        new EventModel { EventId = 3, EventDate = DateTime.MinValue}
    ];
    
    public List<EventModel> GetEvents()
    {
        return _eventList;
    }

    public EventModel? GetEventById(int id)
    {
        return GetEvents().FirstOrDefault(x => x.EventId == id);
    }

    public void RegisterAttendance(int eventId, string userName)
    {
        var eventItem = GetEventById(eventId);
        if (eventItem != null && !eventItem.Attendees.Contains(userName))
        {
            eventItem.Attendees.Add(userName);
        }
    }
}