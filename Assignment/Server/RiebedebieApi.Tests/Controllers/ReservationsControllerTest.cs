using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RecipeApi.DTOs;
using RiebedebieApi.Controllers;
using RiebedebieApi.Models;
using RiebedebieApi.Tests.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace RiebedebieApi.Tests.Models
{
    public class ReservationsControllerTest
    {
        private readonly ReservationsController _reservationController;
        private readonly DummyApplicationDbContext _dbContext;

        private readonly Mock<IChildRepository> _mockChildRepo;
        private readonly Mock<IParentRepository> _mockParentRepo;
        private readonly Mock<IRiebedebieRepository> _mockRiebedebieRepo;
        private readonly Mock<IReservationRepository> _mockReservationRepo;


        private readonly Parent _parent1;

        public ReservationsControllerTest()
        {
            _dbContext = new DummyApplicationDbContext();
            //create mocks
            _mockChildRepo = new Mock<IChildRepository>();
            _mockParentRepo = new Mock<IParentRepository>();
            _mockRiebedebieRepo = new Mock<IRiebedebieRepository>();
            _mockReservationRepo = new Mock<IReservationRepository>();

            var context = MockContext();

            //inject mocks
            _reservationController = new ReservationsController(_mockRiebedebieRepo.Object, _mockReservationRepo.Object, _mockChildRepo.Object, _mockParentRepo.Object);
            _reservationController.ControllerContext = context;

            //fetch 
            _parent1 = _dbContext.Parent1;
        }

        [Fact]
        public void PostReservationSuccessful()
        {
            Child kind = _dbContext.Kind;
            //Mock
            _mockParentRepo.Setup(m => m.GetBy(It.IsNotNull<string>())).Returns(_parent1);
            _mockChildRepo.Setup(m => m.GetBy(It.IsNotNull<int>())).Returns(kind);
            _mockRiebedebieRepo.Setup(m => m.GetAll()).Returns(new List<Riebedebie> { _dbContext.Kinderwerking });
            //Arrange
            _parent1.AddChild(kind);
            DateTime tomorrow = DateTime.Today.AddDays(1);
            ReservationDTO res = new ReservationDTO()
            {
                Date = DateTime.Today.AddDays(1).ToString(),
                Earlier = "false",
                Later = "false"
            };
            //Act
            var result = Assert.IsType<ActionResult<Reservation>>(_reservationController.PostReservation(kind.Id, res));
            //Assert
            Reservation reservation = _parent1.Reservations.Last();
            Assert.Equal(tomorrow, reservation.Date);
            Assert.Equal(false, reservation.Earlier);
            Assert.Equal(false, reservation.Later);

            //Verify
            _mockParentRepo.Verify(m => m.GetBy(It.IsNotNull<string>()), Times.Once);
            _mockChildRepo.Verify(m => m.GetBy(It.IsNotNull<int>()), Times.Once);
            _mockParentRepo.Verify(m => m.SaveChanges(), Times.Once);
            _mockRiebedebieRepo.Verify(m => m.GetAll(), Times.Once);
            _mockRiebedebieRepo.Verify(m => m.SaveChanges(), Times.Once);


        }

        private static ControllerContext MockContext()
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "John Doe"),
                new Claim(ClaimTypes.NameIdentifier, "1"),
                new Claim("name", "John Doe"),
            };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var claimsPrincipal = new ClaimsPrincipal(identity);

            var mockPrincipal = new Mock<IPrincipal>();
            mockPrincipal.Setup(x => x.Identity).Returns(identity);
            mockPrincipal.Setup(x => x.IsInRole(It.IsAny<string>())).Returns(true);

            var mockHttpContext = new Mock<HttpContext>();
            mockHttpContext.Setup(m => m.User).Returns(claimsPrincipal);

            var context = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = claimsPrincipal
                }
            };
            return context;
        } 

    }
}