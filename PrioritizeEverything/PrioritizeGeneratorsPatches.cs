using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace StormShark.OniMods
{
	public static class PrioritizeGeneratorsPatches
	{
		[HarmonyPatch(typeof(SteamTurbineConfig2), MethodType.Normal)]
		[HarmonyPatch("DoPostConfigureComplete")]
		public static class SteamTurbine_Patch
		{
			public static void Postfix(GameObject go)
			{
				Prioritizable.AddRef(go);
			}
		}

		[HarmonyPatch(typeof(GeneratorConfig), MethodType.Normal)]
		[HarmonyPatch("DoPostConfigureComplete")]
		public static class CoalGenerator_Patch
		{
			public static void Postfix(GameObject go)
			{
				Prioritizable.AddRef(go);
			}
		}

		[HarmonyPatch(typeof(WoodGasGeneratorConfig), MethodType.Normal)]
		[HarmonyPatch("DoPostConfigureComplete")]
		public static class WoodBurner_Patch
		{
			public static void Postfix(GameObject go)
			{
				Prioritizable.AddRef(go);
			}
		}

		[HarmonyPatch(typeof(HydrogenGeneratorConfig), MethodType.Normal)]
		[HarmonyPatch("DoPostConfigureComplete")]
		public static class HydrogenGenerator_Patch
		{
			public static void Postfix(GameObject go)
			{
				Prioritizable.AddRef(go);
			}
		}

		[HarmonyPatch(typeof(MethaneGeneratorConfig), MethodType.Normal)]
		[HarmonyPatch("DoPostConfigureComplete")]
		public static class GasGenerator_Patch
		{
			public static void Postfix(GameObject go)
			{
				Prioritizable.AddRef(go);
			}
		}

		[HarmonyPatch(typeof(SolarPanelConfig), MethodType.Normal)]
		[HarmonyPatch("DoPostConfigureComplete")]
		public static class SolarPanel_Patch
		{
			public static void Postfix(GameObject go)
			{
				Prioritizable.AddRef(go);
			}
		}

		[HarmonyPatch(typeof(PetroleumGeneratorConfig), MethodType.Normal)]
		[HarmonyPatch("DoPostConfigureComplete")]
		public static class CombustionGenerator_Patch
		{
			public static void Postfix(GameObject go)
			{
				Prioritizable.AddRef(go);
			}
		}
	}
}
