using Entities.Concrete;
using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Common;
using Common.Exceptions;

namespace Business.Concrete
{
    public class RoverManager : IRoverManager
    {
        public List<Rover> RoverList { get; set; }
        public Plateau Plateau { get; set; }
        public RoverManager(Plateau plateau, List<Rover> roverList)
        {
            Plateau = plateau;
            RoverList = roverList;
        }
        public void ExecuteCommands(Rover rover, string commands)
        {
            foreach (char cmd in commands)
            {
                if (cmd == 'R')
                {
                    TurnRight(rover);
                }
                else if (cmd == 'L')
                {
                    TurnLeft(rover);
                }
                else if (cmd == 'M')
                {
                    Move(rover);
                }
                else
                {
                    throw new CommandException(cmd);
                }
            }
        }

        public void Move(Rover rover)
        {
            switch (rover.RoverDirection)
            {
                case RoverDirection.N:
                    if (rover.Location.YAxis != Plateau.YLimit)
                    {
                        //Collision control
                        Location newLoc = new Location() { XAxis = rover.Location.XAxis, YAxis = rover.Location.YAxis + 1 };
                        if (IsCollided(newLoc))
                        {
                            throw new CollisionException();
                        }
                        rover.Location.YAxis++;
                    }                        
                    break;
                case RoverDirection.E:
                    if (rover.Location.XAxis != Plateau.XLimit)
                    {
                        Location newLoc = new Location() { XAxis = rover.Location.XAxis + 1, YAxis = rover.Location.YAxis };
                        if (IsCollided(newLoc))
                        {
                            throw new CollisionException();
                        }
                        rover.Location.XAxis++;
                    }
                    break;
                case RoverDirection.S:
                    if (rover.Location.YAxis != 0)
                    {
                        Location newLoc = new Location() { XAxis = rover.Location.XAxis, YAxis = rover.Location.YAxis - 1 };
                        if (IsCollided(newLoc))
                        {
                            throw new CollisionException();
                        }
                        rover.Location.YAxis--;
                    }
                    break;
                case RoverDirection.W:
                    if (rover.Location.XAxis != 0)
                    {
                        Location newLoc = new Location() { XAxis = rover.Location.XAxis - 1, YAxis = rover.Location.YAxis };
                        if (IsCollided(newLoc))
                        {
                            throw new CollisionException();
                        }
                        rover.Location.XAxis--;
                    }
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        public void PrintCurrentStateOfPlateau()
        {
            foreach (Rover rover in RoverList)
            {
                PrintCurrentStateOfRover(rover);
            }
        }

        public void TurnLeft(Rover rover)
        {
            if (rover.RoverDirection == RoverDirection.N)
            {
                rover.RoverDirection = RoverDirection.W;
            }
            else
            {
                rover.RoverDirection--;
            }            
        }

        public void TurnRight(Rover rover)
        {
            if (rover.RoverDirection == RoverDirection.W)
            {
                rover.RoverDirection = RoverDirection.N;
            }
            else
            {
                rover.RoverDirection++;
            }
        }
        public string PrintCurrentStateOfRover(Rover rover)
        {
            string output = rover.Location.XAxis + " " + rover.Location.YAxis + " " + rover.Direction;
            Console.WriteLine(output);

            return output;
        }
        public void AddRover(Rover rover)
        {
            RoverList.Add(rover);
        }
        private bool IsCollided(Location loc)
        {
            foreach (Rover rover in RoverList)
            {
                if (loc.XAxis == rover.Location.XAxis && loc.YAxis == rover.Location.YAxis)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
