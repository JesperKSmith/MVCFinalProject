using System;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinalExamProject.Repositories;
using Moq;
using FinalExamProject.Controllers;
using FinalExamProject.Models;

namespace FinalExamProject.Tests.Controllers
{
    [TestClass]
    public class LampControllerTest
    {
        private Mock<ILampRepository> MockLampRepo;
        private Mock<IImageRepository> MockImageRepo;
        private LampsController LampController;

        [TestMethod]
        public void LampIndexViewNotNull()
        {
            // Arrange
            MockImageRepo = new Mock<IImageRepository>();
            MockLampRepo = new Mock<ILampRepository>();
            LampController = new LampsController(MockLampRepo.Object, MockImageRepo.Object);

            // Act
            ViewResult result = LampController.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void InsertOrUpdate()
        {
            //Arrange
            MockImageRepo = new Mock<IImageRepository>();
            MockLampRepo = new Mock<ILampRepository>();
            var controllerLamp = new LampsController(MockLampRepo.Object, MockImageRepo.Object);
            var controllerImage = new ImagesController(MockImageRepo.Object);
            var image = new Image
            {
                ImageName = "good image",
                ImageExtension = ".jpg"
            };
            var lamp = new Lamp
            {
                LampName = "meh lamp",
                Author = "meh author",
                ImageId = 1,
                Likes = 420
            };
            //Act
            controllerLamp.Create(lamp);
            //Assert
            MockLampRepo.Verify(m => m.InsertOrUpdate(lamp));
        }
    }
}
