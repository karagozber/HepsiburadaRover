using Business.Abstract;
using Business.Concrete;
using Common;
using Common.Exceptions;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    public class Simulation
    {
        public IRoverManager RoverManager { get; set; }
        public Plateau Plateau { get; set; }
        public Simulation()
        {
            Console.WriteLine("Please enter dimensions of the plateau: ");
            String dimensions = Console.ReadLine();
            String[] dims = dimensions.Split(' ');
            Plateau = new Plateau(Convert.ToInt32(dims[0]), Convert.ToInt32(dims[1]));
            RoverManager = new RoverManager(Plateau, new List<Rover>());
        }
        public Simulation(Plateau plateau)
        {
            Plateau = plateau;
            RoverManager = new RoverManager(Plateau, new List<Rover>());
        }

        public void Simulate() {
            InitializeRover();
            InitializeRover();
            RoverManager.PrintCurrentStateOfPlateau();
        }       

        public Rover InitializeRover()
        {
            Console.WriteLine("Please enter the location and direction of rover: ");
            String rov = Console.ReadLine();
            String[] rovLoc = rov.Split(' ');
            Location roverLoc = new Location { XAxis = Convert.ToInt32(rovLoc[0]), YAxis = Convert.ToInt32(rovLoc[1]) };

            //Checks if rover location is valid
            if (!IsOnPlateau(roverLoc))
            {
                throw new OutOfPlateauException(roverLoc.XAxis, roverLoc.YAxis);
            }
            Rover rover = new Rover(roverLoc, Convert.ToChar(rovLoc[2]));
            rover.RoverDirection = DirectionToRoverDirection(rover.Direction);
            RoverManager.AddRover(rover);

            Console.WriteLine("Please enter commands for rover: ");
            String commands = Console.ReadLine();
            RoverManager.ExecuteCommands(rover, commands);

            return rover;
        }
        public Rover InitializeRover(Location roverLoc, char direction)
        {
            //Checks if rover location is valid
            if (!IsOnPlateau(roverLoc))
            {
                throw new OutOfPlateauException(roverLoc.XAxis, roverLoc.YAxis);
            }
            Rover rover = new Rover(roverLoc, direction);
            rover.RoverDirection = DirectionToRoverDirection(rover.Direction);
            RoverManager.AddRover(rover);

            Console.WriteLine("Please enter commands for rover: ");
            String commands = Console.ReadLine();
            RoverManager.ExecuteCommands(rover, commands);

            return rover;
        }
        public RoverDirection DirectionToRoverDirection(char direction)
        {
            if (direction == 'N')
            {
                return RoverDirection.N;
            }
            else if (direction == 'E')
            {
                return RoverDirection.E;
            }
            else if (direction == 'S')
            {
                return RoverDirection.S;
            }
            else if (direction == 'W')
            {
                return RoverDirection.W;
            }
            else
            {
                throw new DirectionException(direction);
            }
        }
        public bool IsOnPlateau(Location loc)
        {
            if (loc.XAxis >= 0 && loc.XAxis <= Plateau.XLimit && loc.YAxis >= 0 && loc.YAxis <= Plateau.YLimit)
            {
                return true;
            }
            else
                return false;
        }
    }
}
