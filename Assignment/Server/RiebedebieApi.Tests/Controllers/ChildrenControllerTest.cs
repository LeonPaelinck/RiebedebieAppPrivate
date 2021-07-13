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

        private readonly Mock<UserManager<IdentityUser>> _mockUserManager;

        public ChildrenControllerTest()
        {
            _dbContext = new DummyApplicationDbContext();
            //create mocks
            _mockChildRepo = new Mock<IChildRepository>();
            _mockParentRepo = new Mock<IParentRepository>();
            //inject mocks
            _childrenController = new ChildrenController(_mockChildRepo.Object, _mockParentRepo.Object);
        }

        #region == Create Methodes ==
        [Fact]
        public void PostChildSuccessful()
        {
            //Mock
            _mockParentRepo.Setup(m => m.GetBy(It.IsNotNull<string>())).Returns(_dbContext.Parent1);
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
        #endregion
    }
}