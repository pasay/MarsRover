using MarsRover.Models;
using MarsRover.Models.Rover;
using MarsRover.Models.Rover.Imp;
using MarsRover.Models.Validations;
using NUnit.Framework;
using FluentValidation;
using FluentValidation.TestHelper;
using System.Collections.Generic;
using System.Linq;
using MarsRover.Models.Enums;
using System;
using MarsRover.Business.Extensions;

namespace MarsRover.UnitTests.Business.Extensions
{
    [TestFixture]
    public class EnumExtensionTest
    {
        List<DirectionType> DirectionTypeList;
        [SetUp]
        public void Setup()
        {
            DirectionTypeList = Enum.GetValues(typeof(DirectionType)).Cast<DirectionType>().ToList();
        }

        [Test]
        [TestCase(DirectionType.E)]
        [TestCase(DirectionType.N)]
        [TestCase(DirectionType.S)]
        [TestCase(DirectionType.W)]
        public void Should_have_error_DirectionType_Next_Value(DirectionType directionType)
        {
            DirectionType nextDirectionType = directionType.NextValue();
            DirectionType correctDirectionType = DirectionTypeList[(DirectionTypeList.IndexOf(directionType) + 1) % DirectionTypeList.Count()];
            Assert.AreEqual(correctDirectionType, nextDirectionType);
        }

        [Test]
        [TestCase(DirectionType.E)]
        [TestCase(DirectionType.N)]
        [TestCase(DirectionType.S)]
        [TestCase(DirectionType.W)]
        public void Should_have_error_Previous_Value(DirectionType directionType)
        {
            DirectionType prevDirectionType = directionType.PreviousValue();
            DirectionType correctDirectionType = DirectionTypeList[(DirectionTypeList.IndexOf(directionType) - 1 + DirectionTypeList.Count()) % DirectionTypeList.Count()];
            Assert.AreEqual(correctDirectionType, prevDirectionType);
        }
    }
}
