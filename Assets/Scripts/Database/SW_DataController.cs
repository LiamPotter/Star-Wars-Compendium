using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.RepresentationModel;
using System.IO;
using SWars.Utils;
using System;
using SWars.Tables;

namespace SWars.Data
{
	public class SW_DataController : MonoBehaviour
	{
		public ExtractBaseYAML extractBase;
		public SW_Table_Overlord overlord;
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
	
		public bool Load()
		{
			Abilities = LoadYAML.Load<Ability>("Abilities");
			AdRules = LoadYAML.Load<AdRule>("Additional-Rules");
			Adversaries = LoadYAML.Load<Adversary>("Adversaries");
			AdversaryArmors = LoadYAML.Load<AdversaryArmor>("Adversaries-Armors");
			AdversaryGear = LoadYAML.Load<AdversaryGear>("Adversaries-Gear");
			AdversaryWeapons = LoadYAML.Load<AdversaryWeapon>("Adversaries-Weapons");
			Armors = LoadYAML.Load<Armor>("Armor");
			Attachments = LoadYAML.Load<Attachment>("Attachments");
			Books = LoadYAML.Load<Book>("Books");
			Creatures = LoadYAML.Load<Creature>("Creatures");
			CreatureWeapons = LoadYAML.Load<CreatureWeapon>("Creatures-Weapons");
			Gear = LoadYAML.Load<Gear>("Gear");
			Qualities = LoadYAML.Load<Quality>("Qualities");
			Skills = LoadYAML.Load<Skill>("Skills");
			Species = LoadYAML.Load<Species>("Species");
			Starships = LoadYAML.Load<Starship>("Starships");
			Talents = LoadYAML.Load<Talent>("Talents");
			VehicleAttachments = LoadYAML.Load<VehicleAttachment>("Vehicle-Attachments");
			Vehicles = LoadYAML.Load<Vehicle>("Vehicles");
			VehicleWeapons = LoadYAML.Load<VehicleWeapon>("Vehicles-Weapons");
			Weapons = LoadYAML.Load<Weapon>("Weapons");
			overlord.PopulateAllTables();
			return true;
		}
		
		public object GetDataClass(dataType type)
		{
			switch (type)
			{
				case dataType.None:
					return null;
				case dataType.Ability:
					return Abilities;
				case dataType.AdRule:
					return AdRules;
				case dataType.Adversary:
					return Adversaries;
				case dataType.AdversaryArmor:
					return AdversaryArmors;
				case dataType.AdversaryGear:
					return AdversaryGear;
				case dataType.AdversaryWeapon:
					return AdversaryWeapons;
				case dataType.Armor:
					return Armors;
				case dataType.Attachment:
					return Attachments;
				case dataType.Book:
					return Books;
				case dataType.Creature:
					return Creatures;
				case dataType.Gear:
					return Gear;
				case dataType.Quality:
					return Qualities;
				case dataType.Skill:
					return Skills;
				case dataType.Species:
					return Species;
				case dataType.Starship:
					return Starships;
				case dataType.Talent:
					return Talents;
				case dataType.VehicleAttachment:
					return VehicleAttachments;
				case dataType.Vehicle:
					return Vehicles;
				case dataType.VehicleWeapon:
					return VehicleWeapons;
				case dataType.Weapon:
					return Weapons;
				default:
					return null;
			}
		}

		public string BookFromIndex(string index)
		{
			char[] divider = new char[]{ ':', ','};
			string[] id = index.Split(divider,StringSplitOptions.None);
			
			string builtName = "";
			for (int i = 0; i < Books.Items.Count; i++)
			{
				for (int j = 0; j < id.Length; j++)
				{
					id[j] = id[j].Trim();
					if (Books.Items[i].GeneratedId == id[j])
					{
						//Debug.Log("Builtname before=" + builtName);
						builtName = builtName + Books.Items[i].Name + ":" + id[j + 1] +(j>=id.Length-2?" ":", ");
					}
				}
			
			}
			return builtName;
		}
	}
}