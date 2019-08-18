using Database;
using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unity;
using UnityEngine;

namespace StormShark.OniMods
{
	public static class ConsoleAchievementTrackerPatches
	{
		[HarmonyPatch(typeof(ColonyAchievementTracker))]
		[HarmonyPatch("Serialize")]
		public static class ColonyAchievementTracker_Patch
		{
			public static void Postfix(ColonyAchievementTracker __instance)
			{
				Debug.Log("---");
				Debug.Log("!Achievement Tracker Start!");

				if (DebugHandler.InstantBuildMode)
				{
					Debug.LogWarningFormat("Unable to unlock achievements: instant build mode");
				}
				else if (SaveGame.Instance.sandboxEnabled)
					Debug.LogWarningFormat("Unable to unlock achievements: instant build mode");
				else if (Game.Instance.debugWasUsed)
				{
					Debug.LogWarningFormat("Unable to unlock achievements: debug was used.");
				}

				foreach (KeyValuePair<string, ColonyAchievementStatus> achievement in __instance.achievements)
				{
					if (relevantAchievements.Contains(achievement.Key))
					{
						Debug.Log("-----");
						var outputString = getAchievementString(achievement.Key, achievement.Value);
						foreach (string s in outputString)
						{
							Debug.Log(s);
						}
					}
					//else
					//{
					//	Debug.Log("Other achievement: " + achievement.Key);
					//}
				}
				Debug.Log("-----");
			}

			private static List<string> getAchievementString(string key, ColonyAchievementStatus cas)
			{
				List<string> outStrings = new List<string>();
				switch (key)
				{
					case "TameAllBasicCritters":
						outStrings.Add("Critter Whisperer:");
						outStrings.Add(getAchievementStatus(cas));
						outStrings.AddRange(CritterWhispererFormatter(cas));
						break;
					case "EatkCalFromMeatByCycle100":
						outStrings.Add("Carnivore:");
						outStrings.Add(getAchievementStatus(cas));
						outStrings.AddRange(CarnivoreFormatter(cas));
						break;
					case "NoFarmTilesAndKCal":
						outStrings.Add("Locavore:");
						outStrings.Add(getAchievementStatus(cas));
						outStrings.AddRange(LocavoreFormatter(cas));
						break;
					case "Generate240000kJClean":
						outStrings.Add("Super Sustainable:");
						outStrings.Add(getAchievementStatus(cas));
						outStrings.AddRange(SuperSustainableFormatter(cas));
						break;
					case "BasicPumping":
						outStrings.Add("Oxygen Not Occluded:");
						outStrings.Add(getAchievementStatus(cas));
						outStrings.AddRange(VentXKGFormatter(cas));
						break;
					case "Travel10000InTubes":
						outStrings.Add("Totally Tubular:");
						outStrings.Add(getAchievementStatus(cas));
						outStrings.AddRange(TotallyTubularFormatter(cas));
						break;
					case "GeneratorTuneup":
						outStrings.Add("Finely Tuned Machine:");
						outStrings.Add(getAchievementStatus(cas));
						outStrings.AddRange(TuneUpForWhatFormatter(cas));
						break;
					case "ClearFOW":
						outStrings.Add("Pulling Back The Veil:");
						outStrings.Add(getAchievementStatus(cas));
						outStrings.AddRange(PullingBackTheVeilFormatter(cas));
						break;
					case "HatchRefinement":
						outStrings.Add("Down the Hatch:");
						outStrings.Add(getAchievementStatus(cas));
						outStrings.AddRange(DownTheHatchFormatter(cas));
						break;
					default:
						break;

				}
				return outStrings;
			}

			private static string getAchievementStatus(ColonyAchievementStatus cas)
			{

				if (cas.success)
				{
					return "Imperative Successful!";
				}
				else if (cas.failed)
				{
					//find the requirement that failed, and report the first one.
					foreach (ColonyAchievementRequirement car in cas.Requirements)
					{
						if (car.Fail())
						{
							return string.Format("Failed Requirement:{0}", car.GetType().ToString());
						}
					}

					return "Eligible";
				}
				else
				{
					return "Eligible";
				}

			}
		}

		static readonly HashSet<string> relevantAchievements = new HashSet<string>(new List<string>() { "TameAllBasicCritters","EatkCalFromMeatByCycle100","NoFarmTilesAndKCal","Generate240000kJClean",
		"Travel10000InTubes","GeneratorTuneup","BasicPumping","ClearFOW","HatchRefinement"});

