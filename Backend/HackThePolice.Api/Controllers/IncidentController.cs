using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using ExpressMapper.Extensions;
using HackThePolice.Api.Models;
using HackThePolice.Infrastructure.Core;
using HackThePolice.Infrastructure.Core.Models;

namespace HackThePolice.Api.Controllers
{
    public class IncidentController : ApiController
    {
        [ResponseType(typeof(List<IncidentModel>))]
        public IHttpActionResult Get()
        {
            try
            {
                Trace.TraceInformation("Hello!");
                var repository = new Repository();
                var incidents = repository.GetAllIncidents();
                return Ok(incidents.Select(x => x.Map<Incident, IncidentModel>()));
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                throw;
            }
        }

        [ResponseType(typeof(StatementModel))]
        public IHttpActionResult Get(Guid id)
        {
            var repository = new Repository();
            var statement = repository.GetIncident(id);
            return Ok(statement.Map<Incident, IncidentModel>());
        }

        [ResponseType(typeof(Guid))]
        public IHttpActionResult Post([FromBody] IncidentModel request)
        {
            var repository = new Repository();
            if (!request.OccurredAt.HasValue) request.OccurredAt = DateTime.UtcNow;
            var id = repository.Upsert(request.Map<IncidentModel, Incident>());
            return Ok(id);
        }

        public IHttpActionResult Put(Guid id, [FromBody] IncidentModel request)
        {
            var repository = new Repository();
            request.Id = id;
            repository.Upsert(request.Map<IncidentModel, Incident>());
            return Ok(id);
        }

        public IHttpActionResult Delete(Guid id)
        {
            return Ok();
        }
    }
}
