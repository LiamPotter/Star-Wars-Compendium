using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngineInternal;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace SWars.Data
{

	public class DataClasses
	{

	}

	

	public class DataItem
	{
		[DefaultValue("")]
		public string Index { get; set; }
		public string GeneratedId { get; set; }

		[DefaultValue(0)]
		public SW_DataController.dataType DataType;
	}

	public class Ability
	{

		public List<AbilityItem> Items { get; set; }
		//public List<AbilityItem> Items { get; set; }
	}

	public class AbilityItem: DataItem
	{
		[YamlMember(Alias = "name", ApplyNamingConventions = false, ScalarStyle = YamlDotNet.Core.ScalarStyle.Plain)]
		public string Name { get; set; }
		public string Description { get; set; }
	}

	public class AdRule
	{
		public List<AdRuleItem> Items { get; set; }
	}
	public class AdRuleItem : DataItem
	{
		[YamlMember(Alias = "name", ApplyNamingConventions = false, ScalarStyle = YamlDotNet.Core.ScalarStyle.Plain)]
		public string Name { get; set; }
		public string Description { get; set; }

	}
	public class Adversary
	{
		public List<AdversaryItem> Items { get; set; }

	}
	public class AdversaryItem : DataItem
	{
		[YamlMember(Alias = "name", ApplyNamingConventions = false, ScalarStyle = YamlDotNet.Core.ScalarStyle.Plain)]
		public string Name { get; set; }
		public string Level { get; set; }
		[DefaultValue(0)]
		public int Defense { get; set; }
		[DefaultValue(0)]
		public int Soak { get; set; }
		[DefaultValue(0)]
		[YamlMember(Alias = "wt", ApplyNamingConventions = false, ScalarStyle = YamlDotNet.Core.ScalarStyle.Plain)]
		public int WT { get; set; }
		[DefaultValue(0)]
		[YamlMember(Alias = "st", ApplyNamingConventions = false, ScalarStyle = YamlDotNet.Core.ScalarStyle.Plain)]
		public int ST { get; set; }
		[DefaultValue("")]
		[YamlMember(Alias = "mr", ApplyNamingConventions = false, ScalarStyle = YamlDotNet.Core.ScalarStyle.Plain)]
		public string MR { get; set; }
		[DefaultValue(0)]
		public int Brawn { get; set; }
		[DefaultValue(0)]
		public int Agility { get; set; }
		[DefaultValue(0)]
		public int Intellect { get; set; }
		[DefaultValue(0)]
		public int Cunning { get; set; }
		[DefaultValue(0)]
		public int Willpower { get; set; }
		[DefaultValue(0)]
		public int Presence { get; set; }
		[DefaultValue("")]
		public string Skills { get; set; }
		[DefaultValue("")]
		public string Talents { get; set; }
		[DefaultValue("")]
		public string Abilities { get; set; }
		[DefaultValue("")]
		public string Equipment { get; set; }
		[DefaultValue("")]
		public string Notes { get; set; }
	}
	public class AdversaryArmor
	{
		public List<AdversaryArmorItem> Items { get; set; }
	}
	public class AdversaryArmorItem : DataItem
	{
		[YamlMember(Alias = "name", ApplyNamingConventions = false, ScalarStyle = YamlDotNet.Core.ScalarStyle.Plain)]
		public string Name { get; set; }
		public int Defense { get; set; }
		public int Soak { get; set; }
	}
	public class AdversaryGear
	{
		public List<AdversaryGearItem> Items { get; set; }
	}
	public class AdversaryGearItem : DataItem
	{
		[YamlMember(Alias = "name", ApplyNamingConventions = false, ScalarStyle = YamlDotNet.Core.ScalarStyle.Plain)]
		public string Name { get; set; }
	}
	public class AdversaryWeapon
	{
		public List<AdversaryWeaponItem> Items { get; set; }
	}
	public class AdversaryWeaponItem : DataItem
	{
		[YamlMember(Alias = "name", ApplyNamingConventions = false, ScalarStyle = YamlDotNet.Core.ScalarStyle.Plain)]
		public string Name { get; set; }
		public string Skill { get; set; }
		public int Damage { get; set; }
		public int Crit { get; set; }
		public string Range { get; set; }
		public string Special { get; set; }
	}
	public class Armor
	{
		public List<ArmorItem> Items { get; set; }
	}
	public class ArmorItem : DataItem
	{
		[YamlMember(Alias = "name", ApplyNamingConventions = false, ScalarStyle = YamlDotNet.Core.ScalarStyle.Plain)]
		public string Name { get; set; }
		public int Defense { get; set; }
		public int Soak { get; set; }
		public int Price { get; set; }
		public string Encumbrance { get; set; }
		public int HP { get; set; }
		public int Rarity { get; set; }
	}
	public class Attachment
	{
		public List<AttachmentItem> Items { get; set; }
	}
	public class AttachmentItem : DataItem
	{
		[YamlMember(Alias = "category", ApplyNamingConventions = false, ScalarStyle = YamlDotNet.Core.ScalarStyle.Plain)]
		public string Category { get; set; }
		public string Name { get; set; }
		public int Price { get; set; }
		public string Restricted { get; set; }
		public string Encumbrance { get; set; }
		public int HP { get; set; }
		public int Rarity { get; set; }
	}
	public class Book 
	{
		public List<BookItem> Items { get; set; }
	}
	public class BookItem
	{
		[YamlMember(Alias = "name", ApplyNamingConventions = false, ScalarStyle = YamlDotNet.Core.ScalarStyle.Plain)]
		public string Name { get; set; }
		public string System { get; set; }
		public string Key { get; set; }
		public string Initials { get; set; }
		public string GeneratedId { get; set; }
	}
	public class Creature
	{
		public List<CreatureItem> Items { get; set; }
	}
	public class CreatureItem : DataItem
	{
		[YamlMember(Alias = "name", ApplyNamingConventions = false, ScalarStyle = YamlDotNet.Core.ScalarStyle.Plain)]
		public string Name { get; set; }
		public string Level { get; set; }
		public string Skills { get; set; }
		public string Talents { get; set; }
		public string Abilities { get; set; }
		public string Equipment { get; set; }
	}
	public class CreatureWeapon
	{
		public List<CreatureWeaponItem> Items { get; set; }
	}
	public class CreatureWeaponItem : DataItem
	{
		[YamlMember(Alias = "name", ApplyNamingConventions = false, ScalarStyle = YamlDotNet.Core.ScalarStyle.Plain)]
		public string Name { get; set; }
		public string Skill { get; set; }
		public int Damage { get; set; }
		public int Crit { get; set; }
		public string Range { get; set; }
		public string Special { get; set; }
	}
	public class Gear
	{
		public List<GearItem> Items { get; set; }
	}
	public class GearItem : DataItem
	{
		[YamlMember(Alias = "category", ApplyNamingConventions = false, ScalarStyle = YamlDotNet.Core.ScalarStyle.Plain)]
		public string Category { get; set; }
		public string Name { get; set; }
		public int Price { get; set; }
		public string Restricted { get; set; }
		public string Encumbrance { get; set; }
		public int Rarity { get; set; }
		public string Notes { get; set; }
	}
	public class Quality
	{
		public List<QualityItem> Items { get; set; }
	}
	public class QualityItem : DataItem
	{
		[YamlMember(Alias = "name", ApplyNamingConventions = false, ScalarStyle = YamlDotNet.Core.ScalarStyle.Plain)]
		public string Name { get; set; }
		public string Active { get; set; }
		public bool Ranked { get; set; }
		public string Effect { get; set; }

	}
	public class Skill
	{
		public List<SkillItem> Items { get; set; }
	}
	public class SkillItem : DataItem
	{
		[YamlMember(Alias = "name", ApplyNamingConventions = false, ScalarStyle = YamlDotNet.Core.ScalarStyle.Plain)]
		public string Name { get; set; }
		public string Characteristic { get; set; }
		public string Type { get; set; }
	}
	public class Species
	{
		public List<SpeciesItem> Items { get; set; }
	}
	public class SpeciesItem : DataItem
	{
		[YamlMember(Alias = "name", ApplyNamingConventions = false, ScalarStyle = YamlDotNet.Core.ScalarStyle.Plain)]
		public string Name { get; set; }
		[DefaultValue(0)]
		[YamlMember(Alias = "wt", ApplyNamingConventions = false, ScalarStyle = YamlDotNet.Core.ScalarStyle.Plain)]
		public string WT { get; set; }
		[DefaultValue(0)]
		[YamlMember(Alias = "st", ApplyNamingConventions = false, ScalarStyle = YamlDotNet.Core.ScalarStyle.Plain)]
		public string ST { get; set; }
		[DefaultValue(0)]
		public int Brawn { get; set; }
		[DefaultValue(0)]
		public int Agility { get; set; }
		[DefaultValue(0)]
		public int Intellect { get; set; }
		[DefaultValue(0)]
		public int Cunning { get; set; }
		[DefaultValue(0)]
		public int Willpower { get; set; }
		[DefaultValue(0)]
		public int Presence { get; set; }
		[DefaultValue(0)]
		[YamlMember(Alias = "xp", ApplyNamingConventions = false, ScalarStyle = YamlDotNet.Core.ScalarStyle.Plain)]
		public int XP { get; set; }
		[DefaultValue("")]
		public string SpecialAbilities { get; set; }
		[DefaultValue("")]
		public string Notes { get; set; }

		[YamlMember(Alias = "index", ApplyNamingConventions = false, ScalarStyle = YamlDotNet.Core.ScalarStyle.Folded)]
		public new string Index { get; set; }

	}
	public class Starship
	{
		public List<StarshipItem> Items { get; set; }
	}
	public class StarshipItem : DataItem
	{
		[YamlMember(Alias = "category", ApplyNamingConventions = false, ScalarStyle = YamlDotNet.Core.ScalarStyle.Plain)]
		public string Category { get; set; }
		public string Name { get; set; }
		public int Silhouette { get; set; }
		public int Speed { get; set; }
		public int Handling { get; set; }
		public string Model { get; set; }
		public string Manufacturer { get; set; }
		public int Crew { get; set; }
		public int Encumbrance { get; set; }
		public int Passengers { get; set; }
		public int Price { get; set; }
		public string Restricted { get; set; }
		public int Rarity { get; set; }
		public int HP { get; set; }
		public int Weapons { get; set; }
		[DefaultValue(0)]
		public int Armor { get; set; }
		[DefaultValue(0)]
		[YamlMember(Alias = "htt", ApplyNamingConventions = false, ScalarStyle = YamlDotNet.Core.ScalarStyle.Plain)]
		public int HTT { get; set; }
		[DefaultValue(0)]
		[YamlMember(Alias = "stt", ApplyNamingConventions = false, ScalarStyle = YamlDotNet.Core.ScalarStyle.Plain)]
		public int STT { get; set; }
		[DefaultValue("")]
		public string Defense { get; set; }
		[DefaultValue("")]
		public string Sensor { get; set; }
		[DefaultValue("")]
		public string Hyperdrive { get; set; }
		[DefaultValue("")]
		public string Navicomputer { get; set; }
		[DefaultValue("")]
		public string AdditionalRules { get; set; }
		[DefaultValue("")]
		public string Notes { get; set; }

	}
	public class Talent
	{
		public List<TalentItem> Items { get; set; }
	}
	public class TalentItem : DataItem
	{
		[YamlMember(Alias = "name", ApplyNamingConventions = false, ScalarStyle = YamlDotNet.Core.ScalarStyle.Plain)]
		public string Name { get; set; }
		public string Activation { get; set; }
		public bool Ranked { get; set; }
		public bool ForceSensitive { get; set; }

	}
	public class VehicleAttachment
	{
		public List<VehicleAttachmentItem> Items { get; set; }
	}
	public class VehicleAttachmentItem
	{
		[YamlMember(Alias = "name", ApplyNamingConventions = false, ScalarStyle = YamlDotNet.Core.ScalarStyle.Plain)]
		public string Name { get; set; }
		public int Price { get; set; }
		public bool Restricted { get; set; }
		public int HP { get; set; }
		public int Rarity { get; set; }

	}
	public class Vehicle
	{
		public List<VehicleItem> Items { get; set; }
	}
	public class VehicleItem : DataItem
	{
		[YamlMember(Alias = "category", ApplyNamingConventions = false, ScalarStyle = YamlDotNet.Core.ScalarStyle.Plain)]
		public string Category { get; set; }
		public string Name { get; set; }
		public int Silhouette { get; set; }
		public int Speed { get; set; }
		public int Handling { get; set; }
		public string Model { get; set; }
		public string Manufacturer { get; set; }
		public int Crew { get; set; }
		public int Encumbrance { get; set; }
		public int Passengers { get; set; }
		public int Price { get; set; }
		public string Restricted { get; set; }
		public int Rarity { get; set; }
		public int HP { get; set; }
		public int Weapons { get; set; }
		public int Armor { get; set; }
		[DefaultValue(0)]
		[YamlMember(Alias = "htt", ApplyNamingConventions = false, ScalarStyle = YamlDotNet.Core.ScalarStyle.Plain)]
		public int HTT { get; set; }
		[DefaultValue(0)]
		[YamlMember(Alias = "stt", ApplyNamingConventions = false, ScalarStyle = YamlDotNet.Core.ScalarStyle.Plain)]
		public int STT { get; set; }
		[DefaultValue("")]
		public string Defense { get; set; }
		[DefaultValue("")]
		public string Sensor { get; set; }
		[DefaultValue("")]

		public string Notes { get; set; }

	}
	public class VehicleWeapon
	{
		public List<VehicleWeaponItem> Items { get; set; }
	}
	public class VehicleWeaponItem : DataItem
	{
		[YamlMember(Alias = "category", ApplyNamingConventions = false, ScalarStyle = YamlDotNet.Core.ScalarStyle.Plain)]
		public string Category { get; set; }
		public string Name { get; set; }
		public string Range { get; set; }
		public int Damage { get; set; }
		public int Crit { get; set; }
		public int Price { get; set; }
		public bool Restricted { get; set; }
		public int Rarity { get; set; }
		public string Qualities { get; set; }
		public string CompatibleSilhouette { get; set; }
		public string Notes { get; set; }
	}
	public class Weapon
	{
		public List<WeaponItem> Items { get; set; }
	}
	public class WeaponItem : DataItem
	{
		[YamlMember(Alias = "category", ApplyNamingConventions = false, ScalarStyle = YamlDotNet.Core.ScalarStyle.Plain)]
		public string Category { get; set; }
		public string Name { get; set; }
		public string Skill { get; set; }
		public int Damage { get; set; }
		public int Crit { get; set; }
		public string Range { get; set; }
		public string Encumbrance { get; set; }
		public int HP { get; set; }
		public int Price { get; set; }
		public bool Restricted { get; set; }
		public int Rarity { get; set; }
		public string Special { get; set; }
	}
}
