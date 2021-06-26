using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace StormShark.OniMods
{
	public static class PlantConsumerFix
	{



		[HarmonyPatch(typeof(SaltPlant), MethodType.Normal)]
		[HarmonyPatch("OnWilt")]
		public static class Saltplant_OnWiltPatch
		{
			public static void PreFix(SaltPlant __instance)
			{
				Debug.Log("Salt Wilt called. Resource Consumption Halted.");
			}
		}

		[HarmonyPatch(typeof(SaltPlant), MethodType.Normal)]
		[HarmonyPatch("OnWiltRecover")]
		public static class Immigration_Patch_b
		{
			public static void PreFix(SaltPlant __instance)
			{
				Debug.Log("Salt Wilt Recover called. Resource Consumption Resumed.");
			}
		}

	}


}
