using System;
using System.Text;
using System.Collections.Generic;
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
        Mock<ILampRepository> mockLamp = new Mock<ILampRepository>();
        Mock<IImageRepository> mockImage = new Mock<IImageRepository>();

        [TestMethod]
        public void InsertOrUpdate()
        {
            //Arrange
            var controllerLamp = new LampsController(mockLamp.Object, mockImage.Object);
            var controllerImage = new ImagesController(mockImage.Object);
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
            mockLamp.Verify(m => m.InsertOrUpdate(lamp));
        }
    }
}
