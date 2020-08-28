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
	public static class SaveYAML
	{

		public static void Save<T>(T toSave, string FileName)
		{
			var serializer = new SerializerBuilder().Build();
			var yaml = serializer.Serialize(toSave);
			StringBuilder sbuilder = new StringBuilder(yaml);
			sbuilder.Insert(0, System.Environment.NewLine);
			sbuilder.Insert(0, "---");
			yaml = sbuilder.ToString();
			if (!Directory.Exists(Application.dataPath + "/YAML/"))
				Directory.CreateDirectory(Application.dataPath + "/YAML/");
			if (File.Exists(Application.dataPath + "/YAML/" + FileName + ".yaml"))
				File.WriteAllText(Application.dataPath + "/YAML/" + FileName + ".yaml", yaml);
			else
			{
				var fs = new FileStream(Application.dataPath + "/YAML/" + FileName + ".yaml", FileMode.Create);
				fs.Dispose();
				File.WriteAllText(Application.dataPath + "/YAML/" + FileName + ".yaml", yaml);
			}
		}
	}
}