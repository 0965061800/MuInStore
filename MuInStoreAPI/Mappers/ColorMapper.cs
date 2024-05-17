using MuInShared.Color;
using MuInStoreAPI.Models;

namespace MuInStoreAPI.Mappers
{
	public static class ColorMapper
	{
		public static ColorDto ToColorDto(this Color color)
		{
			return new ColorDto
			{
				ColorId = color.ColorId,
				ColorName = color.ColorName,
			};
		}
	}
}
