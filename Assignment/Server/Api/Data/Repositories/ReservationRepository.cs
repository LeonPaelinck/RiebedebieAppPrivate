﻿using Microsoft.EntityFrameworkCore;
using RiebedebieApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiebedebieApi.Data.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly DbSet<Reservation> _reservations;
        public IEnumerable<Reservation> GetAll(int childId)
        {
            return _reservations.Where(res => res.Child.Id == childId).ToList();
        }

        public Reservation GetBy(int id)
        {
            return _reservations.Where(res => res.Id == id).FirstOrDefault();
        }
    }
}
