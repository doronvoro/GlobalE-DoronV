//using System.Threading.Tasks;
//using GlobalE.BL;
////using Mongo2Go;
//using MongoDB.Driver;
//using Moq;
//using Xunit;

//public class MongoTimerRepositoryTests
//{
//    private readonly Mock<IMongoCollection<Timer>> _mockCollection;
//    private readonly MongoTimerRepository _repository;

//    public MongoTimerRepositoryTests()
//    {
//        var mockDatabase = new Mock<IMongoDatabase>();
//        _mockCollection = new Mock<IMongoCollection<Timer>>();
//        mockDatabase.Setup(db => db.GetCollection<Timer>("Timers", null)).Returns(_mockCollection.Object);
//        _repository = new MongoTimerRepository(mockDatabase.Object);
//    }

//    [Fact]
//    public async Task GetByIdAsync_ReturnsTimer_WhenTimerExists()
//    {
//        // Arrange
//        var timerId = "123";
//        var expectedTimer = new Timer { Id = timerId };
//        _mockCollection.Setup(c => c.Find(It.IsAny<FilterDefinition<Timer>>(), null))
//                       .Returns(new Mock<IAsyncCursor<Timer>>().Object);

//        var cursor = new Mock<IAsyncCursor<Timer>>();
//        cursor.Setup(_ => _.Current).Returns(new[] { expectedTimer });
//        _mockCollection.Setup(c => c.Find(It.IsAny<FilterDefinition<Timer>>(), null)).Returns(cursor.Object);

//        // Act
//        var result = await _repository.GetByIdAsync(timerId);

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(timerId, result.Id);
//    }

//    [Fact]
//    public async Task AddAsync_InsertsTimer()
//    {
//        // Arrange
//        var timer = new Timer { Id = "123" };

//        // Act
//        await _repository.AddAsync(timer);

//        // Assert
//        _mockCollection.Verify(c => c.InsertOneAsync(timer, null, default), Times.Once);
//    }
//}
