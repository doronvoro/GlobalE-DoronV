namespace GlobalE.BL
{
    public interface ITimerRepository
    {
        void AddTimer(TimerItem timer);
        TimerItem GetTimer(Guid id);
        IEnumerable<TimerItem> GetAllTimers();
    }
}