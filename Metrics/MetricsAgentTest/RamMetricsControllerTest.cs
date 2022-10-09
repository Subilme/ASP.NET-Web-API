using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace MetricsAgentTest
{
    public class RamMetricsControllerTest
    {
        private RamMetricsController _ramMetricsController;

        public RamMetricsControllerTest()
        {
            _ramMetricsController = new RamMetricsController();
        }

        [Fact]
        public void GetDotNetMetrics_ReturnOk()
        {
            TimeSpan fromTime = TimeSpan.FromSeconds(0);
            TimeSpan toTime = TimeSpan.FromSeconds(100);
            var result = _ramMetricsController.GetRAMMetrics(fromTime, toTime);
            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
