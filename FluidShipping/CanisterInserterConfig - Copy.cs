using STRINGS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TUNING;
using UnityEngine;


//namespace StormShark.OniFluidShipping
//{
//	public class CanisterInserterConfig : IBuildingConfig
//	{
//		public const string ID = "StormShark.CanisterInserter";
//		static readonly string Name = "Canister Inserter";
//		static readonly string Description = "Canister Inserters allow contained gas to be inserted directly into a ventilation network.";
//		static readonly string Effect = "Loads " + UI.FormatAsLink("Gas", "ELEMENTS_GAS") + " canisters into " + UI.FormatAsLink("Pipes", "GASPIPING") + " for transport.\n\nMust be loaded by Duplicants.";

//		public override BuildingDef CreateBuildingDef()
//		{
//			string id = ID;
//			int width = 2;
//			int height = 2;
//			string anim = "rationbox_kanim";
//			int hitpoints = 10;
//			float construction_time = 10f;
//			float[] tieR4 = TUNING.BUILDINGS.CONSTRUCTION_MASS_KG.TIER4;
//			string[] rawMinerals = MATERIALS.RAW_MINERALS;
//			float melting_point = 1600f;
//			BuildLocationRule build_location_rule = BuildLocationRule.OnFloor;
//			EffectorValues none = NOISE_POLLUTION.NONE;
//			BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, tieR4, rawMinerals, melting_point, build_location_rule, TUNING.BUILDINGS.DECOR.BONUS.TIER0, none, 0.2f);
//			buildingDef.Overheatable = false;
//			buildingDef.Floodable = false;
//			buildingDef.AudioCategory = "Metal";
//			SoundEventVolumeCache.instance.AddVolume("rationbox_kanim", "RationBox_open", NOISE_POLLUTION.NOISY.TIER1);
//			SoundEventVolumeCache.instance.AddVolume("rationbox_kanim", "RationBox_close", NOISE_POLLUTION.NOISY.TIER1);
//			return buildingDef;
//		}

//		public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
//		{
//			Prioritizable.AddRef(go);
//			Storage storage = go.AddOrGet<Storage>();
//			storage.capacityKg = 150f;
//			storage.showInUI = true;
//			storage.showDescriptor = true;
//			storage.storageFilters = STORAGEFILTERS.FOOD;
//			storage.allowItemRemoval = true;
//			//storage.storageFullMargin = STORAGE.STORAGE_LOCKER_FILLED_MARGIN;
//			storage.fetchCategory = Storage.FetchCategory.GeneralStorage;
//			go.AddOrGet<TreeFilterable>();


//		}

//		public override void DoPostConfigureComplete(GameObject go)
//		{
//			//
//		}

//		public static void Setup()
//		{
//			Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ID.ToUpperInvariant()}.NAME", "<link=\"" + ID + "\">" + Name + "</link>");
//			Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ID.ToUpperInvariant()}.DESC", Description);
//			Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ID.ToUpperInvariant()}.EFFECT", Effect);


//			int categoryIndex = TUNING.BUILDINGS.PLANORDER.FindIndex(x => x.category == "HVAC");
//			(TUNING.BUILDINGS.PLANORDER[categoryIndex].data as IList<String>)?.Add(ID);

//			var TechGroup = new List<string>(Database.Techs.TECH_GROUPING["Distillation"]) { };
//			TechGroup.Add(ID);
//			Database.Techs.TECH_GROUPING["Distillation"] = TechGroup.ToArray();

//		}
//	}
//}
