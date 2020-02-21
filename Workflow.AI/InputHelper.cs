using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Workflow.AI
{
    public class InputHelper
    {
        //below line for future input validation
        //static List<string> validCharInputlist = new List<string>() { "L", "R", "M", "N","E","W","S" };

        public static List<int> GetUpperRightMax(string input)
        {
            if (string.IsNullOrEmpty(input))
                new ArgumentException("Invalid upper X,Y values");

            var xyMaxArray = input.Split(' ');
            if (xyMaxArray.Length > 2 || xyMaxArray.Length < 1)
                new ArgumentException("Invalid upper X,Y values");
            return xyMaxArray.Select(int.Parse).ToList();

        }

        public static List<string> GetRoverInputPositionLineOne(string input)
        {
            if (string.IsNullOrEmpty(input))
                new ArgumentException("Invalid position values");

            var xyMaxArray = input.Split(' ');
            if (xyMaxArray.Length > 3 || xyMaxArray.Length < 1)
                new ArgumentException("Invalid position values");
            return xyMaxArray.ToList();
        }

        public static List<char> GetRoverInpuInstructionineTwo(string input)
        {
            if (string.IsNullOrEmpty(input))
                new ArgumentException("Invalid position values");

            return input.ToCharArray().ToList<char>();
        }


    }
}
