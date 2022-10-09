using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace MetricsAgentTest
{
    public class NetworkControllerTest
    {
        private NetworkMetricsController _ramMetricsController;

        public NetworkControllerTest()
        {
            _ramMetricsController = new NetworkMetricsController();
        }

        [Fact]
        public void GetDotNetMetrics_ReturnOk()
        {
            TimeSpan fromTime = TimeSpan.FromSeconds(0);
            TimeSpan toTime = TimeSpan.FromSeconds(100);
            var result = _ramMetricsController.GetNetworkMetrics(fromTime, toTime);
            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
