using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace MetricsAgentTest
{
    public class CPUMetricsControllerTest
    {
        private CPUMetricsController _cpuMetricsController;

        public CPUMetricsControllerTest()
        {
            _cpuMetricsController = new CPUMetricsController();
        }

        [Fact]
        public void GetCpuMetrics_ReturnOk()
        {
            TimeSpan fromTime = TimeSpan.FromSeconds(0);
            TimeSpan toTime = TimeSpan.FromSeconds(100);
            var result = _cpuMetricsController.GetCPUMetrics(fromTime, toTime);
            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
