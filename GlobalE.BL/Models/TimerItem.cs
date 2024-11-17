using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace GlobalE.BL
{
    public class TimerItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)] public Guid Id { get; set; }
        public DateTime ExpiryTime { get; set; }
        public string WebhookUrl { get; set; }
        public bool IsExecuted { get; set; }
       
        [BsonIgnore]
        public bool IsExpired => DateTime.UtcNow >= ExpiryTime;
        [BsonIgnore]
        public int TimeLeft => IsExpired ? 0 : (int)(ExpiryTime - DateTime.UtcNow).TotalSeconds;
    }
}