using RiebedebieApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RiebedebieApi.Tests.Models
{
    public class ReservationTest
    {
        [Fact]
        public void NieuwReservation_CorrectReservation_MaaktReservation()
        {
            //Arrange
            Reservation r = new Reservation();
            decimal pricePerDay = 5;
            decimal afterHoursPrice = 1;
            decimal totalPrice = 6;
            //Act
            r.PricePerDay = pricePerDay;
            r.AfterHoursPrice = afterHoursPrice;
            r.Earlier = true;
            r.Later = false;
            //Assert
            Assert.Equal(totalPrice, r.Price);
        }

   
    }
}
