using ITI.KDO.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITI.KDO.WebApp.Services
{
    public class EventServices
    {
        readonly EventGateway _eventGateway;

        public EventServices(EventGateway eventGateway)
        {
            _eventGateway = eventGateway;
        }

        public Result<IEnumerable<Event>> GetAllByUserId(int userId)
        {
            return Result.Success(Status.Ok, _eventGateway.GetAllByUserId(userId));
        }

        public Result<Event> GetById(int id)
        {
            Event events;
            if((events = _eventGateway.FindById(id))== null) return Result.Failure<Event>(Status.NotFound, "Event not found.");
            return Result.Success(Status.Ok, events);
        }

        public Result<int> Delete(int eventId)
        {
            if (_eventGateway.FindById(eventId) == null) return Result.Failure<int>(Status.NotFound, "Event not found.");
            _eventGateway.Delete(eventId);
            return Result.Success(Status.Ok, eventId);
        }

        public Result<Event> UpdateEvent(int eventId, int userId, string eventName, string descriptions, DateTime dates)
        {
            if (!IsNameValid(eventName)) return Result.Failure<Event>(Status.BadRequest, "The event's name is not valid.");
            Event events;
            if ((events = _eventGateway.FindById(eventId)) == null)
            {
                return Result.Failure<Event>(Status.NotFound, "Event not found.");
            }

            {
                Event p = _eventGateway.FindByName(eventName);
                if (p != null && p.EventId == eventId) return Result.Failure<Event>(Status.BadRequest, "A Event with this name already exists.");
            }
            _eventGateway.Update(eventId, eventName, descriptions,dates, userId);
            events = _eventGateway.FindByEventId(eventId);
            return Result.Success(Status.Ok, events);
        }
        public Result<Event> CreateEvent(int userId, string eventName, string descriptions, DateTime dates)
        {
            if (!IsNameValid(eventName)) return Result.Failure<Event>(Status.BadRequest, "The event's name is not valid.");
            _eventGateway.Create(eventName, descriptions, dates, userId);
            Event events = _eventGateway.FindByName(eventName);
            return Result.Success(Status.Ok, events);
        }

        bool IsNameValid(string name) => !string.IsNullOrWhiteSpace(name);

    }
}
