using MetricsManager.Models;
using MetricsManager.Models.Requests;

namespace MetricsManager.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            AgentsClient agentsClient = new AgentsClient("http://localhost:5062/", new HttpClient());
            CPUMetricsClient cpuMetricsClient = new CPUMetricsClient("http://localhost:5062/", new HttpClient());

            //http://localhost:5151/

            await agentsClient.RegisterAsync(new Models.AgentInfo
            {
                AgentAddress = new Uri("http://localhost:5151/"),
                AgentId = 1,
                Enable = true
            });

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Задачи");
                Console.WriteLine("==============================================");
                Console.WriteLine("1 - Получить метрики за последнюю минуту (CPU)");
                Console.WriteLine("0 - Завершение работы приложения");
                Console.WriteLine("==============================================");
                Console.Write("Введите номер задачи: ");
                if (int.TryParse(Console.ReadLine(), out int taskNumber))
                {
                    switch (taskNumber)
                    {
                        case 0:
                            Console.WriteLine("Завершение работы приложения.");
                            return;
                        case 1:
                            try
                            {

                                TimeSpan toTime = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
                                TimeSpan fromTime = toTime - TimeSpan.FromSeconds(60);

                                CPUMetricsResponse response = await cpuMetricsClient.GetAllByIdAsync(
                                    1,
                                    fromTime.ToString("dd\\.hh\\:mm\\:ss"),
                                    toTime.ToString("dd\\.hh\\:mm\\:ss"));

                                foreach (CPUMetric metric in response.Metrics)
                                {
                                    Console.WriteLine($"{TimeSpan.FromSeconds(metric.Time).ToString("dd\\.hh\\:mm\\:ss")} >>> {metric.Value}");
                                }
                                Console.WriteLine("Нажмите любую клавишу для продолжения работы ...");
                                Console.ReadKey(true);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"Произошла ошибка при попыте получить CPU метрики.\n{e.Message}");
                            }

                            break;
                        default:
                            Console.WriteLine("Введите корректный номер подзадачи.");
                            break;
                    }
                }
            }
        }
    }
}