		private static string GetLocalizedName(Tag key)
		{
			switch (key.ToString())
			{
				case "Drecko":
				case "Hatch":
				case "Pacu":
				case "Puft":
					return key.ToString();
				case "LightBug":
					return "Shine Bug";
				case "Mole":
					return "Shove Vole";
				case "Oilfloater":
					return "Slickster";
				case "Moo":
					return "Gassy Moo";
				case "Crab":
					return "Pokeshell";
				case "Squirrel":
					return "Pip";
				default:
					return key.ToString();
			}
		}


		public static List<string> CritterWhispererFormatter(ColonyAchievementStatus cas)
		{
			List<string> outStrings = new List<string>();

			CritterTypesWithTraits __instance = (CritterTypesWithTraits)cas.Requirements.Find(s => s is CritterTypesWithTraits);

			var priv = Traverse.Create(__instance);
			Dictionary<Tag, bool> tameDict = (Dictionary<Tag, bool>)priv.Field("critterTypesToCheck").GetValue();



			foreach (KeyValuePair<Tag, bool> keyValuePair in tameDict)
			{
				string localizeName = GetLocalizedName(keyValuePair.Key);

				string output = string.Format("Critter:{0}, Tamed: {1}", localizeName, keyValuePair.Value);

				outStrings.Add(output);
			}

			return outStrings;

		}



		public static List<string> TotallyTubularFormatter(ColonyAchievementStatus cas)
		{
			List<string> outStrings = new List<string>();

			TravelXUsingTransitTubes __instance = (TravelXUsingTransitTubes)cas.Requirements.Find(s => s is TravelXUsingTransitTubes);

			var priv = Traverse.Create(__instance);
			int distToGo = (int)priv.Field("distanceToTravel").GetValue();

			int num = 0;
			foreach (Component component1 in Components.MinionIdentities.Items)
			{
				Navigator component2 = component1.GetComponent<Navigator>();
				if ((UnityEngine.Object)component2 != (UnityEngine.Object)null && component2.distanceTravelledByNavType.ContainsKey(NavType.Tube))
					num += component2.distanceTravelledByNavType[NavType.Tube];
			}

			string output = string.Format("Distance Traveled: {0} / {1}", num, distToGo);

			outStrings.Add(output);

			return outStrings;
		}


		//It may be "FinelyTunedMachine" now, but it will always be "TuneUpForWhat in my heart.
		public static List<string> TuneUpForWhatFormatter(ColonyAchievementStatus cas)
		{
			List<string> outStrings = new List<string>();

			TuneUpGenerator __instance = (TuneUpGenerator)cas.Requirements.Find(s => s is TuneUpGenerator);

			var priv = Traverse.Create(__instance);
			//Sic. This *is* the name of the field. If they fix the typo, it'll need to be fixed here as well.
			float numChores = (float)priv.Field("numChoreseToComplete").GetValue();

			float num = 0.0f;
			ReportManager.ReportEntry entry = ReportManager.Instance.TodaysReport.GetEntry(ReportManager.ReportType.ChoreStatus);
			for (int index = 0; index < entry.contextEntries.Count; ++index)
			{
				ReportManager.ReportEntry contextEntry = entry.contextEntries[index];
				if (contextEntry.context == Db.Get().ChoreTypes.PowerTinker.Name)
					num += contextEntry.Negative;
			}
			for (int index1 = 0; index1 < ReportManager.Instance.reports.Count; ++index1)
			{
				for (int index2 = 0; index2 < ReportManager.Instance.reports[index1].GetEntry(ReportManager.ReportType.ChoreStatus).contextEntries.Count; ++index2)
				{
					ReportManager.ReportEntry contextEntry = ReportManager.Instance.reports[index1].GetEntry(ReportManager.ReportType.ChoreStatus).contextEntries[index2];
					if (contextEntry.context == Db.Get().ChoreTypes.PowerTinker.Name)
						num += contextEntry.Negative;
				}
			}

			string output = string.Format("Tune Ups: {0} / {1}", (double)Math.Abs(num), (double)numChores);

			outStrings.Add(output);
			return outStrings;
		}



		public static List<string> SuperSustainableFormatter(ColonyAchievementStatus cas)
		{
			List<string> outStrings = new List<string>();

			ProduceXEngeryWithoutUsingYList __instance = (ProduceXEngeryWithoutUsingYList)cas.Requirements.Find(s => s is ProduceXEngeryWithoutUsingYList);

			var priv = Traverse.Create(__instance);

			List<Tag> disallowedBuildings = (List<Tag>)priv.Field("disallowedBuildings").GetValue();

			bool mooted = (bool)priv.Field("usedDisallowedBuilding").GetValue();
			float toMake = (float)priv.Field("amountToProduce").GetValue();

			float num = 0.0f;
			foreach (KeyValuePair<Tag, float> keyValuePair in Game.Instance.savedInfo.powerCreatedbyGeneratorType)
			{
				if (!disallowedBuildings.Contains(keyValuePair.Key))
					num += keyValuePair.Value;
			}
			double made = (double)num / 1000.0;

			string output = string.Format("Clean Energy Generated: {0} / {1}", made, toMake);

			outStrings.Add(output);

			return outStrings;

		}


