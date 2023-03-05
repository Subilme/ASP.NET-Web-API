using MetricsManager.Models;
using MetricsManager.Models.Requests;
using Newtonsoft.Json;

namespace MetricsManager.Services.Client.Impl
{
    public class CPUMetricsAgentClient : ICPUMetricsAgentClient
    {
        private readonly AgentPool _agentPool;
        private readonly HttpClient _httpClient;

        public CPUMetricsAgentClient(HttpClient httpClient, AgentPool agentPool)
        {
            _httpClient = httpClient;
            _agentPool = agentPool;
        }

        public CPUMetricsResponse GetCPUMetrics(CPUMetricsRequest request)
        {
            AgentInfo agentInfo = _agentPool.Get().FirstOrDefault(agent => agent.AgentId == request.AgentId);
            if (agentInfo == null)
            {
                return null;
            }

            string requestStr =
                $"{agentInfo.AgentAddress}api/metrics/cpu/from/{request.FromTime.ToString("dd\\.hh\\:mm\\:ss")}/to/{request.ToTime.ToString("dd\\.hh\\:mm\\:ss")}";

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, requestStr);
            httpRequestMessage.Headers.Add("Accept", "application/json");

            HttpResponseMessage response = _httpClient.Send(httpRequestMessage);
            if (response.IsSuccessStatusCode)
            {
                string responseStr = response.Content.ReadAsStringAsync().Result;
                CPUMetricsResponse cpuMetricsResponse =
                    (CPUMetricsResponse)JsonConvert.DeserializeObject(responseStr, typeof(CPUMetricsResponse));
                cpuMetricsResponse.AgentId = request.AgentId;
                return cpuMetricsResponse;
            }

            return null;
        }
    }
}
