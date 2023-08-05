
using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver.Core.Configuration;
using MongoDB.Bson.Serialization.Conventions;

namespace Blasco.Data
{
    public class BlascoMongoExperimental
    {
        private MongoClient dbClient;
        public BlascoMongoExperimental()
        {
            dbClient = new MongoClient("mongodb://localhost:27017");
        }

        public void ListDatabases()
        {
            var pack = new ConventionPack { new CamelCaseElementNameConvention() };
            ConventionRegistry.Register("elementNameConvention", pack, x => true);

            IMongoDatabase db = dbClient.GetDatabase("testdb");

            var coll = db.GetCollection<Image>("photo");


            byte[] binaryContent = File.ReadAllBytes("image.jpg");

            var photos = new[]
            {
                new Image
                {
                    FileName = "Test",
                    EntityCorrespondingId = "2871D55E-AE05-40CC-BBC3-E5EB8803EB70",
                    ContentImage = binaryContent
                }
            };

            coll.InsertMany(photos);


            var results = coll.Find(g => g.FileName == "Test").ToList();
            foreach (var doc in results)
            {
                Console.WriteLine(doc.ToBsonDocument());
            }


            foreach (var comet in photos)
            {
                Console.WriteLine(comet.ContentImage);
            }



            var dbList = dbClient.ListDatabases().ToList();
            Console.WriteLine("The list of databases are:");

            foreach (var item in dbList)
            {
                Console.WriteLine(item);
            }
        }
        public class Image
        {
            //[BsonId]
            //[BsonRepresentation(BsonType.ObjectId)]
            public ObjectId Id { get; set; }

            //[BsonRequired]
            public string FileName { get; set; } = null!;

            //[BsonRequired]
            public byte[] ContentImage { get; set; } = null!;

            //[BsonRequired]
            public string EntityCorrespondingId { get; set; } = null!;
        }

    }
}
