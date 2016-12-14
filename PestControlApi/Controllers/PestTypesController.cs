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
    public class PestTypesController : ApiController
    {
        private IRepository<PestType> _dm = new DALFacade().GetPestTypeRepository();

        // GET: api/PestTypes
        public List<PestType> GetPestType()
        {
            return _dm.Read();
        }

        // GET: api/PestTypes/5
        [ResponseType(typeof(PestType))]
        public IHttpActionResult GetPestType(int id)
        {
            PestType pestType = _dm.Read(id);
            if (pestType == null)
            {
                return NotFound();
            }

            return Ok(pestType);
        }

        // PUT: api/PestTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPestType(int id, PestType pestType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pestType.Id)
            {
                return BadRequest();
            }

            try
            {
                _dm.Update(pestType);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PestTypeExists(id))
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

        // POST: api/PestTypes
        [ResponseType(typeof(PestType))]
        public IHttpActionResult PostPestType(PestType pestType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dm.Create(pestType);

            return CreatedAtRoute("DefaultApi", new { id = pestType.Id }, pestType);
        }

        // DELETE: api/PestTypes/5
        [ResponseType(typeof(PestType))]
        public IHttpActionResult DeletePestType(int id)
        {
            PestType pestType = _dm.Read(id);
            if (pestType == null)
            {
                return NotFound();
            }

            _dm.Delete(pestType.Id);

            return Ok(pestType);
        }

        private bool PestTypeExists(int id)
        {
            return _dm.Read().Count(e => e.Id == id) > 0;
        }
    }
}