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
				//Debug.Log("Time of next immigration: " + __instance.timeBeforeSpawn +" " + GameClock.Instance.GetTimeSinceStartOfCycle() % 600));
			}
		}

		[HarmonyPatch(typeof(Immigration), MethodType.Normal)]
		[HarmonyPatch("Stop")]
		public static class Immigration_Patch_b
		{
			public static void Postfix(Immigration __instance)
			{
				__instance.timeBeforeSpawn = SynchronizedTelepadPatches.GetTimeUntill350();
				//Debug.Log("Time of next immigration: " + (__instance.timeBeforeSpawn + GameClock.Instance.GetTimeSinceStartOfCycle() % 600));
			}
		}

		public static float GetTimeUntill350()
		{
			float sinceStartOfCycle = GameClock.Instance.GetTimeSinceStartOfCycle();
			//Debug.Log("Time since start of cycle:" + sinceStartOfCycle);

			if (sinceStartOfCycle <= immigrationTime)
			{
				var intmedVal = twoDays + (immigrationTime - sinceStartOfCycle);
				//Debug.Log("Two days Plus: " + intmedVal);
				return twoDays + (immigrationTime - sinceStartOfCycle);
			}
			else
			{
				var intmedVal = threeDays - (sinceStartOfCycle - immigrationTime);
				//Debug.Log("Three days Minus: " + intmedVal);
				return threeDays - (sinceStartOfCycle - immigrationTime);
			}
		}

	}



	//[01:53:44.435] [1] [INFO] Time since start of cycle:273.063
	//[01:53:44.436] [1] [INFO] Two days Plus: 1276.937
	//[01:53:44.436] [1] [INFO] Time of next immigration: 1550
	//[01:54:32.449] [1] [INFO] Time since start of cycle:283.1272
	//[01:54:32.449] [1] [INFO] Two days Plus: 1266.873
	//[01:54:32.449] [1] [INFO] Time of next immigration: 1550
	//[02:02:15.476][1][INFO] Time since start of cycle:356.8927
	//[02:02:15.476] [1] [INFO] Two days Plus: 1793.107
	//[02:02:15.476] [1] [INFO] Time of next immigration: 2150
}
