using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace MetricsAgentTest
{
    public class DotNetMetricsControllerTest
    {
        private DotNetMetricsController _dotNetMetricsController;

        public DotNetMetricsControllerTest()
        {
            _dotNetMetricsController = new DotNetMetricsController();
        }

        [Fact]
        public void GetDotNetMetrics_ReturnOk()
        {
            TimeSpan fromTime = TimeSpan.FromSeconds(0);
            TimeSpan toTime = TimeSpan.FromSeconds(100);
            var result = _dotNetMetricsController.GetDotNetMetrics(fromTime, toTime);
            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
