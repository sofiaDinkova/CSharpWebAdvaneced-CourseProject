namespace Blasco.Data.BlascoMongoDbFactory.Interfaces
{
    using MongoDB.Driver;
    public interface IMongoDbFactory
    {
        IMongoCollection<T> GetCollection<T>(string databaseName, string collectionNme);
    }
}
