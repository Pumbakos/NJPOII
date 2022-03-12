using System;
using System.Collections.Generic;
using FluentNHibernate.Mapping;

namespace ORMMapping.Zadanie1
{
    public class Event
    {
        public string Id { get; protected set; }
        public DateTime EventOccurenceDateTime { get; set; }
        public string EventSource { get; set; }
        public List<string> AdditionalData { get; set; }
        public EventType EventType { get; set; }
    }

    public enum EventType
    {
        Information,
        Warning,
        Error,
        Critical
    }

    public class EventMap : ClassMap<Event>
    {
        public EventMap()
        {
            Table("Event");
            Id(x => x.Id);
            Map(x => x.EventOccurenceDateTime);
            Map(x => x.EventSource);
            Map(x => x.AdditionalData);
            Map(x => x.EventType).CustomType<EventType>();
        }
    }

    public class EventTypeService
    {
        public void AddEvent(Event newEvent)
        {
            var sessionFactory = Config.CreateSessionFactory(typeof(EventMap));
            using var session = sessionFactory.OpenSession();
            using var transaction = session.BeginTransaction();
            {
                var eventById = GetEventById(newEvent.Id);
                if (eventById != null) return;
                session.Save(newEvent);
                transaction.Commit();
            }
        }
        
        public Event GetEventById(string id){
            var sessionFactory = Config.CreateSessionFactory(typeof(EventMap));
            using var session = sessionFactory.OpenSession();
            {
                return (Event) session.Get(typeof(Event), id);
            }
        }

        public void UpdateEvent(Event newEventData)
        {
            var sessionFactory = Config.CreateSessionFactory(typeof(EventMap));
            using var session = sessionFactory.OpenSession();
            using var transaction = session.BeginTransaction();
            {
                session.SaveOrUpdate(newEventData);
                transaction.Commit();
            }
        }

        public void DeleteEventById(string id)
        {
            var sessionFactory = Config.CreateSessionFactory(typeof(EventMap));
            using var session = sessionFactory.OpenSession();
            using var transaction = session.BeginTransaction();
            {
                var eventById = GetEventById(id);
                session.Delete(eventById);
                transaction.Commit();
            }
        }
    }
}