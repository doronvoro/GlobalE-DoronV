//using MongoDB.Driver;

//namespace GlobalE.BL
//{
//    public class MssqlTimerRepository : ITimerRepository
//    {
//        private readonly ApplicationDbContext _context;

//        public MssqlTimerRepository(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<Timer> GetByIdAsync(int id)
//        {
//            return await _context.Timers.FindAsync(id);
//        }

//        public async Task AddAsync(Timer timer)
//        {
//            timer.CreatedAt = DateTime.UtcNow;
//            _context.Timers.Add(timer);
//            await _context.SaveChangesAsync();
//        }

//        public async Task UpdateAsync(Timer timer)
//        {
//            _context.Timers.Update(timer);
//            await _context.SaveChangesAsync();
//        }

//        public async Task DeleteAsync(int id)
//        {
//            var timer = await _context.Timers.FindAsync(id);
//            if (timer != null)
//            {
//                _context.Timers.Remove(timer);
//                await _context.SaveChangesAsync();
//            }
//        }

//        public IQueryable<Timer> GetAll()
//        {
//            return _context.Timers.AsQueryable();
//        }
//    }



//}