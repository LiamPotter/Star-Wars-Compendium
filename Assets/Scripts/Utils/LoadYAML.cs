using System.Collections;
using System.Collections.Generic;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.RepresentationModel;
using UnityEngine;
using System.IO;
using System.Text;
namespace SWars.Utils
{
	public static class LoadYAML
	{
		public static T Load <T>(string fileName)
		{
			var deserializer = new DeserializerBuilder().WithNamingConvention(new PascalCaseNamingConvention()).IgnoreUnmatchedProperties().Build();
			string fileString = File.ReadAllText(Application.dataPath + "/YAML/" + fileName+".yaml");
			T temp= deserializer.Deserialize<T>(fileString);
			return temp;
		}
	}
}
