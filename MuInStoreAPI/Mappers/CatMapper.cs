using MuInShared.Category;
using MuInStoreAPI.Models;

namespace MuInStoreAPI.Mappers
{
    public static class CatMapper
    {
        public static CategoryDto ToCategoryDto(this Category category)
        {
            return new CategoryDto
            {
                CatId = category.CatId,
                CatImage = category.CatImage,
                ImageName = category.ImageName,
                Description = category.Description,
                CatName = category.CatName,
                Alias = category.Alias,
                SubCategoryDto = category.Subcategories.Select(x => x.ToCategoryDto()).ToList(),
            };
        }
        public static CategoryFullDto ToCategoryFullDto(this Category category, List<Product> allProducts)
        {
            return new CategoryFullDto
            {
                CatId = category.CatId,
                CatImage = category.CatImage,
                ImageName = category.ImageName,
                CatName = category.CatName,
                Alias = category.Alias,
                Description = category.Description,
                //AllProducts = allProducts.Select(p => p.ToProductDto()).ToList(),
                SubCategories = category.Subcategories.Select(c => c.ToCategoryDto()).ToList(),
            };
        }
        public static Category ToCategoryFromRequest(this RequestCatDto requestCatDto)
        {
            return new Category
            {
                CatName = requestCatDto.CatName,
                Alias = requestCatDto.Alias,
                CatImage = requestCatDto.CatImage,
                ImageName = requestCatDto.ImageName,
                ParentCatId = requestCatDto.ParentCatId,
                Description = requestCatDto.Description
            };
        }

        public static Category ToUpdateCategory(this RequestCatDto updateCatDto, Category category)
        {
            category.CatName = updateCatDto.CatName;
            category.Alias = updateCatDto.Alias;
            category.CatImage = updateCatDto.CatImage;
            category.ImageName = updateCatDto.ImageName;
            category.ParentCatId = updateCatDto.ParentCatId;
            category.Description = updateCatDto.Description;
            return category;
        }
    }
}
