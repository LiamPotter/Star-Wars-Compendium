using System.Collections;
using System.Collections.Generic;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.RepresentationModel;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using SWars.Data;
using System.Text;

public class ExtractBaseYAML : MonoBehaviour {

	public string InputFolder;

	public FileInfo[] InputFiles;

	[HideInInspector]
	public List<string[]> InputLines;

	[HideInInspector]
	public List<string> InputAllText;

	[HideInInspector]
	public string Input;


	private StringReader sReader;

	private DeserializerBuilder dBuilder;

	private Deserializer deserializer;

	private YamlStream yStream;

	void Start () 
	{

		Extract();
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	public void Extract()
	{
		InputLines = new List<string[]>();
		InputAllText = new List<string>();
		DirectoryInfo dir = new DirectoryInfo(Application.dataPath + InputFolder);
		deserializer = new DeserializerBuilder().WithNamingConvention(new CamelCaseNamingConvention()).IgnoreUnmatchedProperties().Build();
		InputFiles = dir.GetFiles("*.yaml");
		foreach (FileInfo f in InputFiles)
		{
			//Debug.Log(Application.dataPath + InputFolder + "/" + f.Name);
			Input = File.ReadAllText(Application.dataPath + InputFolder + "/" + f.Name);
			InputAllText.Add(Input);

			sReader = new StringReader(Input);
			//Debug.Log(f.Name);
			switch (f.Name)
			{
				case "abilities.yaml":
					var des = deserializer.Deserialize<Ability>(sReader);
					Debug.Log(des.Items[0].Name);
					SaveToYAML(des, "Abilities");
					break;
				case "additional-rules.yaml":
					var adrule = deserializer.Deserialize<AdRule>(sReader);
					SaveToYAML(adrule, "Additional-Rules");
					break;
				case "adversaries.yaml":
					var adverse = deserializer.Deserialize<Adversary>(sReader);
					SaveToYAML(adverse, "Adversaries");
					break;
				case "adversaries-armor.yaml":
					var adversea = deserializer.Deserialize<AdversaryArmor>(sReader);
					SaveToYAML(adversea, "Adversaries-Armors");
					break;
				case "adversaries-gear.yaml":
					var adverseg = deserializer.Deserialize<AdversaryGear>(sReader);
					SaveToYAML(adverseg, "Adversaries-Gear");
					break;
				case "adversaries-weapons.yaml":
					var adversew = deserializer.Deserialize<AdversaryWeapon>(sReader);
					SaveToYAML(adversew, "Adversaries-Weapons");
					break;
				case "armor.yaml":
					var armor = deserializer.Deserialize<Armor>(sReader);
					SaveToYAML(armor, "Armor");
					break;
				case "attachments.yaml":
					var attach = deserializer.Deserialize<Attachment>(sReader);
					SaveToYAML(attach, "Attachments");
					break;
				case "books.yaml":
					var book = deserializer.Deserialize<Book>(sReader);
					SaveToYAML(book, "Books");
					break;
				case "creatures.yaml":
					var crea = deserializer.Deserialize<Creature>(sReader);
					SaveToYAML(crea, "Creatures");
					break;
				case "creatures-weapons.yaml":
					var creaw = deserializer.Deserialize<CreatureWeapon>(sReader);
					SaveToYAML(creaw, "Creatures-Weapons");
					break;
				case "gear.yaml":
					var gear = deserializer.Deserialize<Gear>(sReader);
					SaveToYAML(gear, "Gear");
					break;
				case "qualities.yaml":
					var qual = deserializer.Deserialize<Quality>(sReader);
					SaveToYAML(qual, "Qualities");
					break;
				case "skills.yaml":
					var skill = deserializer.Deserialize<Skill>(sReader);
					SaveToYAML(skill, "Skills");
					break;
				case "species.yaml":
					var spec = deserializer.Deserialize<Species>(sReader);
					SaveToYAML(spec, "Species");
					break;
				case "starships.yaml":
					var stars = deserializer.Deserialize<Starship>(sReader);					
					SaveToYAML(stars, "Starships");
					break;
				case "talents.yaml":
					var tal = deserializer.Deserialize<Talent>(sReader);
					SaveToYAML(tal, "Talents");
					break;
				case "vehicle-attachments.yaml":
					var veha = deserializer.Deserialize<VehicleAttachment>(sReader);
					SaveToYAML(veha, "Vehicle-Attachments");
					break;
				case "vehicles.yaml":
					var veh = deserializer.Deserialize<Vehicle>(sReader);
					SaveToYAML(veh, "Vehicles");
					break;
				case "vehicle-weapons.yaml":
					var vehw = deserializer.Deserialize<VehicleWeapon>(sReader);
					SaveToYAML(vehw, "Vehicles-Weapons");
					break;
				case "weapons.yaml":
					var wep = deserializer.Deserialize<Weapon>(sReader);
					SaveToYAML(wep, "Weapons");
					break;
				default:
					break;
			}


		}

	}
	public void SaveToYAML<T>(T toSave, string FileName)
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
			var fs = new FileStream(Application.dataPath + "/YAML/" + FileName + ".yaml",FileMode.Create);
			fs.Dispose();
			File.WriteAllText(Application.dataPath + "/YAML/" + FileName + ".yaml", yaml);
		}
	}
}
