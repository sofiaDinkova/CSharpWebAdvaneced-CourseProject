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
    }
}
