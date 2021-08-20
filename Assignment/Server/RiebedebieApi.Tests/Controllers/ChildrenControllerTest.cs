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
    public class ChildrenControllerTest
    {
        private readonly ChildrenController _childrenController;
        private readonly DummyApplicationDbContext _dbContext;

        private readonly Mock<IChildRepository> _mockChildRepo;
        private readonly Mock<IParentRepository> _mockParentRepo;

        private readonly Parent _parent1;

        public ChildrenControllerTest()
        {
            _dbContext = new DummyApplicationDbContext();
            //create mocks
            _mockChildRepo = new Mock<IChildRepository>();
            _mockParentRepo = new Mock<IParentRepository>();

            var context = MockContext();

            //inject mocks
            _childrenController = new ChildrenController(_mockChildRepo.Object, _mockParentRepo.Object);
            _childrenController.ControllerContext = context;

            //fetch 
            _parent1 = _dbContext.Parent1;
        }

        #region == Create Methodes ==
        [Fact]
        public void PostChildSuccessful()
        {
            //Mock
            _mockParentRepo.Setup(m => m.GetBy(It.IsNotNull<string>())).Returns(_parent1);
            //Arrange
            ChildDTO childDTO = new ChildDTO();
            childDTO.BirthDate = _dbContext.Kind.BirthDate.ToString();
            childDTO.FirstName = _dbContext.Kind.FirstName;
            childDTO.LastName = _dbContext.Kind.LastName;
            //Act
            var result = Assert.IsType<ActionResult<Child>>(_childrenController.PostChild(childDTO));
            //Assert
            Child child = result.Value;
            //Verify
            _mockChildRepo.Verify(m => m.Add(It.IsNotNull<Child>()), Times.Once);
            _mockParentRepo.Verify(m => m.GetBy(It.IsNotNull<string>()), Times.Once);
            _mockChildRepo.Verify(m => m.SaveChanges(), Times.Once);

        }

        
        [Fact]
        public void PostChildUnSuccessful()
        {
            //Mock
            _mockParentRepo.Setup(m => m.GetBy(It.IsNotNull<string>())).Returns(_parent1);
            //Arrange
            int numberOfChildren = _parent1.Children.Count();
            ChildDTO childDTO = new ChildDTO
            {
                BirthDate = DateTime.Now.AddYears(20).ToString(), //illegal value (future)
                FirstName = _dbContext.Kind.FirstName,
                LastName = _dbContext.Kind.LastName
            };
            //Act
            _childrenController.PostChild(childDTO);
            //Assert
            Assert.Equal(numberOfChildren, _parent1.Children.Count());
            //Verify
            _mockChildRepo.Verify(m => m.Add(It.IsNotNull<Child>()), Times.Never);
            _mockParentRepo.Verify(m => m.GetBy(It.IsNotNull<string>()), Times.Never);
            _mockChildRepo.Verify(m => m.SaveChanges(), Times.Never);


        }

        #endregion

        #region == Update Methodes ==
        [Fact]
        public void PutChildSuccessful()
        {
            //Arrange
            Child child = _dbContext.Kleuter;
            //Act/Assert
            var result = Assert.IsType<NoContentResult>(_childrenController.PutChild(child.Id, child));
            //Verify
            _mockChildRepo.Verify(m => m.Update(It.IsNotNull<Child>()), Times.Once);
            _mockChildRepo.Verify(m => m.SaveChanges(), Times.Once);

        }

        [Fact]
        public void PutChildUnSuccessful()
        {
            //Arrange
            Child child = _dbContext.Kleuter;
            child.Id = 1;
            int foutiefID = 2;
            //Act/Assert
            var result = Assert.IsType<BadRequestResult>(_childrenController.PutChild(foutiefID, child));

        }
        #endregion

        #region == Delete methods ===
        [Fact]
        public void DeleteChildSuccessful()
        {
            Child kind = _dbContext.Kind;
            _parent1.AddChild(kind);
            //Mock
            _mockChildRepo.Setup(m => m.GetBy(It.IsNotNull<int>())).Returns(kind);
            _mockParentRepo.Setup(m => m.GetBy(It.IsNotNull<string>())).Returns(_parent1);
            //Arrange
            int id = kind.Id;
            //Act
            var result = Assert.IsType<NoContentResult>(_childrenController.DeleteChild(id));
            //Assert
            Assert.False(_parent1.Children.Contains(kind)); //moet uiteraard verwijderd zijn
            //Verify
            _mockChildRepo.Verify(m => m.GetBy(It.IsNotNull<int>()), Times.Once);
            _mockParentRepo.Verify(m => m.GetBy(It.IsNotNull<string>()), Times.Once);
            _mockChildRepo.Verify(m => m.SaveChanges(), Times.Once);

        }

        [Fact]
        public void DeletChildParentDoesNotContainUnsusscesful()
        {
            Child kind = _dbContext.Kind;
            //Mock
            _mockChildRepo.Setup(m => m.GetBy(It.IsNotNull<int>())).Returns(kind);
            _mockParentRepo.Setup(m => m.GetBy(It.IsNotNull<string>())).Returns(_parent1);
            //Arrange
            int id = kind.Id;
            //Act Assert
            var result = Assert.IsType<BadRequestResult>(_childrenController.DeleteChild(id));
           //Verify
            _mockChildRepo.Verify(m => m.GetBy(It.IsNotNull<int>()), Times.Once);
            _mockParentRepo.Verify(m => m.GetBy(It.IsNotNull<string>()), Times.Once);
        }

        [Fact]
        public void DeletNonExistingChildUnsusscesful()
        {
            Child kind = _dbContext.Kind;
            //Mock
            _mockParentRepo.Setup(m => m.GetBy(It.IsNotNull<string>())).Returns(_parent1);
            //Arrange
            int id = kind.Id;
            //Act-Assert
            var result = Assert.IsType<NotFoundResult>(_childrenController.DeleteChild(id));
            //Verify
            _mockChildRepo.Verify(m => m.GetBy(It.IsNotNull<int>()), Times.Once);
            _mockParentRepo.Verify(m => m.GetBy(It.IsNotNull<string>()), Times.Once);
        }
        #endregion

        #region == Mock help methods ==

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
        #endregion
    }
}