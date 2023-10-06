

using PRHD_FULL.Modelos.Dto;

namespace PRDH_FULL
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private string _path = Directory.GetCurrentDirectory() + @"\Files\";
        private int _count = 0;
        
        ///
        private readonly IServiceProvider _serviceProvider;

        public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            int a = 0;
            while (!stoppingToken.IsCancellationRequested && a == 0)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                
                await using (var scope = _serviceProvider.CreateAsyncScope() )
                {
                    var service = scope.ServiceProvider.GetRequiredService<IFiledata>();
                    await service.GetService($"{_path}{_count++}.txt");
                    a = 1;
                }               
            }
        }
    }
}