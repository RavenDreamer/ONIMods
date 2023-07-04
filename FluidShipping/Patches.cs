using HarmonyLib;
using KMod;
using PeterHan.PLib.Core;
using PeterHan.PLib.Options;

namespace StormShark.OniFluidShipping
{
	public class BuildingGenerationPatches : UserMod2
	{
		public override void OnLoad(Harmony harmony)
		{
			base.OnLoad(harmony);

			PUtil.InitLibrary();
			pOption = new POptions();

			pOption.RegisterOptions(this, typeof(FluidShippingOptions));

			Options = new FluidShippingOptions();
		}

		internal static FluidShippingOptions Options { get; private set; }
		internal static POptions pOption { get; private set; }

		[HarmonyPatch(typeof(GeneratedBuildings))]
		[HarmonyPatch("LoadGeneratedBuildings")]
		public static class GeneratedBuildings_LoadGeneratedBuildings_Patch
		{
			public static void Prefix()
			{
				var newOptions = POptions.ReadSettings<FluidShippingOptions>();
				if (newOptions != null) Options = newOptions;

				BottleFillerConfig.Setup();
				BottleInserterConfig.Setup();
				CanisterInserterConfig.Setup();

			}
		}


		[HarmonyPatch(typeof(Db))]
		[HarmonyPatch("Initialize")]
		public static class Db_Techs_Patch
		{
			public static void Postfix()
			{
				//find tech with ImprovedLiquidPiping. Add s_bi_id and s_bf_id to that tech.
				Db.Get().Techs.Get("ImprovedLiquidPiping").unlockedItemIDs.Add(BottleInserterConfig.S_BI_ID);
				Db.Get().Techs.Get("ImprovedLiquidPiping").unlockedItemIDs.Add(BottleFillerConfig.S_BF_ID);
				//find tech with ImprovedGasPiping. Add s_ci_id to that tech.
				Db.Get().Techs.Get("ImprovedGasPiping").unlockedItemIDs.Add(CanisterInserterConfig.S_CI_ID);
			}
		}
	}
}