		public static List<string> LocavoreFormatter(ColonyAchievementStatus cas)
		{

			//This will not be possible if the "No Farmtiles" requirement has ever reported failure.
			//That can't be tracked this way, though, so leaving it out of the "quick and dirty" tracking 
			//we're doing here.
			List<string> outStrings = new List<string>();

			EatXCalories __instance = (EatXCalories)cas.Requirements.Find(s => s is EatXCalories);


			var priv = Traverse.Create(__instance);

			int toEat = (int)priv.Field("numCalories").GetValue();

			var num = (double)RationTracker.Get().GetCaloriesConsumed() / 1000.0;

			string output = string.Format("Calories Consumed: {0} / {1}", num, toEat);

			outStrings.Add(output);

			return outStrings;
		}


		public static List<string> PullingBackTheVeilFormatter(ColonyAchievementStatus cas)
		{

			List<string> outStrings = new List<string>();

			RevealAsteriod __instance = (RevealAsteriod)cas.Requirements.Find(s => s is RevealAsteriod);

			var priv = Traverse.Create(__instance);

			float toReveal = (float)priv.Field("percentToReveal").GetValue();

			float num = 0.0f;
			for (int index = 0; index < Grid.Visible.Length; ++index)
			{
				if (Grid.Visible[index] > (byte)0)
					++num;
			}
			string output = string.Format("Fog of War Pierced: {0}% / {1}%", ((double)num / (double)Grid.Visible.Length) * 100, (double)toReveal * 100);

			outStrings.Add(output);

			return outStrings;

		}


		public static List<string> VentXKGFormatter(ColonyAchievementStatus cas)
		{

			//This references a "GetVentedMass" function that doesn't show up in my version of the decompiled source.
			//Not sure if this is actually working!
			List<string> outStrings = new List<string>();

			VentXKG __instance = (VentXKG)cas.Requirements.Find(s => s is VentXKG);


			var priv = Traverse.Create(__instance);

			float toVent = (float)priv.Field("kilogramsToVent").GetValue();

			float num = 0.0f;
			foreach (UtilityNetwork network in (IEnumerable<UtilityNetwork>)Conduit.GetNetworkManager(ConduitType.Gas).GetNetworks())
			{
				if (network is FlowUtilityNetwork flowUtilityNetwork)
				{
					foreach (FlowUtilityNetwork.IItem sink in flowUtilityNetwork.sinks)
					{
						Vent component = sink.GameObject.GetComponent<Vent>();
						if ((UnityEngine.Object)component != (UnityEngine.Object)null)
							num += component.GetVentedMass(SimHashes.Oxygen);
					}
				}
			}

			string output = string.Format("Oxygen Vented: {0} / {1}", (double)num, (double)toVent);

			outStrings.Add(output);

			return outStrings;

		}

		public static List<string> CarnivoreFormatter(ColonyAchievementStatus cas)
		{

			List<string> outStrings = new List<string>();

			EatXCaloriesFromY __instance = (EatXCaloriesFromY)cas.Requirements.Find(s => s is EatXCaloriesFromY);


			var priv = Traverse.Create(__instance);
			List<string> foodTypes = (List<string>)priv.Field("fromFoodType").GetValue();
			int numCal = (int)priv.Field("numCalories").GetValue();

			var num = (double)RationTracker.Get().GetCaloiresConsumedByFood(foodTypes) / 1000.0;

			string output = string.Format("Meats Eaten: {0} / {1}", (double)num, (double)numCal);

			outStrings.Add(output);
			return outStrings;

		}


		public static List<string> DownTheHatchFormatter(ColonyAchievementStatus cas)
		{

			List<string> outStrings = new List<string>();

			CreaturePoopKGProduction __instance = (CreaturePoopKGProduction)cas.Requirements.Find(s => s is CreaturePoopKGProduction);


			var priv = Traverse.Create(__instance);

			float refineCount = (float)priv.Field("amountToPoop").GetValue();

			float num;
			if (Game.Instance.savedInfo.creaturePoopAmount.ContainsKey((Tag)"HatchMetal"))
			{
				num = Game.Instance.savedInfo.creaturePoopAmount[(Tag)"HatchMetal"];
			}
			else
			{
				num = 0f;
			}

			var achieved = (double)num >= (double)refineCount * 1000.0;

			string output = string.Format("Achieved:{0}, Metals Excreted: {1} / {2}", achieved, (double)num, (double)refineCount);

			outStrings.Add(output);
			return outStrings;

		}


	}
}
