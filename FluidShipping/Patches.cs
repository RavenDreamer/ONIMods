using Harmony;

namespace StormShark.OniFluidShipping
{
	public static class BuildingGenerationPatches
	{
		[HarmonyPatch(typeof(GeneratedBuildings))]
		[HarmonyPatch("LoadGeneratedBuildings")]
		public static class GeneratedBuildings_LoadGeneratedBuildings_Patch
		{
			public static void Prefix()
			{
				StorageButGasesConfig.Setup();
				StorageButLiquidConfig.Setup();
				//Debug.Log("Done the Dirty");
			}
		}
	}
}
