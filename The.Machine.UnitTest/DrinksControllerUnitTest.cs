using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using The.Machine.Controllers;
using The.Machine.Entities;
using The.Machine.Models;
using The.Machine.Services;

namespace The.Machine.UnitTest
{
    [TestFixture]
    public class DrinksControllerUnitTest
    {
        private MockRepository _mockRepository;
        private Mock<IDrinkRepository> _drinksRepository;
        private Mock<IMapper> _mapper;
        private Mock<ILogger<DrinkDTO>> _logger;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository(MockBehavior.Strict);
            _drinksRepository = _mockRepository.Create<IDrinkRepository>();
            _logger = _mockRepository.Create<ILogger<DrinkDTO>>();
            _mapper = _mockRepository.Create<IMapper>();
        }

        [TearDown]
        public void TearDown()
        {
            _mockRepository.VerifyAll();
            ;
        }

        [Test]
        public void Given_When_GetAllDrinks_Then_Return_Exsisting_Drinks()
        {
            //Arrange
            IQueryable<Drink> dataBaseEntities = new List<Drink> { new Drink { Id = 2, Name = "Café", Description = "Pour se concentrer" } }.AsQueryable();
            IEnumerable<DrinkDTO> dtoEntities = new List<DrinkDTO> { new DrinkDTO { Id = 2, Name = "Café", Description = "Pour se concentrer" } };
            _drinksRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(dataBaseEntities);
            _mapper.Setup(x => x.Map<IEnumerable<DrinkDTO>>(dataBaseEntities)).Returns(dtoEntities);

            //Act
            DrinksController sut = new DrinksController(_logger.Object, _drinksRepository.Object, _mapper.Object);
            OkObjectResult result = sut.GetAllDrinks(string.Empty) as OkObjectResult;

            //Assert
            Assert.That(result.Value, Is.TypeOf(typeof(List<DrinkDTO>)));
            CollectionAssert.AreEqual((List<DrinkDTO>)result.Value, dtoEntities);
        }
    }
}
