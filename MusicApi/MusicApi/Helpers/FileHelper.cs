using Azure.Storage.Blobs;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MusicApi.Helpers
{
	public static class FileHelper
	{
		public static async Task<string> UploadImage(IFormFile file )
		{
            string connectionString = @"DefaultEndpointsProtocol=https;AccountName=musicappalbums;AccountKey=ZrymHHfdQMDAdT3poEN/N6GMBQ0TNczQxmeDrXCaldawQJHSHqbS7Z9rdCoWACIXmonyIHu7bj7j+AStEF2qNg==;EndpointSuffix=core.windows.net";
            string containerName = "songcontainer";

            BlobContainerClient blobContainerClient = new BlobContainerClient(connectionString, containerName);

            BlobClient blobClient = blobContainerClient.GetBlobClient(file.FileName);
            var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            memoryStream.Position = 0;
            await blobClient.UploadAsync(memoryStream);

            return blobClient.Uri.AbsoluteUri;
        }

        public static async Task<string> UploadAudio(IFormFile file)
        {
            string connectionString = @"DefaultEndpointsProtocol=https;AccountName=musicappalbums;AccountKey=ZrymHHfdQMDAdT3poEN/N6GMBQ0TNczQxmeDrXCaldawQJHSHqbS7Z9rdCoWACIXmonyIHu7bj7j+AStEF2qNg==;EndpointSuffix=core.windows.net";
            string containerName = "audiocontainer";

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

