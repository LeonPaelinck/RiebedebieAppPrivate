using Microsoft.AspNetCore.Mvc;
using RiebedebieApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace RiebedebieApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KinderenController : ControllerBase
    {
        private readonly IKindRepository _kindRepository;
        public KinderenController(IKindRepository context)
        {
            _kindRepository = context;
        }

        // GET: api/Kinderen
        [HttpGet]
        public IEnumerable<Kind> GetKinderen()
        {
            return _kindRepository.GetAll().OrderBy(k => k.LastName);
        }

        // GET: api/Kind/1
        [HttpGet("{id}")]
        public ActionResult<Kind> GetKind(int id)
        {
            Kind kind = _kindRepository.GetBy(id);
            if (kind is null)
                return NotFound(); //404
            return Ok(kind); //200
        }

        // POST: api/Kind
        [HttpPost]
        public ActionResult<Kind> PostKind(Kind kind)
        {
            _kindRepository.Add(kind);
            _kindRepository.SaveChanges();
            return CreatedAtAction(nameof(GetKind),
                new { id = kind.Id }, kind); //201
        }

        // PUT: api/Kind/1
        [HttpPut("{id}")]
        public ActionResult PutKind(int id, Kind kind)
        {
            if (id != kind.Id)
                return BadRequest(); //400
            _kindRepository.Update(kind);
            _kindRepository.SaveChanges();
            return NoContent(); //204 (geen nieuws is goed nieuws)
        }

        // DELETE: api/Kind/1
        [HttpDelete("{id}")]
        public ActionResult DeleteKind(int id)
        {
            Kind kind = _kindRepository.GetBy(id);
            if (kind is null)
                return NotFound(); //404
            _kindRepository.Delete(kind);
            _kindRepository.SaveChanges();
            return NoContent(); //204 (geen nieuws is goed nieuws)
        }



    }
}
