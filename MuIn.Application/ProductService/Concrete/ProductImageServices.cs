using MuIn.Application.Interfaces;

namespace MuIn.Application.ProductService.Concrete
{
	public class ProductImageServices : IProductImageService
	{
		private readonly string _storagePath = Path.Combine(Directory.GetCurrentDirectory(), "assets");
		public Task<string> DeleteImage(string imageName)
		{
			var filePath = Path.Combine(_storagePath, "images", "products", imageName);
			if (File.Exists(filePath))
			{
				File.Delete(filePath);
			}
			return Task.FromResult(imageName);
		}

		public async Task<string> UploadImageAsync(byte[] fileContent, string fileName)
		{
			var uploadFolderPath = Path.Combine(_storagePath, "images", "products");
			if (!Directory.Exists(uploadFolderPath))
			{
				Directory.CreateDirectory(uploadFolderPath);
			}
			string newFileName = Guid.NewGuid().ToString() + Path.GetExtension(fileName);
			var filePath = Path.Combine(uploadFolderPath, newFileName);
			await File.WriteAllBytesAsync(filePath, fileContent);
			return newFileName;
		}
	}
}
