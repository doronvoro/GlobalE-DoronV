namespace GlobalE.BL
{
    public class TimerService
    {
        private readonly ITimerRepository _repository;

        public TimerService(ITimerRepository repository)
        {
            _repository = repository;
        }

        public TimerResponse SetTimer(TimerRequest request)
        {
            var timer = new TimerItem
            {
                Id = Guid.NewGuid(),
                ExpiryTime = DateTime.UtcNow.AddHours(request.Hours).AddMinutes(request.Minutes).AddSeconds(request.Seconds),
                WebhookUrl = request.WebhookUrl
            };

            _repository.AddTimer(timer);

            return new TimerResponse { Id = timer.Id };
        }

        public TimerStatusResponse GetTimerStatus(Guid id)
        {
            var timer = _repository.GetTimer(id);
            if (timer == null)
            {
                return null;
            }

            return new TimerStatusResponse
            {
                Id = timer.Id,
                TimeLeft = timer.TimeLeft
            };
        }
    }
}
