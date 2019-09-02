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
			string anim = "stormshark_ladderhatch_kanim";
			int hitpoints = 10;
			float construction_time = 10f;
			float[] tieR2 = TUNING.BUILDINGS.CONSTRUCTION_MASS_KG.TIER2;
			string[] allMinerals = MATERIALS.ALL_MINERALS;
			float melting_point = 1600f;
			BuildLocationRule build_location_rule = BuildLocationRule.Anywhere;
			EffectorValues none = NOISE_POLLUTION.NONE;
			BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(ID, width, height, anim, hitpoints, construction_time, tieR2, allMinerals, melting_point, build_location_rule, BUILDINGS.DECOR.PENALTY.TIER0, none, 0.2f);
			buildingDef.Floodable = false;
			buildingDef.Overheatable = false;
			buildingDef.Entombable = false;
			buildingDef.AudioCategory = "Metal";
			buildingDef.AudioSize = "small";
			buildingDef.BaseTimeUntilRepair = -1f;
			buildingDef.isSolidTile = true;
			buildingDef.DragBuild = true;
			buildingDef.TileLayer = ObjectLayer.LadderTile;
			buildingDef.ReplacementLayer = ObjectLayer.ReplacementLadder;
			buildingDef.ReplacementTags = new List<Tag>();
			buildingDef.ReplacementTags.Add(GameTags.Ladders);
			return buildingDef;
		}

		public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
		{
			GeneratedBuildings.MakeBuildingAlwaysOperational(go);
			LadderHatch ladder = go.AddOrGet<LadderHatch>();
			ladder.upwardsMovementSpeedMultiplier = 1f;
			ladder.downwardsMovementSpeedMultiplier = 1f;
			go.AddOrGet<AnimTileable>();
		}



		public const string ID = "StormShark.LadderHatch";
		static readonly string Name = "Ladder Hatch";
		static readonly string Description = "A floor hatch with a ladder directly below it";
		static readonly string Effect = "Allows Duplicants to enter enclosed rooms vertically without breaking their stride.\n\nWill catch debris that falls from above.";
		public static void Setup()
		{
			Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ID.ToUpperInvariant()}.NAME", "<link=\"" + ID + "\">" + Name + "</link>");
			Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ID.ToUpperInvariant()}.DESC", Description);
			Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ID.ToUpperInvariant()}.EFFECT", Effect);


			int categoryIndex = TUNING.BUILDINGS.PLANORDER.FindIndex(x => x.category == "Base");
			(TUNING.BUILDINGS.PLANORDER[categoryIndex].data as IList<String>)?.Add(ID);

		}

		public override void DoPostConfigureComplete(GameObject go)
		{

			go.AddOrGet<ZoneTile>();
			go.AddOrGet<KBoxCollider2D>();
		}
	}

}
