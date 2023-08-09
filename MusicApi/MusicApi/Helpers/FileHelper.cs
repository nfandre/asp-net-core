using System;
using Azure.Storage.Blobs;
using MusicApi.Models;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MusicApi.Helpers
{
	public class FileHelper
	{
		public async Task<string> UploadImage(IFormFile file )
		{
            string connectionString = @"DefaultEndpointsProtocol=https;AccountName=musicstoragenfandre;AccountKey=p0OM2gMFTG0DyscO9SZHy66iqFDTA/hp4V6sRva67AIMI3l1rZjokwZv1B1v0ElRl4MFq8/vPQu/+AStI53zkg==;EndpointSuffix=core.windows.net";
            string containerName = "songcontainer";

            BlobContainerClient blobContainerClient = new BlobContainerClient(connectionString, containerName);

            BlobClient blobClient = blobContainerClient.GetBlobClient(file.FileName);
            var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            memoryStream.Position = 0;
            await blobClient.UploadAsync(memoryStream);

            return blobClient.Uri.AbsoluteUri;
        }
	}
}

