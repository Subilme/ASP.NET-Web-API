using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace MetricsManagerTest
{
    public class RamMetricsControllerTest
    {
        private RamMetricsController _ramMetricsController;

        public RamMetricsControllerTest()
        {
            _ramMetricsController = new RamMetricsController();
        }

        [Fact]
        public void GetMetricsFromAgent_ReturnOk()
        {
            int agentId = 1;
            TimeSpan fromTime = TimeSpan.FromSeconds(0);
            TimeSpan toTime = TimeSpan.FromSeconds(100);

            var result = _ramMetricsController.GetMetricsFromAgent(agentId, fromTime, toTime);

            Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void GetMetricsFromAll_ReturnOk()
        {
            TimeSpan fromTime = TimeSpan.FromSeconds(0);
            TimeSpan toTime = TimeSpan.FromSeconds(100);

            var result = _ramMetricsController.GetMetricsFromAll(fromTime, toTime);

            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
