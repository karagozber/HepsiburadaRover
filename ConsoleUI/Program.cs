using Entities.Concrete;
using Business.Concrete;
using System;
using System.Collections.Generic;
using Business.Abstract;
using Common.Exceptions;
using Common;

namespace ConsoleUI
{
    static class Program
    {
        static void Main(string[] args)
        {
            Simulation simulation = new Simulation();
            simulation.Simulate();
        }
        
    }
}
