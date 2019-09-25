using STRINGS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TUNING;
using UnityEngine;
using BUILDINGS = TUNING.BUILDINGS;

namespace StormShark.OniMods
{
	public class LadderHatchConfig : IBuildingConfig
	{

		public override BuildingDef CreateBuildingDef()
		{
			int width = 1;
			int height = 1;
			string anim = "stormshark_trapdoor_kanim";
			int hitpoints = 30;
			float construction_time = 10f;
			float[] tieR2 = TUNING.BUILDINGS.CONSTRUCTION_MASS_KG.TIER2;
			string[] allMinerals = MATERIALS.ALL_METALS;
			float melting_point = 1600f;
			BuildLocationRule build_location_rule = BuildLocationRule.Tile;
			EffectorValues none = NOISE_POLLUTION.NONE;
			BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(ID, width, height, anim, hitpoints, construction_time, tieR2, allMinerals, melting_point, build_location_rule, BUILDINGS.DECOR.PENALTY.TIER0, none, 0.2f);
			buildingDef.Floodable = false;
			buildingDef.Overheatable = false;
			buildingDef.Entombable = false;
			buildingDef.AudioCategory = "Metal";
			buildingDef.AudioSize = "small";
			buildingDef.BaseTimeUntilRepair = -1f;
			//buildingDef.isSolidTile = true;
			buildingDef.IsFoundation = true;

			//buildingDef.DragBuild = true;
			buildingDef.TileLayer = ObjectLayer.FoundationTile;
			buildingDef.SceneLayer = Grid.SceneLayer.TileMain;

			return buildingDef;
		}

		public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
		{
			GeneratedBuildings.MakeBuildingAlwaysOperational(go);
			LadderHatch ladder = go.AddOrGet<LadderHatch>();
			ladder.upwardsMovementSpeedMultiplier = 1f;
			ladder.downwardsMovementSpeedMultiplier = 1f;
			BuildingConfigManager.Instance.IgnoreDefaultKComponent(typeof(RequiresFoundation), prefab_tag);
			SimCellOccupier simCellOccupier = go.AddOrGet<SimCellOccupier>();
			simCellOccupier.doReplaceElement = false;

			go.AddOrGet<AnimTileable>();
		}

		public override void DoPostConfigureComplete(GameObject go)
		{
			GeneratedBuildings.RemoveLoopingSounds(go);
			go.AddComponent<ZoneTile>();
			//go.AddOrGet<KBoxCollider2D>();
			go.GetComponent<KPrefabID>().AddTag(GameTags.FloorTiles);
		}


		public const string ID = "StormShark.TrapdoorLadder";
		static readonly string Name = "Trapdoor Ladder";
		static readonly string Description = "A tile of floor with a ladder hidden inside";
		static readonly string Effect = "Allows Duplicants to enter enclosed rooms vertically without breaking stride.\n\nWill catch debris that falls from above.";
		public static void Setup()
		{
			Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ID.ToUpperInvariant()}.NAME", "<link=\"" + ID + "\">" + Name + "</link>");
			Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ID.ToUpperInvariant()}.DESC", Description);
			Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ID.ToUpperInvariant()}.EFFECT", Effect);


			int categoryIndex = TUNING.BUILDINGS.PLANORDER.FindIndex(x => x.category == "Base");
			(TUNING.BUILDINGS.PLANORDER[categoryIndex].data as IList<String>)?.Add(ID);

		}

	}

}
