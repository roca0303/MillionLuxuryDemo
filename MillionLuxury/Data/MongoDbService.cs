using MongoDB.Driver;

namespace MillionLuxury.Data
{
  // This class is responsible for connecting to the MongoDB database
  // Injections are done in the Startup.cs file
  public class MongoDbService
  {
    private readonly IConfiguration _configuration;
    private readonly IMongoDatabase _database;

    public MongoDbService(IConfiguration configuration)
    {
      _configuration = configuration;

      var connectionString = _configuration.GetConnectionString("DbConnection");
      var mongoUrl = MongoUrl.Create(connectionString);
      var mongoClient = new MongoClient(mongoUrl);
      _database = mongoClient.GetDatabase(mongoUrl.DatabaseName);
    }

    public IMongoDatabase? Database => _database;

  }
}
