using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRoverManager
    {
        void ExecuteCommands(Rover rover, string commands);
        void PrintCurrentStateOfPlateau();
        void TurnLeft(Rover rover);
        void TurnRight(Rover rover);
        void Move(Rover rover);
        string PrintCurrentStateOfRover(Rover rover);
        void AddRover(Rover rover);
    }
}
