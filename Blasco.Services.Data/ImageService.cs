
using Blasco.Data.BlascoMongoDbFactory;
using Blasco.Data.Models;
using Blasco.Services.Data.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blasco.Services.Data
{
    public class ImageService : IImageService
    {
        private readonly IMongoCollection<Image> toDoItems;

        public ImageService(IMongoDbFactory mongoDbFactory)
        {
            this.toDoItems = mongoDbFactory.GetCollection<Image>("blasco", "image");
        }

        public byte[] GetImageBytesByEntityCorrespondingId(string entityId)
        {
            //var imageCollection = dbClient.GetCollection<Image>("blasco");

            // Retrieve the image data from MongoDB
            var filter = Builders<Image>.Filter.Eq("EntityCorrespondingId", entityId);
            var imageDocument = toDoItems.Find(filter).FirstOrDefault();

            if (imageDocument != null)
            {
                // Extract binary data from the Image entity
                byte[] imageBytes = imageDocument.ContentImage;

                return imageBytes;
            }

            return null; // Image not found
        }
    }
}
