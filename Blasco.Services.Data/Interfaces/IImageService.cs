using Blasco.Web.ViewModels.Image;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blasco.Services.Data.Interfaces
{
    public interface IImageService
    {
        public byte[] GetImageBytesByEntityCorrespondingId(string entityId);

        public List<byte[]> GetAllImagesBytesByEntityCorrespondingId(string entityId);

        public Task InsertImagesAsync(List<IFormFile> files, string entityCorrespondingId);

        public Task DeleteProductImagesByEntityCorrespondingIdAsync(string id);

        public List<ImageDeleteFormModel> GetImagesToEditByEntityCorrespondingIdAsync(string id);

        public Task DeleteProductImageByImageId(string id);
    }
}
