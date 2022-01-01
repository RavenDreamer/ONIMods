using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StormShark.OniMods
{
	public class LadderHatchPatches : KMod.UserMod2
	{
		[HarmonyPatch(typeof(GeneratedBuildings))]
		[HarmonyPatch("LoadGeneratedBuildings")]
		public static class GeneratedBuildings_LoadGeneratedBuildings_Patch
		{
			public static void Prefix()
			{
				LadderHatchConfig.Setup();
				//FirePoleHatch.Setup();
			}
		}
	}
}
