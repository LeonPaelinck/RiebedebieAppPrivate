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
        private readonly IParentRepository _parentRepository;

        public ReservationsController(IRiebedebieRepository context, IReservationRepository reservationRepository, IChildRepository childrenRepos, IParentRepository parentRepos)
        {
            _riebedebieRepository = context;
            _reservationRepository = reservationRepository;
            _childRepository = childrenRepos;
            _parentRepository = parentRepos;
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

        // GET: api/Reservations
        /// <summary>
        /// Get every reservation from current parent
        /// </summary>
        /// <returns>A list of all reservations from the current user (parent)</returns>
        [HttpGet("/reservations")]
        public IEnumerable<Reservation> GetReservations()
        {
            return _parentRepository.GetBy(User.Identity.Name).Reservations;
        }

        // POST: api/Reservation
        /// <summary>
        /// Creates and persists a new reservation
        /// </summary>
        /// <param name="reservation">The info needed for the added reservation</param>
        /// <returns>The added Child</returns>
        [HttpPost]
        public ActionResult<Reservation> PostReservation(ReservationDTO reservation)
        {
            try
            {
                DateTime date = DateTime.Parse(reservation.Date);
                Parent parent = _parentRepository.GetBy(User.Identity.Name);
                Child child = _childRepository.GetBy(reservation.ChildId);

                if (!parent.Children.Contains(child))
                    return BadRequest("You cannot add a reservation for another child");

                Riebedebie rieb = _riebedebieRepository.GetBy(1);//.GetAll().FirstOrDefault(r => r.AgeCategory.Equals(child.AgeCategory));
               
                Reservation res = rieb.Register(parent, child, date, Convert.ToBoolean(reservation.Earlier), Convert.ToBoolean(reservation.Later));
                _riebedebieRepository.SaveChanges();

                return CreatedAtAction(nameof(GetReservation), new { id = res.Id }, res);

            } catch (ArgumentException e)
            {
                return BadRequest(e);
            }
        }
           

    }
}
