using System;
using Workflow.AI;
using Xunit;

namespace WeddingShopTechTest.Test
{
    public class RoverTest
    {
        [Fact]
        public void TestScanrio_12N_LMLMLMLMM()
        {
            string maxXY = "5 5";
            string position = "1 2 N", instruction = "LMLMLMLMM";

            var mission = new RoverControlCenter(maxXY);
            var expectedOutput = "1 3 N";
            var actulOutput = mission.MissionControl(position, instruction);
            Assert.Equal(expectedOutput, actulOutput);
        }

        [Fact]
        public void TestScanrio_33E_MRRMMRMRRM()
        {
            string maxXY = "5 5";
            string position = "3 3 E", instruction = "MMRMMRMRRM";

            var mission = new RoverControlCenter(maxXY);
            var expectedOutput = "5 1 E";
            var actulOutput = mission.MissionControl(position, instruction);

            Assert.Equal(expectedOutput, actulOutput);
        }
    }
}
