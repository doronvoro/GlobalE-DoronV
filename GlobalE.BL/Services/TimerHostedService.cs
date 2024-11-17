using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GlobalE.BL
{
    public class TimerHostedService : BackgroundService
    {
        private readonly ITimerRepository _repository;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<TimerHostedService> _logger;

        public TimerHostedService(ITimerRepository repository,
                                  IHttpClientFactory httpClientFactory,
                                  ILogger<TimerHostedService> logger)
        {
            _repository = repository;
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                _logger.LogDebug("Timer check {time}", DateTime.Now);

                var timers = _repository.GetAllTimers()
                                        .Where(t => t.IsExpired && !t.IsExecuted)
                                        .ToList();

                _logger.LogDebug("timers to execute {timers}", timers);

                foreach (var timer in timers)
                {
                    //TODO: fire and forget or wait?
                    await SendWebhookAsync(timer.WebhookUrl);
                    // Optionally remove the expired timer from the repository or use an arcive repository
                    timer.IsExecuted = true;
                }
                await Task.Delay(1000, stoppingToken); // Check every second
            }
        }

        private async Task SendWebhookAsync(string webhookUrl)
        {
            try
            {
                var client = _httpClientFactory.CreateClient(nameof(TimerHostedService));
                await client.PostAsync(webhookUrl, null);
            }
            catch (Exception ex)
            {
                //TODO: use retry? check http reason 
                _logger.LogError(ex, "Failed to send webhook");
            }
        }
    }
}