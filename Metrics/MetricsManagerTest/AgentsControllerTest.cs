using MetricsManager.Controllers;
using MetricsManager.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace MetricsManagerTest
{
    public class AgentsControllerTest
    {
        private AgentsController _agentsController;
        private AgentPool _agentPool;
        public AgentsControllerTest()
        {
            _agentPool = AgentPool.Instance;
            _agentsController = new AgentsController(_agentPool);

        }

        [Theory]
        [InlineData(5)]
        [InlineData(15)]
        [InlineData(25)]
        public void RegisterAgentTest(int agentId)
        {
            AgentInfo agentInfo = new AgentInfo() { AgentId = agentId, Enable = true };
            var actionResult = _agentsController.RegisterAgent(agentInfo);
            Assert.IsAssignableFrom<IActionResult>(actionResult);
        }
    }
}
