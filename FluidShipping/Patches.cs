using Harmony;
using PeterHan.PLib;
using PeterHan.PLib.Options;

namespace StormShark.OniFluidShipping
{
	public static class BuildingGenerationPatches
	{
		public static void OnLoad()
		{
			PUtil.InitLibrary();
			POptions.RegisterOptions(typeof(FluidShippingOptions));

			Options = new FluidShippingOptions();
		}

		internal static FluidShippingOptions Options { get; private set; }

		[HarmonyPatch(typeof(GeneratedBuildings))]
		[HarmonyPatch("LoadGeneratedBuildings")]
		public static class GeneratedBuildings_LoadGeneratedBuildings_Patch
		{
			public static void Prefix()
			{
				var newOptions = POptions.ReadSettings<FluidShippingOptions>();
				if (newOptions != null) Options = newOptions;

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
				//find tech with ImprovedLiquidPiping. Add s_bi_id to that tech.
				Db.Get().Techs.Get("ImprovedLiquidPiping").unlockedItemIDs.Add(BottleInserterConfig.S_BI_ID);
				//find tech with ImprovedGasPiping. Add s_ci_id to that tech.
				Db.Get().Techs.Get("ImprovedGasPiping").unlockedItemIDs.Add(CanisterInserterConfig.S_CI_ID);
			}
		}
	}
}
