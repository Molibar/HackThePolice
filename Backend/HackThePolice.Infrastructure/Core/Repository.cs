using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ExpressMapper;
using HackThePolice.Infrastructure.Core.Models;

namespace HackThePolice.Infrastructure.Core
{
    public class Repository
    {
        public IQueryable<Incident> GetGreedyQueryable(IQueryable<Incident> queryable)
        {
            return queryable
                .Include(x => x.Statements.Select(y => y.Circumstance))
                .Include(x => x.Statements.Select(y => y.ContactDetails))
                .Include(x => x.Statements.Select(y => y.PeoplePresent))
                .Include(x => x.Statements.Select(y => y.Suspects))
                .Include(x => x.Statements.Select(y => y.Vehicles));
        }

        public IQueryable<Statement> GetGreedyQueryable(IQueryable<Statement> queryable)
        {
            return queryable
                .Include(x => x.Circumstance)
                .Include(x => x.ContactDetails)
                .Include(x => x.PeoplePresent)
                .Include(x => x.Suspects)
                .Include(x => x.Vehicles);
        }

        public Statement GetStatement(Guid id)
        {
            using (var context = new IncidentContext())
            {
                return GetGreedyQueryable(context.Statements).FirstOrDefault(x => x.Id == id);
            }
        }

        public List<Incident> GetAllIncidents()
        {
            using (var context = new IncidentContext())
            {
                return GetGreedyQueryable(context.Incidents).ToList();
            }
        }

        public Incident GetIncident(Guid incidentId)
        {
            using (var context = new IncidentContext())
            {
                return GetGreedyQueryable(context.Incidents).FirstOrDefault(x => x.Id == incidentId);
            }
        }

        public Guid Upsert(Statement statement)
        {
            if (!statement.Id.HasValue)
            {
                statement.Id = Guid.NewGuid();
                using (var context = new IncidentContext())
                {
                    statement.Circumstance.Id = Guid.NewGuid();
                    statement.ContactDetails.Id = Guid.NewGuid();
                    statement.PeoplePresent.ForEach(x => x.Id = Guid.NewGuid());
                    statement.Vehicles.ForEach(x => x.Id = Guid.NewGuid());
                    statement.Suspects.ForEach(x => x.Id = Guid.NewGuid());
                    context.Statements.Add(statement);
                    context.SaveChanges();
                }
            }
            else
            {
                using (var context = new IncidentContext())
                {
                    var loadedStatement = context.Statements.Find(statement.Id);
                    Mapper.Map(statement, loadedStatement);
                    context.SaveChanges();
                }
            }
            return statement.Id.Value;
        }

        public Guid Upsert(Incident incident)
        {
            if (!incident.Id.HasValue)
            {
                incident.Id = Guid.NewGuid();
                using (var context = new IncidentContext())
                {
                    context.Incidents.Add(incident);
                    context.SaveChanges();
                }
            }
            else
            {
                using (var context = new IncidentContext())
                {
                    var loadedIncident = context.Incidents.Find(incident.Id);
                    Mapper.Map(incident, loadedIncident);
                    context.SaveChanges();
                }
            }
            return incident.Id.Value;
        }
    }
}
