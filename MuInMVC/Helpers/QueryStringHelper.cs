﻿using System.Web;

namespace MuInMVC.Helpers
{
	public static class QueryStringHelper
	{
		public static string ToQueryString(object obj)
		{
			var properties = from p in obj.GetType().GetProperties()
							 where p.GetValue(obj, null) != null
							 select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(obj, null).ToString());

			return "?" + string.Join("&", properties.ToArray());
		}
	}
}
