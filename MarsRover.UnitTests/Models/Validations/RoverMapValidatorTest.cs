using MarsRover.Models;
using MarsRover.Models.Rover;
using MarsRover.Models.Rover.Imp;
using MarsRover.Models.Validations;
using NUnit.Framework;
using FluentValidation;
using FluentValidation.TestHelper;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover.UnitTests.Models.Validations
{
    [TestFixture]
    public class RoverMapValidatorTest
    {
        IPointModel upperRightPointModel;

        [SetUp]
        public void Setup()
        {
            upperRightPointModel = new UpperRightPointModel();
            upperRightPointModel.X = 10;
            upperRightPointModel.Y = 10;
        }

        [Test]
        public void Should_have_error_Rover_Outside_Map_Border_East()
        {
            RoverMapValidator roverMapValidator = new RoverMapValidator(upperRightPointModel);
            IRoverModel roverModel = new RectangleRoverModel();
            roverModel.X = upperRightPointModel.X + 1;
            roverModel.Y = 0;

            var validator = roverMapValidator.Validate(roverModel);
            Assert.AreEqual(false, validator.IsValid, validator.Errors.FirstOrDefault()?.ErrorMessage);
        }
        [Test]
        public void Should_have_error_Rover_Outside_Map_Border_West()
        {
            RoverMapValidator roverMapValidator = new RoverMapValidator(upperRightPointModel);
            IRoverModel roverModel = new RectangleRoverModel();
            roverModel.X = -1;
            roverModel.Y = 0;

            var validator = roverMapValidator.Validate(roverModel);
            Assert.AreEqual(false, validator.IsValid, validator.Errors.FirstOrDefault()?.ErrorMessage);
        }
        [Test]
        public void Should_have_error_Rover_Outside_Map_Border_South()
        {
            RoverMapValidator roverMapValidator = new RoverMapValidator(upperRightPointModel);
            IRoverModel roverModel = new RectangleRoverModel();
            roverModel.X = 0;
            roverModel.Y = -1;

            var validator = roverMapValidator.Validate(roverModel);
            Assert.AreEqual(false, validator.IsValid, validator.Errors.FirstOrDefault()?.ErrorMessage);
        }
        [Test]
        public void Should_have_error_Rover_Outside_Map_Border_North()
        {
            RoverMapValidator roverMapValidator = new RoverMapValidator(upperRightPointModel);
            IRoverModel roverModel = new RectangleRoverModel();
            roverModel.X = 0;
            roverModel.Y = upperRightPointModel.Y + 1;

            var validator = roverMapValidator.Validate(roverModel);
            Assert.AreEqual(false, validator.IsValid, validator.Errors.FirstOrDefault()?.ErrorMessage);
        }
        [Test]
        public void Should_have_error_Rover_Outside_Map_Border_Origin()
        {
            RoverMapValidator roverMapValidator = new RoverMapValidator(upperRightPointModel);
            IRoverModel roverModel = new RectangleRoverModel();
            roverModel.X = 0;
            roverModel.Y = 0;

            var validator = roverMapValidator.Validate(roverModel);
            Assert.AreEqual(true, validator.IsValid, validator.Errors.FirstOrDefault()?.ErrorMessage);
        }
        [Test]
        public void Should_have_error_Rover_Outside_Map_Border_UpperRight()
        {
            RoverMapValidator roverMapValidator = new RoverMapValidator(upperRightPointModel);
            IRoverModel roverModel = new RectangleRoverModel();
            roverModel.X = upperRightPointModel.X;
            roverModel.Y = upperRightPointModel.Y;

            var validator = roverMapValidator.Validate(roverModel);
            Assert.AreEqual(true, validator.IsValid, validator.Errors.FirstOrDefault()?.ErrorMessage);
        }
    }
}