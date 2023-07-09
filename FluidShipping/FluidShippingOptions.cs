using Newtonsoft.Json;
using PeterHan.PLib.Core;
using PeterHan.PLib.Options;

namespace StormShark.OniFluidShipping
{
	/// <summary>
	/// The options class used for Claustrophobia.
	/// </summary>
	[ModInfo("https://github.com/RavenDreamer/ONIMods", "previewv2.png")]
	[JsonObject(MemberSerialization.OptIn)]
	[RestartRequired]
	public sealed class FluidShippingOptions
	{
		[Option("Canister Inserter Volume", "Internal storage volume of Canister Inserter (Kg).")]
		[JsonProperty]
		public float CanisterVolume { get; set; }

		[Option("Bottle Inserter Volume", "Internal storage volume of Bottle Inserter (Kg).")]
		[JsonProperty]
		public float BottleVolume { get; set; }

		[Option("Bottle Filler Volume", "Internal storage volume of Bottle Filler (Kg).")]
		[JsonProperty]
		public float BottleFillerVolume { get; set; }

		[Option("Canister Inserter Power Requirement", "Power requirement of Canister Inserter (W).")]
		[JsonProperty]
		public float CanisterInserterPowerRequirement { get; set; }

		[Option("Bottle Filler Power Requirement", "Power requirement of Bottle Filler (W).")]
		[JsonProperty]
		public float BottleFillerPowerRequirement { get; set; }


		public FluidShippingOptions()
		{
			CanisterVolume = 10;
			BottleVolume = 200;
			BottleFillerVolume = 200;
			CanisterInserterPowerRequirement = 0;
			BottleFillerPowerRequirement = 0;

		}

		public override string ToString()
		{
			return "FluidShippingOptions[gasKg={0:D},liquidKg{1:D},liquidFillerKg={2:D},canisterWatts={3:D},bottleWatts={4:D}]".F(CanisterVolume, BottleVolume, BottleFillerVolume, CanisterInserterPowerRequirement, BottleFillerPowerRequirement);
		}
	}
}
