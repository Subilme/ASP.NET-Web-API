using MetricsAgent.Models;

namespace MetricsAgent.Services
{
    public interface ICPUMetricsRepository : IRepository<CPUMetric>
    {
        IList<CPUMetric> GetByTimePeriod(TimeSpan timeFrom, TimeSpan timeTo);
    }
}
