using MuIn.Application.Interfaces;
using MuIn.Domain.SeedWork.InterfaceRepo;

namespace MuIn.Application.ProductService.Concrete
{
	public class ProductImageServices : IProductImageService
	{
		private IProductRepository _productRepo;
		public ProductImageServices(IProductRepository productRepository)
		{
			_productRepo = productRepository;
		}
		private readonly string _storagePath = Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles");
		public Task<string> DeleteImage(string imageName)
		{
			var filePath = Path.Combine(_storagePath, "products", imageName);
			if (File.Exists(filePath))
			{
				File.Delete(filePath);
			}
			return Task.FromResult(imageName);
		}

		public async Task<string> UploadImageAsync(byte[] fileContent, string fileName)
		{
			var uploadFolderPath = Path.Combine(_storagePath, "products");
			if (!Directory.Exists(uploadFolderPath))
			{
				Directory.CreateDirectory(uploadFolderPath);
			}
			string newFileName = Guid.NewGuid().ToString() + Path.GetExtension(fileName);
			var filePath = Path.Combine(uploadFolderPath, newFileName);
			await File.WriteAllBytesAsync(filePath, fileContent);
			return newFileName;
		}

		public async Task UpdateImageAsync(int productId, byte[]? fileContent, string? fileName)
		{
			var databaseImageName = await _productRepo.GetProductImage(productId);
			string? newImageName = null;
			if (fileContent is not null && !string.IsNullOrEmpty(databaseImageName))
			{
				await DeleteImage(databaseImageName);
				newImageName = await UploadImageAsync(fileContent, fileName);
			}
			if (fileContent is null && !string.IsNullOrEmpty(databaseImageName))
			{
				await DeleteImage(databaseImageName);
				newImageName = "";
			}
			if (fileContent is not null && string.IsNullOrEmpty(databaseImageName))
			{
				newImageName = await UploadImageAsync(fileContent, fileName);
			}
			if (fileContent is null && string.IsNullOrEmpty(databaseImageName))
			{
				//do nothing
			}
			var result = await _productRepo.UpdateImageAsync(productId, newImageName);
			if (result is null) throw new Exception("Update failed");
			else
			{
				await _productRepo.SaveChange();
			}
		}
	}
}
