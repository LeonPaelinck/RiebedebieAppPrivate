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
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IRiebedebieRepository _riebedebieRepository;
        private readonly IChildRepository _childRepository;

        public ReservationsController(IRiebedebieRepository context, IChildRepository childrenRepos)
        {
            _riebedebieRepository = context;
            _childRepository = childrenRepos;
        }

        // GET: api/Reservations/1/1
        /// <summary>
        /// Get every reservation from a child
        /// </summary>
        /// <param name="riebedebieId">The riebedebie's id</param>
        /// <param name="childId">The child's id</param>
        /// <returns>A list of all reservations from that child</returns>
        [HttpGet]
        public IEnumerable<Reservation> GetReservationsBy(int childId, int riebedebieId)
        {
            return _riebedebieRepository.getBy(riebedebieId).Reservations.Where(res => res.Child.Id == childId);
        }

        // POST: api/Reservation
        /// <summary>
        /// Creates and persists a new reservation
        /// </summary>
        /// <param name="riebedebieId">The id of the riebedebier</param>
        /// <param name="childId">The id of the child that to be registered</param>
        /// <param name="reservation">The info needed for the added reservation</param>
        /// <returns>The added Child</returns>
        [HttpPost]
        public ActionResult<Reservation> PostReservation(int riebedebieId, int childId, ReservationDTO reservation)
        {
            Riebedebie rieb = _riebedebieRepository.getBy(riebedebieId);
            try
            {
                Child child = null;// _childRepository.GetBy(childId);
                Reservation res = rieb.Register(child, DateTime.Parse(reservation.Date), reservation.Earlier, reservation.Later);
                _riebedebieRepository.SaveChanges();
                return res;
                   
            } catch (ArgumentException e)
            {
                return BadRequest(e);
            }
        }
           

    }
}
