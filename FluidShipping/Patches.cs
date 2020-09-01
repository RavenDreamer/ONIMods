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
	}
}
