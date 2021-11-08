using Business.Abstract;
using Business.Concrete;
using Entities.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ConsoleUI;
using Common.Exceptions;

namespace Test
{
    [TestClass]
    public class RoverTest
    {
        [TestMethod]
        public void RoverOneTest()
        {
            Plateau plateau = new Plateau(5, 5);
            Simulation simulation = new Simulation(plateau);
            IRoverManager roverManager = new RoverManager(plateau, new List<Rover>());
            Rover roverOne = new Rover(new Location { XAxis=1, YAxis=2 },'N');
            roverOne.RoverDirection = simulation.DirectionToRoverDirection(roverOne.Direction);
            roverManager.ExecuteCommands(roverOne, "LMLMLMLMM");
            Assert.AreEqual("1 3 N", roverManager.PrintCurrentStateOfRover(roverOne));
        }
        [TestMethod]
        public void RoverTwoTest()
        {
            Plateau plateau = new Plateau(5, 5);
            Simulation simulation = new Simulation(plateau);            
            IRoverManager roverManager = new RoverManager(plateau, new List<Rover>());
            Rover roverTwo = new Rover(new Location { XAxis = 3, YAxis = 3 }, 'E');
            roverTwo.RoverDirection = simulation.DirectionToRoverDirection(roverTwo.Direction);
            roverManager.ExecuteCommands(roverTwo, "MMRMMRMRRM");

            Assert.AreEqual("5 1 E", roverManager.PrintCurrentStateOfRover(roverTwo));
        }
        [TestMethod]
        [ExpectedException(typeof(CollisionException))]
        public void RoverCollisionTest()
        {
            Plateau plateau = new Plateau(5, 5);
            Simulation simulation = new Simulation(plateau);            
            IRoverManager roverManager = new RoverManager(plateau, new List<Rover>());
            Rover rover = new Rover(new Location { XAxis = 3, YAxis = 3 }, 'E');
            rover.RoverDirection = simulation.DirectionToRoverDirection(rover.Direction);
            roverManager.AddRover(rover);
            Rover roverTwo = new Rover(new Location { XAxis = 4, YAxis = 3 }, 'E');
            roverTwo.RoverDirection = simulation.DirectionToRoverDirection('E');
            roverManager.AddRover(roverTwo);
            roverManager.Move(rover);
        }
        [TestMethod]
        [ExpectedException(typeof(OutOfPlateauException))]
        public void IsOnPlateauTest()
        {
            Plateau plateau = new Plateau(5, 5);
            Simulation simulation = new Simulation(plateau);
            simulation.InitializeRover(new Location {XAxis = 5, YAxis = 6}, 'E');
        }
        [TestMethod]
        public void OutOfPlateauTest()
        {
            Plateau plateau = new Plateau(5, 5);
            Simulation simulation = new Simulation(plateau);
            IRoverManager roverManager = new RoverManager(plateau, new List<Rover>());
            Rover rover = new Rover(new Location { XAxis = 1, YAxis = 1 }, 'W');
            rover.RoverDirection = simulation.DirectionToRoverDirection(rover.Direction);
            roverManager.ExecuteCommands(rover, "MMM");

            Assert.AreEqual("0 1 W", roverManager.PrintCurrentStateOfRover(rover));
        }
    }
}
