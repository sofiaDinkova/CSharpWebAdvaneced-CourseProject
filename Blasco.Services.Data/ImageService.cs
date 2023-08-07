using Blasco.Data.BlascoMongoDbFactory.Interfaces;
using Blasco.Data.Models;
using Blasco.Services.Data.Interfaces;
using MongoDB.Driver;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blasco.Services.Data
{
    public class ImageService : IImageService
    {
        private readonly IMongoCollection<Image> images;

        public ImageService(IMongoDbFactory mongoDbFactory)
        {
            this.images = mongoDbFactory.GetCollection<Image>("blasco", "image");
        }

        public byte[] GetImageBytesByEntityCorrespondingId(string entityId)
        {
            //var imageCollection = dbClient.GetCollection<Image>("blasco");

            // Retrieve the image data from MongoDB
            var filter = Builders<Image>.Filter.Eq("EntityCorrespondingId", entityId.ToLower());
            Image imageDocument = images.Find(filter).FirstOrDefault();

            if (imageDocument != null)
            {
                // Extract binary data from the Image entity
                byte[] imageBytes = imageDocument.ContentImage;

                return imageBytes;
            }

            return null; // Image not found
        }

        public List<byte[]> GetAllImagesBytesByEntityCorrespondingId(string entityId)
        {
            //var imageCollection = dbClient.GetCollection<Image>("blasco");

            // Retrieve the image data from MongoDB
            var filter = Builders<Image>.Filter.Eq("EntityCorrespondingId", entityId.ToLower());
            var imageDocument = images.Find(filter).ToList();

            List<byte[]> imagesBytes = new();

            if (imageDocument != null)
            {
                // Extract binary data from the Image entity
                foreach (var document in imageDocument)
                {
                    byte[] imageBytes = document.ContentImage;
                    imagesBytes.Add(imageBytes);
                }
                return imagesBytes;
            }

            return null; // Image not found
        }
        public async Task InsertImagesAsync(List<IFormFile> files, string entityCorrespondingId)
        {
            foreach (var file in files)
            {
                if (file != null && file.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await file.CopyToAsync(memoryStream);
                        var image = new Image
                        {
                            FileName = file.FileName,
                            ContentImage = memoryStream.ToArray(),
                            EntityCorrespondingId = entityCorrespondingId
                        };
                        await images.InsertOneAsync(image);
                    }
                }
            }
        }
    }
}
