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
    public class WorksheetsController : ApiController
    {
        private IRepository<Worksheet> _dm = new DllFacade().GetWorksheetRepository();

        // GET: api/Worksheets
        public List<Worksheet> GetWorksheet()
        {
            return _dm.Read();
        }

        // GET: api/Worksheets/5
        [ResponseType(typeof(Worksheet))]
        public IHttpActionResult GetWorksheet(int id)
        {
            Worksheet worksheet = _dm.Read(id);
            if (worksheet == null)
            {
                return NotFound();
            }

            return Ok(worksheet);
        }

        // PUT: api/Worksheets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWorksheet(int id, Worksheet worksheet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != worksheet.Id)
            {
                return BadRequest();
            }

            try
            {
                _dm.Update(worksheet);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorksheetExists(id))
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

        // POST: api/Worksheets
        [ResponseType(typeof(Worksheet))]
        public IHttpActionResult PostWorksheet(Worksheet worksheet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dm.Create(worksheet);

            try
            {
                _dm.Update(worksheet);
            }
            catch (DbUpdateException)
            {
                if (WorksheetExists(worksheet.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = worksheet.Id }, worksheet);
        }
        /// <summary>
        /// Deletes specified worksheet (Requires id)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/Worksheets/5
        [ResponseType(typeof(Worksheet))]
        public IHttpActionResult DeleteWorksheet(int id)
        {
            Worksheet worksheet = _dm.Read(id);
            if (worksheet == null)
            {
                return NotFound();
            }

            _dm.Delete(worksheet.Id);

            return Ok(worksheet);
        }

        private bool WorksheetExists(int id)
        {
            return _dm.Read().Count(e => e.Id == id) > 0;
        }
    }
}