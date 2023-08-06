using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blasco.Data.BlascoMongoDbFactory.Interfaces
{
    public interface IMongoDbFactory
    {
        IMongoCollection<T> GetCollection<T>(string databaseName, string collectionNme);
    }
}
