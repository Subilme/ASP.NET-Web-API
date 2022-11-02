using MetricsAgent.Services;
using Quartz;
using System.Diagnostics;

namespace MetricsAgent.Jobs
{
    public class DotNetMetricJob : IJob
    {
        private PerformanceCounter _dotnetCounter;
        private IServiceScopeFactory _serviceScopeFactory;

        public DotNetMetricJob(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _dotnetCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        }

        public Task Execute(IJobExecutionContext context)
        {
            using (IServiceScope serviceScope = _serviceScopeFactory.CreateScope())
            {
                var dotnetMetricsRepository = serviceScope.ServiceProvider.GetService<IDotNetMetricsRepository>();
                try
                {
                    var dotnetUsageInPercents = _dotnetCounter.NextValue();
                    var time = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
                    Debug.WriteLine($"{time} > {dotnetUsageInPercents}");
                    dotnetMetricsRepository.Create(new Models.DotNetMetric
                    {
                        Value = (int)dotnetUsageInPercents,
                        Time = (long)time.TotalSeconds
                    });
                }
                catch (Exception ex)
                {

                }
            }

            return Task.CompletedTask;
        }
    }
}
