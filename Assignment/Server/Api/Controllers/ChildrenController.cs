using Microsoft.AspNetCore.Mvc;
using RiebedebieApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace RiebedebieApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChildrenController : ControllerBase
    {
        private readonly IChildRepository _childRepository;
        public ChildrenController(IChildRepository context)
        {
            _childRepository = context;
        }

        // GET: api/Children
        /// <summary>
        /// Get every child ordered by lastname and age
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Child> GetChildren()
        {
            return _childRepository.GetAll().OrderBy(k => k.LastName).ThenBy(c => c.BirthDate);
        }

        // GET: api/Child/1
        [HttpGet("{id}")]
        public ActionResult<Child> GetChild(int id)
        {
            Child child = _childRepository.GetBy(id);
            if (child is null)
                return NotFound(); //404
            return Ok(child); //200
        }

        // POST: api/Child
        [HttpPost]
        public ActionResult<Child> PostChild(Child child)
        {
            _childRepository.Add(child);
            _childRepository.SaveChanges();
            return CreatedAtAction(nameof(GetChild),
                new { id = child.Id }, child); //201
        }

        // PUT: api/Child/1
        [HttpPut("{id}")]
        public ActionResult PutChild(int id, Child child)
        {
            if (id != child.Id)
                return BadRequest(); //400
            _childRepository.Update(child);
            _childRepository.SaveChanges();
            return NoContent(); //204 (geen nieuws is goed nieuws)
        }

        // DELETE: api/Child/1
        [HttpDelete("{id}")]
        public ActionResult DeleteChild(int id)
        {
            Child child = _childRepository.GetBy(id);
            if (child is null)
                return NotFound(); //404
            _childRepository.Delete(child);
            _childRepository.SaveChanges();
            return NoContent(); //204 (geen nieuws is goed nieuws)
        }



    }
}
