using STRINGS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TUNING;
using UnityEngine;


namespace StormShark.OniFluidShipping
{
	//public class CanisterInserterConfig : IBuildingConfig
	//{
	//	public const string ID = "StormShark.CanisterInserter";
	//	static readonly string Name = "Canister Inserter";
	//	static readonly string Description = "Canister Inserters allow contained gas to be inserted directly into a ventilation network.";
	//	static readonly string Effect = "Loads " + UI.FormatAsLink("Gas", "ELEMENTS_GAS") + " canisters into " + UI.FormatAsLink("Pipes", "GASPIPING") + " for transport.\n\nMust be loaded by Duplicants.";

	//	public override BuildingDef CreateBuildingDef()
	//	{
	//		string id = ID;
	//		int width = 1;
	//		int height = 3;
	//		string anim = "gas_emptying_station_kanim";
	//		int hitpoints = 30;
	//		float construction_time = 60f;
	//		float[] tieR2 = TUNING.BUILDINGS.CONSTRUCTION_MASS_KG.TIER2;
	//		string[] refinedMetals = MATERIALS.REFINED_METALS;
	//		float melting_point = 1600f;
	//		BuildLocationRule build_location_rule = BuildLocationRule.OnFloor;
	//		EffectorValues tieR1 = NOISE_POLLUTION.NOISY.TIER1;
	//		BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, construction_mass: tieR2, construction_materials: refinedMetals,
	//																		melting_point: melting_point, build_location_rule: build_location_rule, decor: TUNING.BUILDINGS.DECOR.PENALTY.TIER2,
	//																		noise: tieR1, temperature_modification_mass_scale: 0.2f);
	//		buildingDef.Floodable = false;
	//		buildingDef.AudioCategory = "Metal";
	//		buildingDef.Overheatable = false;
	//		buildingDef.PermittedRotations = PermittedRotations.FlipH;
	//		//buildingDef.OutputConduitType = ConduitType.Gas;
	//		//buildingDef.UtilityOutputOffset = new CellOffset(0, 1);
	//		buildingDef.ViewMode = OverlayModes.GasConduits.ID;
	//		return buildingDef;
	//	}

	//	public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
	//	{

	//		Prioritizable.AddRef(go);
	//		Storage storage = go.AddOrGet<Storage>();
	//		storage.fetchCategory = Storage.FetchCategory.Building;
	//		storage.storageFilters = STORAGEFILTERS.GASES;
	//		storage.showInUI = true;
	//		storage.showDescriptor = true;
	//		storage.capacityKg = 200f;
	//		storage.allowItemRemoval = false;
	//		ConduitDispenser conduitDispenser = go.AddOrGet<ConduitDispenser>();
	//		conduitDispenser.conduitType = ConduitType.Liquid;
	//		conduitDispenser.alwaysDispense = true;
	//		go.AddOrGet<TreeFilterable>();

	//		ManualDeliveryKG manualDeliveryKg = go.AddOrGet<ManualDeliveryKG>();
	//		manualDeliveryKg.SetStorage(storage);
	//		manualDeliveryKg.requestedItemTag = GameTags.Gas;
	//		manualDeliveryKg.refillMass = 10f;
	//		manualDeliveryKg.capacity = storage.Capacity();
	//		manualDeliveryKg.choreTypeIDHash = Db.Get().ChoreTypes.StorageFetch.IdHash;
	//	}

	//	public override void DoPostConfigureComplete(GameObject go)
	//	{
	//		//
	//	}

	//	public static void Setup()
	//	{
	//		Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ID.ToUpperInvariant()}.NAME", "<link=\"" + ID + "\">" + Name + "</link>");
	//		Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ID.ToUpperInvariant()}.DESC", Description);
	//		Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ID.ToUpperInvariant()}.EFFECT", Effect);


	//		int categoryIndex = TUNING.BUILDINGS.PLANORDER.FindIndex(x => x.category == "HVAC");
	//		(TUNING.BUILDINGS.PLANORDER[categoryIndex].data as IList<String>)?.Add(ID);

	//		var TechGroup = new List<string>(Database.Techs.TECH_GROUPING["Distillation"]) { };
	//		TechGroup.Add(ID);
	//		Database.Techs.TECH_GROUPING["Distillation"] = TechGroup.ToArray();

	//	}
	//}
}
