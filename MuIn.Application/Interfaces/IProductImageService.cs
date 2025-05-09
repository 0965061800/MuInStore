﻿namespace MuIn.Application.Interfaces
{
	public interface IProductImageService
	{
		public Task<string> UploadImageAsync(byte[] fileContent, string fileName);
		public Task<string> DeleteImage(string imageName);
		public Task UpdateImageAsync(int productId, byte[]? fileContent, string? fileName);
	}
}
