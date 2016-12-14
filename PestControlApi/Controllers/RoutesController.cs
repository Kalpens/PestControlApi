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
using PestControlDll;
using PestControlDll.Context;
using PestControlDll.Entities;

namespace PestControlApi.Controllers
{
    [Authorize]
    public class RoutesController : ApiController
    {
        private IRepository<Route> _rm = new DALFacade().GetRouteRepository();

        // GET: api/Routes
        public List<Route> GetRoute()
        {
            return _rm.Read();
        }

        // GET: api/Routes/5
        [ResponseType(typeof(Route))]
        public IHttpActionResult GetRoute(int id)
        {
            Route route = _rm.Read(id);
            if (route == null)
            {
                return NotFound();
            }

            return Ok(route);
        }

        // PUT: api/Routes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRoute(int id, Route route)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != route.Id)
            {
                return BadRequest();
            }

            try
            {
                _rm.Update(route);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RouteExists(id))
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

        // POST: api/Routes
        [ResponseType(typeof(Route))]
        public IHttpActionResult PostRoute(Route route)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _rm.Create(route);

            return CreatedAtRoute("DefaultApi", new { id = route.Id }, route);
        }

        // DELETE: api/Routes/5
        [ResponseType(typeof(Route))]
        public IHttpActionResult DeleteRoute(int id)
        {
            Route route = _rm.Read(id);
            if (route == null)
            {
                return NotFound();
            }

            _rm.Delete(id);

            return Ok(route);
        }

        private bool RouteExists(int id)
        {
            return _rm.Read().Count(e => e.Id == id) > 0;
        }
    }
}