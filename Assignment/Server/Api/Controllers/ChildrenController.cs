using Microsoft.AspNetCore.Mvc;
using RecipeApi.DTOs;
using RiebedebieApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace RiebedebieApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiConventionType(typeof(DefaultApiConventions))]
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
        /// <returns>A list of all Children</returns>
        [HttpGet]
        public IEnumerable<Child> GetChildren()
        {
            return _childRepository.GetAll().OrderBy(k => k.LastName).ThenBy(c => c.BirthDate);
        }

        // GET: api/Child/1
        /// <summary>
        /// Get one child by its id
        /// </summary>
        /// <param name="id">The unique id</param>
        /// <returns>One Child</returns>
        [HttpGet("{id}")]
        public ActionResult<Child> GetChild(int id)
        {
            Child child = _childRepository.GetBy(id);
            if (child is null)
                return NotFound(); //404
            return Ok(child); //200
        }

        // POST: api/Child
        /// <summary>
        /// Adds and persists a new Child
        /// </summary>
        /// <param name="child">The new Child</param>
        /// <returns>The added Child</returns>
        [HttpPost]
        public ActionResult<Child> PostChild(ChildDTO child)
        {
            Child childToCreate = new Child() { LastName = child.LastName, FirstName = child.FirstName, BirthDate = child.BirthDate };

            _childRepository.Add(childToCreate);
            _childRepository.SaveChanges();
            return CreatedAtAction(nameof(GetChild),
                new { id = childToCreate.Id }, childToCreate); //201
        }

        // PUT: api/Child/1
        /// <summary>
        /// Alter an existing child and persist the changes
        /// </summary>
        /// <param name="id">The unique id</param>
        /// <param name="child">The altered Child</param>
        /// <returns></returns>
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
        /// <summary>
        /// Deletes a Child
        /// </summary>
        /// <param name="id">The unique id</param>
        /// <returns></returns>
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
