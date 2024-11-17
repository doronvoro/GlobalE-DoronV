using MongoDB.Driver;

namespace GlobalE.BL
{
    public class MongoTimerRepository : ITimerRepository
    {
        private readonly IMongoCollection<TimerItem> _timerCollection;

        public MongoTimerRepository(IMongoDatabase database)
        {
            _timerCollection = database.GetCollection<TimerItem>("Timers");
        }

        public void AddTimer(TimerItem timer)
        {
            _timerCollection.InsertOne(timer);
        }

        public TimerItem GetTimer(Guid id)
        {
            return _timerCollection.Find(timer => timer.Id == id).FirstOrDefault();
        }

        public IEnumerable<TimerItem> GetAllTimers()
        {
            return _timerCollection.Find(timer => true).ToList();
        }
    }
}