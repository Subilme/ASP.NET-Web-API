using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace MetricsAgentTest
{
    public class HddMetricsControllerTest
    {
        private HddMetricsController _hddMetricsController;

        public HddMetricsControllerTest()
        {
            _hddMetricsController = new HddMetricsController();
        }

        [Fact]
        public void GetDotNetMetrics_ReturnOk()
        {
            TimeSpan fromTime = TimeSpan.FromSeconds(0);
            TimeSpan toTime = TimeSpan.FromSeconds(100);
            var result = _hddMetricsController.GetHDDMetrics(fromTime, toTime);
            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
