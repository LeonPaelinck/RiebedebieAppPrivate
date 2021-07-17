using RiebedebieApi.Models;
using System;
using Xunit;

namespace RiebedebieApi.Tests.Models
{
    public class ChildTest
    {
        public static string voornaam = "leon";
        public static string familienaam = "paelinck";

        [Fact]
        public void NieuwChild_CorrectChild_MaaktChild()
        {
            //Arrange
            DateTime geboortedatum = DateTime.Today.AddYears(-10);
            //Act
            Child c = new Child(familienaam, voornaam, geboortedatum);
            //Assert
            Assert.Equal(voornaam, c.FirstName);
            Assert.Equal(familienaam, c.LastName);
            Assert.Equal(geboortedatum, c.BirthDate);
            Assert.Equal(AgeCategory.Child, c.AgeCategory); //zou zelf meoten berekenene 
        }

        [Fact]
        public void NieuwChild_IncorrectChild_MaakGeentChild()
        {
            //Arrange
            DateTime toekomst = DateTime.Today.AddYears(10);
            //Act
            //Assert
            Assert.Throws<ArgumentException>(() => new Child(familienaam, voornaam, toekomst));
        }
    }
}
