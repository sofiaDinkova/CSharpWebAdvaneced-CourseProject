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
using Blasco.Web.ViewModels.Image;
using MongoDB.Bson;

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

        public Dictionary<string, byte[]> GetAllImagesIdsAndBytesByEntityCorrespondingId(string entityId)
        {
            //var imageCollection = dbClient.GetCollection<Image>("blasco");

            // Retrieve the image data from MongoDB
            var filter = Builders<Image>.Filter.Eq("EntityCorrespondingId", entityId.ToLower());
            var imageDocument = images.Find(filter).ToList();

            Dictionary<string, byte[]> imagesBytes = new();

            if (imageDocument != null)
            {
                // Extract binary data from the Image entity
                foreach (var document in imageDocument)
                {
                    byte[] imageBytes = document.ContentImage;
                    imagesBytes.Add(document.Id.ToString(), imageBytes);
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
                            EntityCorrespondingId = entityCorrespondingId.ToLower()
                        };
                        await images.InsertOneAsync(image);
                    }
                }
            }
        }

        public async Task DeleteProductImagesByEntityCorrespondingIdAsync(string id)
        {
            var filter = Builders<Image>.Filter.Eq("EntityCorrespondingId", id.ToLower());

            await images.DeleteManyAsync(filter);
        }

        public async Task DeleteProductImageByImageId(string id)
        {
            await images.DeleteOneAsync(a => a.Id.ToString() == id);

        }

        public List<ImageDeleteFormModel> GetImagesToEditByEntityCorrespondingIdAsync(string id)
        {
            Dictionary<string, byte[]> images = GetAllImagesIdsAndBytesByEntityCorrespondingId(id);
                        
            List<ImageDeleteFormModel> imageDeleteFormModels = new List<ImageDeleteFormModel>();

            foreach (var image in images)
            {
                ImageDeleteFormModel formModel = new ImageDeleteFormModel()
                {
                    Id = image.Key.ToString(),
                    ExistingImage = image.Value,
                    ToBeDeleted = false,
                };
                imageDeleteFormModels.Add(formModel);
            }

            return imageDeleteFormModels;
        }
    }
}
