using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StormShark.OniMods
{
	public static class LadderHatchPatches
	{
		[HarmonyPatch(typeof(GeneratedBuildings))]
		[HarmonyPatch("LoadGeneratedBuildings")]
		public static class GeneratedBuildings_LoadGeneratedBuildings_Patch
		{
			public static void Prefix()
			{
				//LadderHatch.Setup();
				//FirePoleHatch.Setup();
			}
		}
	}
}
