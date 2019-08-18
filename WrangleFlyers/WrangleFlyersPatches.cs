using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace StormShark.OniMods
{
	public static class WrangleLightBugPatches
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
	}
}
