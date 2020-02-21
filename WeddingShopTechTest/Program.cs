using System;
using System.Collections.Generic;
using Workflow.AI;

namespace WeddingShopTechTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //case 1
            var result= new RoverControlCenter("5 5").MissionControl("1 2 N", "LMLMLMLMM");
            //case 2
            var result2 = new RoverControlCenter("5 5").MissionControl("3 3 E", "MMRMMRMRRM");

        }
    }
}
