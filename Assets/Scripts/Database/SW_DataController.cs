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
        public Ability Abilities;
		public AdRule AdRules;
		public Adversary Adversaries;
		public AdversaryArmor AdversaryArmors;
		public AdversaryGear AdversaryGear;
		public AdversaryWeapon AdversaryWeapons;
		public Armor Armors;
		public Attachment Attachments;
		public Book Books;
		public Creature Creatures;
		public CreatureWeapon CreatureWeapons;
		public Gear Gear;
		public Quality Qualities;
		public Skill Skills;
		public Species Species;
		public Starship Starships;
		public Talent Talents;
		public Vehicle Vehicles;
		public VehicleAttachment VehicleAttachments;
		public VehicleWeapon VehicleWeapons;
		public Weapon Weapons;
		#endregion

		public bool Loaded = false;
		void Start()
		{
			Loaded=Load();		
			
		}
		protected bool Load()
		{
			Abilities = LoadYAML.Load<Ability>("Abilities");
			Debug.Log(Abilities.Items.Count);
			Debug.Log(Abilities.Items[0].Name);	
			Books = LoadYAML.Load<Book>("Books");

			DirectoryInfo dir = new DirectoryInfo(Application.dataPath + "/YAML");
			var deserializer = new DeserializerBuilder().WithNamingConvention(new CamelCaseNamingConvention()).IgnoreUnmatchedProperties().Build();
			var InputFiles = dir.GetFiles("*.yaml");
			foreach (FileInfo f in InputFiles)
			{
				string Input = File.ReadAllText(Application.dataPath + "/YAML/" + f.Name);
				StringReader sReader = new StringReader(Input);
				//Debug.Log(Input);
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
			return true;
		}
		
	}
}