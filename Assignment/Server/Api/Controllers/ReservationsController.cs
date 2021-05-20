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
        private readonly IReservationRepository _reservationRepository;
        private readonly IChildRepository _childRepository;

        public ReservationsController(IRiebedebieRepository context, IReservationRepository reservationRepository, IChildRepository childrenRepos)
        {
            _riebedebieRepository = context;
            _reservationRepository = reservationRepository;
            _childRepository = childrenRepos;
        }

        // GET: api/Reservations/5
        /// <summary>
        /// Get the reservation with given id
        /// </summary>
        /// <param name="id">the id of the reservation</param>
        /// <returns>The reservation</returns>
        [HttpGet("{id}")]
        public ActionResult<Reservation> GetReservation(int id)
        {
            Reservation reservation = _reservationRepository.GetBy(id);
            if (reservation == null) return NotFound();
            return reservation;
        }

        // GET: api/Reservations/1
        /// <summary>
        /// Get every reservation from a child
        /// </summary>
        /// <param name="childId">The child's id</param>
        /// <returns>A list of all reservations from that child</returns>
        [HttpGet("{childId}/reservations")]
        public IEnumerable<Reservation> GetReservations(int childId)
        {
            return _reservationRepository.GetAll(childId).ToList();
        }

        // POST: api/Reservation
        /// <summary>
        /// Creates and persists a new reservation
        /// </summary>
        /// <param name="childId">The id of the child that to be registered</param>
        /// <param name="reservation">The info needed for the added reservation</param>
        /// <returns>The added Child</returns>
        [HttpPost]
        public ActionResult<Reservation> PostReservation(int childId, ReservationDTO reservation)
        {
            try
            {
                Child child = _childRepository.GetBy(childId);
                Riebedebie rieb = _riebedebieRepository.getAll().FirstOrDefault(r => r.AgeCategory == child.AgeCategory);
                Reservation res = rieb.Register(child, DateTime.Parse(reservation.Date), Convert.ToBoolean(reservation.Earlier), Convert.ToBoolean(reservation.Later));
                _riebedebieRepository.SaveChanges();
                return CreatedAtAction(nameof(GetReservation), new { id = res.Id }, res);

            } catch (ArgumentException e)
            {
                return BadRequest(e);
            }
        }
           

    }
}
