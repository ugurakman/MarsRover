using Nasa.MarsRover.Business;
using Nasa.MarsRover.Business.Domain.Models;
using Nasa.MarsRover.Business.Interfaces;
using System;
using System.Collections.Generic;

namespace Nasa.MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Parameters

            var plateau = new PlateauModel();
            plateau.LowerLeft = 5;
            plateau.UpperRight = 5;

            var rover1 = new RoverModel
            {
                X = 1,
                Y = 2,
                Direction = 'N',
                Movement = "LMLMLMLMM",
                Plateau = plateau
            };

            var rover2 = new RoverModel
            {
                X = 3,
                Y = 3,
                Direction = 'E',
                Movement = "MMRMMRMRRM",
                Plateau = plateau
            }; 
            #endregion

            Queue<RoverModel> myQueue = new Queue<RoverModel>();
            myQueue.Enqueue(rover1);
            myQueue.Enqueue(rover2);

            Manager manager = new Manager();

            GetInputsForPlateau(plateau, manager);
            manager.PreparePlateau(plateau);

            string roverStatus = "";

            int i = 1;
            while (myQueue.Count > 0)
            {
                var rover = myQueue.Dequeue();
                GetInputsForRover(rover, manager, plateau, i);
                roverStatus += manager.GetRoverStatus();

                i++;
            }

            Console.WriteLine(roverStatus);

            Console.ReadLine();
        }

        private static void GetInputsForPlateau(PlateauModel plateaus, IManager manager)
        {
            do
            {
                manager.PreparePlateau(plateaus);

                if (plateaus.ErrorTracer != null)
                    Console.WriteLine(plateaus.ErrorTracer);

            } while (plateaus.ErrorTracer != null);

        }

        private static void GetInputsForRover(RoverModel rover, IManager manager, PlateauModel plateaus, int i)
        {
            do
            {
                manager.PrepareRover(rover);

                if (rover.ErrorTracer != null)
                    Console.WriteLine(rover.ErrorTracer);


            } while (rover.ErrorTracer != null);

            GetInputForPath(rover, manager);
        }

        private static void GetInputForPath(RoverModel rover, IManager manager)
        {
            do
            {
                manager.MoveRover(rover);

                if (rover.ErrorTracer != null)
                    Console.WriteLine(rover.ErrorTracer);

            } while (rover.ErrorTracer != null);
        }
    }
}
