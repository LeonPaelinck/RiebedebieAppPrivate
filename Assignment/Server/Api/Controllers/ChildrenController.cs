using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeApi.DTOs;
using RiebedebieApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RiebedebieApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class ChildrenController : ControllerBase
    {
        private readonly IChildRepository _childRepository;
        private readonly IParentRepository _parentRepository;

        public ChildrenController(IChildRepository context, IParentRepository parentRepo)
        {
            _childRepository = context;
            _parentRepository = parentRepo;
        }

        // GET: api/Children
        /// <summary>
        /// Get every child 
        /// </summary>
        /// <returns>A list of all Children</returns>
        [HttpGet]
        public IEnumerable<Child> GetChildren()
        {
            Parent parent = _parentRepository.GetBy(User.Identity.Name);
            return parent.Children;
            //return _childRepository.GetAll();
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
            Parent parent = _parentRepository.GetBy(User.Identity.Name);
            if (!parent.Children.Contains(child))
                return BadRequest(); //andere ouder heeft hier niks over te zeggen
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
            try
            {
                Child childToCreate = new Child(child.LastName, child.FirstName, DateTime.Parse(child.BirthDate));
                _childRepository.Add(childToCreate);
                Parent parent = _parentRepository.GetBy(User.Identity.Name);
                parent.AddChild(childToCreate);
                _childRepository.SaveChanges();
                return CreatedAtAction(nameof(GetChild), new { id = childToCreate.Id }, childToCreate); //201
            }
            catch (Exception)
            {
                return BadRequest();
            }
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
            Parent parent = _parentRepository.GetBy(User.Identity.Name);

            if (!parent.Children.Contains(child))
                return BadRequest(); //andere ouder heeft hier niks over te zeggen

            if (child is null)
                return NotFound(); //404
            if (!parent.Children.Contains(child))
                return BadRequest(); //andere ouder heeft hier niks over te zeggen
            //_childRepository.Delete(child);
            parent.DeleteChild(child);
            _childRepository.SaveChanges();
            return NoContent(); //204 (geen nieuws is goed nieuws)
        }



    }
}
