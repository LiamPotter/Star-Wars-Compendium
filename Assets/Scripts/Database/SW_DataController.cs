using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.RepresentationModel;
using System.IO;
using SWars.Utils;
namespace SWars.Data
{
	public class SW_DataController : MonoBehaviour
	{
		public enum dataType
		{
			None,
			Ability,
			AdRule,
			Adversary,
			AdversaryArmor,
			AdversaryGear,
			AdversaryWeapon,
			Armor,
			Attachment,
			Book,
			Creature,
			Gear,
			Quality,
			Skill,
			Species,
			Starship,
			Talent,
			VehicleAttachment,
			Vehicle,
			VehicleWeapon,
			Weapon
		}

        #region Data Classes
        private Ability Abilities;
		private AdRule AdRules;
		private Adversary Adversaries;
		private AdversaryArmor AdversaryArmors;
		private AdversaryGear AdversaryGear;
		private AdversaryWeapon AdversaryWeapons;
		private Armor Armors;
		private Attachment Attachments;
		private Book Books;
		private Creature Creatures;
		private CreatureWeapon CreatureWeapons;
		private Gear Gear;
		private Quality Qualities;
		private Skill Skills;
		private Species Species;
		private Starship Starships;
		private Talent Talents;
		private Vehicle Vehicles;
		private VehicleAttachment VehicleAttachments;
		private VehicleWeapon VehicleWeapons;
		private Weapon Weapons;
		#endregion

		void Start()
		{
			Load();			
		}
		protected void Load()
		{
			Abilities = LoadYAML.Load<Ability>("Abilities");
			Debug.Log(Abilities.Items.Count);
			Debug.Log(Abilities.Items[0].Name);
			DirectoryInfo dir = new DirectoryInfo(Application.dataPath + "/YAML");
			var deserializer = new DeserializerBuilder().WithNamingConvention(new CamelCaseNamingConvention()).IgnoreUnmatchedProperties().Build();
			var InputFiles = dir.GetFiles("*.yaml");
			foreach (FileInfo f in InputFiles)
			{
				string Input = File.ReadAllText(Application.dataPath + "/YAML/" + f.Name);
				StringReader sReader = new StringReader(Input);
				Debug.Log(Input);
				switch (f.Name)
				{				
					case "Additional-Rules.yaml":
						AdRules = deserializer.Deserialize<AdRule>(sReader);
						break;
					case "Adversaries.yaml":
						Adversaries = deserializer.Deserialize<Adversary>(sReader);
						break;
					case "Adversaries-Armor.yaml":
						AdversaryArmors = deserializer.Deserialize<AdversaryArmor>(sReader);
						break;
					case "Adversaries-Gear.yaml":
						AdversaryGear = deserializer.Deserialize<AdversaryGear>(sReader);
						break;
					case "Adversaries-Weapon.yaml":
						AdversaryWeapons = deserializer.Deserialize<AdversaryWeapon>(sReader);
						break;
					case "Armor.yaml":
						Armors = deserializer.Deserialize<Armor>(sReader);
						break;
					case "Attachments.yaml":
						Attachments = deserializer.Deserialize<Attachment>(sReader);
						break;
					case "Books.yaml":
						Books = deserializer.Deserialize<Book>(sReader);
						break;
					case "Creatures.yaml":
						Creatures = deserializer.Deserialize<Creature>(sReader);
						break;
					case "Creatures-Weapons.yaml":
						CreatureWeapons = deserializer.Deserialize<CreatureWeapon>(sReader);
						break;
					case "Gear.yaml":
						Gear = deserializer.Deserialize<Gear>(sReader);
						break;
					case "Qualities.yaml":
						Qualities = deserializer.Deserialize<Quality>(sReader);
						break;
					case "Skills.yaml":
						Skills = deserializer.Deserialize<Skill>(sReader);
						break;
					case "Species.yaml":
						Species = deserializer.Deserialize<Species>(sReader);
						break;
					case "Starships.yaml":
						Starships = deserializer.Deserialize<Starship>(sReader);
						break;
					case "Talents.yaml":
						Talents = deserializer.Deserialize<Talent>(sReader);
						break;
					case "Vehicle-Attachments.yaml":
						VehicleAttachments = deserializer.Deserialize<VehicleAttachment>(sReader);
						break;
					case "Vehicles.yaml":
						Vehicles = deserializer.Deserialize<Vehicle>(sReader);
						break;
					case "Vehicles-Weapons.yaml":
						VehicleWeapons = deserializer.Deserialize<VehicleWeapon>(sReader);
						break;
					case "Weapons.yaml":
						Weapons = deserializer.Deserialize<Weapon>(sReader);
						break;
					default:
						break;
				}
			}
		}
	}
}