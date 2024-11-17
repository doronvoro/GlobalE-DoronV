using System.Collections.Concurrent;

namespace GlobalE.BL
{
    public class InMemoryTimerRepository : ITimerRepository
    {
        private readonly ConcurrentDictionary<Guid, TimerItem> _timers = new();

        public void AddTimer(TimerItem timer)
        {
            _timers[timer.Id] = timer;
        }

        public TimerItem GetTimer(Guid id)
        {
            _timers.TryGetValue(id, out var timer);
            return timer;
        }

        public IEnumerable<TimerItem> GetAllTimers() => _timers.Values;
    }
}