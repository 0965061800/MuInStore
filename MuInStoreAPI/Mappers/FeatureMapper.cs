using MuInShared.Feature;
using MuInStoreAPI.Models;

namespace MuInStoreAPI.Mappers
{
	public static class FeatureMapper
	{
		public static FeatureDto ToFeatureDto(this Feature feature)
		{
			return new FeatureDto
			{
				FeatureId = feature.FeatureId,
				FeatureName = feature.FeatureName,
				Alias = feature.Alias,
			};
		}
	}
}
