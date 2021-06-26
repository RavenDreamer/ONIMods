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
	public sealed class FluidShippingOptions
	{
		[Option("Canister Inserter Volume", "Internal storage volume of Canister Inserter (Kg).")]
		[JsonProperty]
		public float CanisterVolume { get; set; }

		[Option("Bottle Inserter Volume", "Internal storage volume of Bottle Inserter (Kg).")]
		[JsonProperty]
		public float BottleVolume { get; set; }

		[Option("Bottle Filler Volume", "Internal storage volume of Bottle Filler(Kg).")]
		[JsonProperty]
		public float BottleFillerVolume { get; set; }


		public FluidShippingOptions()
		{
			CanisterVolume = 10;
			BottleVolume = 200;
			BottleFillerVolume = 200;
		}

		public override string ToString()
		{
			return "FluidShippingOptions[liquidKg={0:D},gasKg{1:D},liquidFillerKg={2:D}]".F(CanisterVolume, BottleVolume, BottleFillerVolume);
		}
	}
}
