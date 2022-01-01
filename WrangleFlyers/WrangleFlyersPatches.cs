using HarmonyLib;
using KMod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace StormShark.OniMods
{
	public class WrangleFlyerPatches : UserMod2
	{
		[HarmonyPatch(typeof(BaseLightBugConfig), MethodType.Normal)]
		[HarmonyPatch("BaseLightBug")]
		public static class WrangleLightBug_Patch
		{
			public static void Postfix(GameObject __result)
			{
				__result.AddOrGet<Capturable>().allowCapture = true;
			}
		}

		[HarmonyPatch(typeof(BaseMooConfig), MethodType.Normal)]
		[HarmonyPatch("BaseMoo")]
		public static class WrangleMoo_Patch
		{
			public static void Postfix(GameObject __result)
			{
				__result.AddOrGet<Capturable>().allowCapture = true;
			}
		}

		[HarmonyPatch(typeof(BaseOilFloaterConfig), MethodType.Normal)]
		[HarmonyPatch("BaseOilFloater")]
		public static class WrangleOilFloater_Patch
		{
			public static void Postfix(GameObject __result)
			{
				__result.AddOrGet<Capturable>().allowCapture = true;
			}
		}

		[HarmonyPatch(typeof(BasePuftConfig), MethodType.Normal)]
		[HarmonyPatch("BasePuft")]
		public static class WranglePuft_Patch
		{
			public static void Postfix(GameObject __result)
			{
				__result.AddOrGet<Capturable>().allowCapture = true;
			}
		}
	}
}
