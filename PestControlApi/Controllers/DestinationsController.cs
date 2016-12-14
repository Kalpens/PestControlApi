using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PestControlDll.Context;
using PestControlDll.Entities;
using PestControlDll;

namespace PestControlApi.Controllers
{
    [Authorize]
    public class DestinationsController : ApiController
    {
        
        private IRepository<Destination> _dm = new DALFacade().GetDestinationRepository();

        // GET: api/Destinations
        public List<Destination> GetDestination()
        {
            return _dm.Read();
        }

        // GET: api/Destinations/5
        [ResponseType(typeof(Destination))]
        public IHttpActionResult GetDestination(int id)
        {
            Destination destination = _dm.Read(id);
            if (destination == null)
            {
                return NotFound();
            }

            return Ok(destination);
        }

        // PUT: api/Destinations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDestination(int id, Destination destination)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != destination.Id)
            {
                return BadRequest();
            }
            try
            {
                _dm.Update(destination);
            }
            
            catch (DbUpdateConcurrencyException)
            {
                if (!DestinationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Destinations
        [ResponseType(typeof(Destination))]
        public IHttpActionResult PostDestination(Destination destination)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dm.Create(destination);

            return CreatedAtRoute("DefaultApi", new { id = destination.Id }, destination);
        }

        // DELETE: api/Destinations/5
        [ResponseType(typeof(Destination))]
        public IHttpActionResult DeleteDestination(int id)
        {
            Destination destination = _dm.Read(id);
            if (destination == null)
            {
                return NotFound();
            }

            _dm.Delete(destination.Id);

            return Ok(destination);
        }

        private bool DestinationExists(int id)
        {
            return _dm.Read().Count(e => e.Id == id) > 0;
        }
    }
}