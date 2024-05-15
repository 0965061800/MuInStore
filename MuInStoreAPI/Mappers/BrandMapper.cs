using MuInShared.Brands;
using MuInStoreAPI.Models;

namespace MuInStoreAPI.Mappers
{
    public static class BrandMapper
    {
        public static BrandDto ToBrandDto(this Brand brand)
        {
            return new BrandDto
            {
                BrandId = brand.BrandId,
                BrandName = brand.BrandName,
                Alias = brand.Alias,
                BrandImage = brand.BrandImage,
            };
        }
        public static Brand ToBrandFromRequest(this RequestBrandDto requestBrandDto)
        {
            return new Brand
            {
                BrandName = requestBrandDto.BrandName,
                BrandImage = requestBrandDto.BrandImage,
                Alias = requestBrandDto.Alias,
            };
        }
        public static Brand ToUpdateBrand(this RequestBrandDto requestBrandDto, Brand brand)
        {
            brand.BrandName = requestBrandDto.BrandName;
            brand.BrandImage = requestBrandDto.BrandImage;
            brand.Alias = requestBrandDto.Alias;
            return brand;
        }
    }
}
