using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StormShark.OniMods
{
	public static class SynchronizedTelepadPatches
	{
		public static readonly float twoDays = 1200f;
		public static readonly float threeDays = 1800f;
		public static readonly float immigrationTime = 350f;
		//Game starts cycle 1 at 50, with .5 cycles (aka 300) until first print.
		//All subsequent prints aree 1800 after.
		//This means that we want to return between 2 and 3 cycles @ 350, daily time


		[HarmonyPatch(typeof(Immigration), MethodType.Normal)]
		[HarmonyPatch("EndImmigration")]
		public static class Immigration_Patch_a
		{
			public static void Postfix(Immigration __instance)
			{
				__instance.timeBeforeSpawn = SynchronizedTelepadPatches.GetTimeUntill350();
			}
		}

		[HarmonyPatch(typeof(Immigration), MethodType.Normal)]
		[HarmonyPatch("Stop")]
		public static class Immigration_Patch_b
		{
			public static void Postfix(Immigration __instance)
			{
				__instance.timeBeforeSpawn = SynchronizedTelepadPatches.GetTimeUntill350();
			}
		}

		public static float GetTimeUntill350()
		{
			float sinceStartOfCycle = GameClock.Instance.GetTimeSinceStartOfCycle();
			if ((double)sinceStartOfCycle <= (double)immigrationTime)
			{
				return twoDays + (immigrationTime - sinceStartOfCycle);
			}
			else
			{
				return threeDays - (sinceStartOfCycle - immigrationTime);
			}
		}

	}
}
