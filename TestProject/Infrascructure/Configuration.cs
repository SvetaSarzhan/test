using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace TestProject.Infrascructure
{
	public static class Configuration
	{
		//for such variables can be used configurations files
		//but because we have only one environment we use properties 
		public static string SiteUrl = "https://translate.google.com.ua/";
		public static string Browser = "Chrome";
		public const string MobileUserAgent = "Mozilla/5.0 (iPhone; CPU iPhone OS 6_0 like Mac OS X) AppleWebKit/536.26 " +
											   "(KHTML, like Gecko) Version/6.0 Mobile/10A5376e Safari/8536.25";
		public const string browserLang = "de";
	}
}