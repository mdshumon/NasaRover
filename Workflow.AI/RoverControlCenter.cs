using System;
using System.Collections.Generic;
using System.Linq;
using Workflow.Models;
using static Workflow.Models.Enums;

namespace Workflow.AI
{
    public class RoverControlCenter : IRobot
    {

        PlateauVm plateau = new PlateauVm();

        //DS: An example position might be 0, 0, N, which means the rover is in the bottom left corner and facing North.

        public RoverControlCenter(string maxXY)
        {
            plateau.X = Plateau.MinX;
            plateau.Y = Plateau.MinY;
            plateau.XMax = InputHelper.GetUpperRightMax(maxXY)[0];
            plateau.YMax = InputHelper.GetUpperRightMax(maxXY)[1];
            plateau.FacingDirections = FacingDirections.N;
        }

        //DS: Assume that the square directly North from (x, y) is (x, y+1).
        private void DriveContinue()
        {
            
            if (plateau.FacingDirections == FacingDirections.N)
            {
                plateau.Y += 1;
            }
            else if (plateau.FacingDirections == FacingDirections.S)
            {
                plateau.Y -= 1;
            }
            else if (plateau.FacingDirections == FacingDirections.E)
            {
                plateau.X += 1;
            }
            else if (plateau.FacingDirections == FacingDirections.W)
            {
                plateau.X -= 1;
            }
        }
        private void Left_Rotation()
        {
            switch (plateau.FacingDirections)
            {
                case FacingDirections.N:
                    plateau.FacingDirections = FacingDirections.W;
                    break;
                case FacingDirections.S:
                    plateau.FacingDirections = FacingDirections.E;
                    break;
                case FacingDirections.E:
                    plateau.FacingDirections = FacingDirections.N;
                    break;
                case FacingDirections.W:
                    plateau.FacingDirections = FacingDirections.S;
                    break;
                default:
                    break;
            }
        }

        private void Right_Rotation()
        {
            switch (plateau.FacingDirections)
            {
                case FacingDirections.N:
                    plateau.FacingDirections = FacingDirections.E;
                    break;
                case FacingDirections.S:
                    plateau.FacingDirections = FacingDirections.W;
                    break;
                case FacingDirections.E:
                    plateau.FacingDirections = FacingDirections.S;
                    break;
                case FacingDirections.W:
                    plateau.FacingDirections = FacingDirections.N;
                    break;
                default:
                    break;
            }
        }

        public string MissionControl(string position, string instruction)
        {
            if (string.IsNullOrEmpty(position) || (string.IsNullOrEmpty(instruction)))
                new ArgumentException("Invalid input charters");
            List<string> directions = InputHelper.GetRoverInputPositionLineOne(position);
            this.plateau.X = Convert.ToInt32(directions[0]);
            this.plateau.Y = Convert.ToInt32(directions[1]);
            this.plateau.FacingDirections = GetCharToDirectionEnumMap(Convert.ToChar( directions[2]));
            char[] instruc = instruction.ToCharArray().Select(x => Char.ToUpper(x)).ToArray();

            foreach (var move in instruc)
            {
                switch (move)
                {
                    case 'M':
                        this.DriveContinue();
                        break;
                    case 'L':
                        Left_Rotation();
                        break;
                    case 'R':
                        Right_Rotation();
                        break;
                    default:
                        break;
                }
            }

            if (this.plateau.X<0|| this.plateau.X> this.plateau.XMax || this.plateau.Y < 0 || this.plateau.Y > this.plateau.YMax)
                new ArgumentException("Invalid input for MAX X and Y");

            return $"{this.plateau.X} {this.plateau.Y} {  plateau.FacingDirections}";
        }
        private FacingDirections GetCharToDirectionEnumMap(char dir)
        {
            switch (dir.ToString().ToUpper())
            {
                case "N":
                    return FacingDirections.N;
                case "S":
                    return FacingDirections.S;
                case "E":
                    return FacingDirections.E;
                case "W":
                    return FacingDirections.W;
                default:
                    return 0;
            }
        }
    }
}
