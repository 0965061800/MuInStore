namespace MuIn.Application.Interfaces
{
	public interface IProductImageService
	{
		public Task<string> UploadImageAsync(byte[] fileContent, string fileName);
		public Task<string> DeleteImage(string imageName);
	}
}
