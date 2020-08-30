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
			AdRules = LoadYAML.Load<AdRule>("Additional-Rules");
			Adversaries = LoadYAML.Load<Adversary>("Adversaries");
			AdversaryArmors = LoadYAML.Load<AdversaryArmor>("Adversaries-Armor");
			AdversaryGear = LoadYAML.Load<AdversaryGear>("Adversaries-Gear");
			AdversaryWeapons = LoadYAML.Load<AdversaryWeapon>("Adversaries-Weapon");
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
			return true;
		}
		
	}
}