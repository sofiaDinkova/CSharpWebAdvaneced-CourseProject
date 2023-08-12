namespace Blasco.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;

    using Web.ViewModels.Image;

    public interface IImageService
    {
        public byte[] GetImageBytesByEntityCorrespondingId(string entityId);

        public List<byte[]> GetAllImagesBytesByEntityCorrespondingId(string entityId);

        public Task InsertImagesAsync(List<IFormFile> files, string entityCorrespondingId);

        public Task DeleteProductImagesByEntityCorrespondingIdAsync(string id);

        public List<ImageDeleteFormModel> GetImagesToEditByEntityCorrespondingIdAsync(string id);

        public Task DeleteProductImageByImageId(string id);

        Task InsertImageAsync(IFormFile file, string entityCorrespondingId);
    }
}
