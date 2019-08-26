//public class SMInstance : GameStateMachine<States, VesselInserter.SMInstance, VesselInserter, object>.GameInstance
//{
//	//private FetchChore chore;

//	public SMInstance(VesselInserter master)
//	  : base(master)
//	{
//	}

//	//public MeterController Meter { get; private set; }

//	//public void CreateChore()
//	//{
//	//	KBatchedAnimController component1 = this.GetComponent<KBatchedAnimController>();
//	//	Tag[] tags = this.GetComponent<TreeFilterable>().GetTags();
//	//	if (tags == null || tags.Length == 0)
//	//	{
//	//		component1.TintColour = (Color32)this.master.noFilterTint;
//	//	}
//	//	else
//	//	{
//	//		component1.TintColour = (Color32)this.master.filterTint;
//	//		Tag[] forbidden_tags;

//	//		forbidden_tags = new Tag[0];
//	//		Storage component2 = this.GetComponent<Storage>();
//	//		this.chore = new FetchChore(Db.Get().ChoreTypes.StorageFetch, component2, component2.Capacity(), this.GetComponent<TreeFilterable>().GetTags(), (Tag[])null, forbidden_tags, (ChoreProvider)null, true, (System.Action<Chore>)null, (System.Action<Chore>)null, (System.Action<Chore>)null, FetchOrder2.OperationalRequirement.Operational, 0, (Tag[])null);
//	//	}
//	//	Debug.Log("chore created");
//	//}

//	//public void CancelChore()
//	//{
//	//	if (this.chore == null)
//	//		return;
//	//	this.chore.Cancel("Storage Changed");
//	//	this.chore = (FetchChore)null;
//	//	Debug.Log("chore canceled");
//	//}

//	//public void RefreshChore()
//	//{
//	//	//this.GoTo((StateMachine.BaseState)this.sm.unoperational);
//	//}

//	//private void OnFilterChanged(Tag[] tags)
//	//{
//	//	this.RefreshChore();
//	//}

//	//private void OnStorageChange(object data)
//	//{
//	//	Storage component = this.GetComponent<Storage>();
//	//	this.Meter.SetPositionPercent(Mathf.Clamp01(component.RemainingCapacity() / component.capacityKg));
//	//}

//	//public void StartMeter()
//	//{
//	//	PrimaryElement firstPrimaryElement = this.GetFirstPrimaryElement();
//	//	if ((UnityEngine.Object)firstPrimaryElement == (UnityEngine.Object)null)
//	//		return;
//	//	this.Meter.SetSymbolTint(new KAnimHashedString("meter_fill"), firstPrimaryElement.Element.substance.colour);
//	//	this.Meter.SetSymbolTint(new KAnimHashedString("water1"), firstPrimaryElement.Element.substance.colour);
//	//	this.GetComponent<KBatchedAnimController>().SetSymbolTint(new KAnimHashedString("leak_ceiling"), (Color)firstPrimaryElement.Element.substance.colour);
//	//}

//	//private PrimaryElement GetFirstPrimaryElement()
//	//{
//	//	Storage component1 = this.GetComponent<Storage>();
//	//	for (int index = 0; index < component1.Count; ++index)
//	//	{
//	//		GameObject gameObject = component1[index];
//	//		if (!((UnityEngine.Object)gameObject == (UnityEngine.Object)null))
//	//		{
//	//			PrimaryElement component2 = gameObject.GetComponent<PrimaryElement>();
//	//			if (!((UnityEngine.Object)component2 == (UnityEngine.Object)null))
//	//				return component2;
//	//		}
//	//	}
//	//	return (PrimaryElement)null;
//	//}
//}



////public class States : GameStateMachine<States, SMInstance, VesselInserter>
////{
////	private StatusItem statusItem;
////	public State unoperational;
////	public State waitingfordelivery;
////	public State emptying;

////	public override void InitializeStates(out StateMachine.BaseState default_state)
////	{
////		default_state = waitingfordelivery;
////		this.statusItem = new StatusItem(nameof(VesselInserter), string.Empty, string.Empty, string.Empty, StatusItem.IconType.Info, NotificationType.Neutral, false, OverlayModes.None.ID, 63486)
////		{
////			resolveStringCallback = (Func<string, object, string>)((str, data) =>
////			{
////				VesselInserter vesselInserter = (VesselInserter)data;
////				if ((UnityEngine.Object)vesselInserter == (UnityEngine.Object)null)
////					return str;

////				return (string)BUILDING.STATUSITEMS.BOTTLE_EMPTIER.DENIED.NAME;
////			}),
////			resolveTooltipCallback = (Func<string, object, string>)((str, data) =>
////			{
////				VesselInserter vesselInserter = (VesselInserter)data;
////				if ((UnityEngine.Object)vesselInserter == (UnityEngine.Object)null)
////					return str;

////				return (string)BUILDING.STATUSITEMS.BOTTLE_EMPTIER.DENIED.TOOLTIP;
////			})
////		};
////		this.root.ToggleStatusItem(statusItem, smi => smi.master);
////		//if unoperational and we gain the "Operational" tag, move to waitingForDelivery
////		this.unoperational.TagTransition(GameTags.Operational, this.waitingfordelivery, false)
////			//play the "off" animation when in this state
////			.PlayAnim("off");
////		//if waitingForDelivery and we remove the "Operational" tag, move to unoperational
////		this.waitingfordelivery.TagTransition(GameTags.Operational, this.unoperational, true)
////			//when there is a change in storage, change from "waitingForDelivery" to "emptying" as long as the storage is not empty
////			.EventTransition(GameHashes.OnStorageChange, this.emptying, smi => !smi.GetComponent<Storage>().IsEmpty())
////			//when you enter this state, create a new chore
////			.Enter("CreateChore", smi => smi.CreateChore())
////			//when you leave this state, cancel the created chore
////			.Exit("CancelChore", smi => smi.CancelChore())
////			//?? when in this state, play the "on" animation??
////			.PlayAnim("on");
////		//if emptying and we lose the "operational" tag, move to unoperational
////		this.emptying.TagTransition(GameTags.Operational, this.unoperational, true)
////			//when there is a change in storage, change from "emptying" to "waiting for delivery" as long as storage *is* empty
////			.EventTransition(GameHashes.OnStorageChange, this.waitingfordelivery, smi => smi.GetComponent<Storage>().IsEmpty())
////			.Enter("StartMeter", (StateMachine<States, VesselInserter.SMInstance, VesselInserter, object>.State.Callback)(smi => smi.StartMeter()))
////			//					.Update("Emit", (System.Action<VesselInserter.SMInstance, float>)((smi, dt) => smi), UpdateRate.SIM_200ms, false)
////			.PlayAnim("working_loop", KAnim.PlayMode.Loop);
////	}
////}

//public class States : GameStateMachine<VesselInserter.States, VesselInserter.SMInstance, VesselInserter>
//{
//	public State off;
//	public State on;

//	public override void InitializeStates(out BaseState default_state)
//	{
//		default_state = on;
//		this.root.DoNothing();

//		this.off.PlayAnim("off")
//			//if it becomes operational, turn it on
//			.EventTransition(GameHashes.OperationalChanged, on, smi => smi.GetComponent<Operational>().IsOperational);
//		//if it becomes non-operational, turn it off.
//		this.on.PlayAnim("on")
//			.EventTransition(GameHashes.OperationalChanged, off, smi => !smi.GetComponent<Operational>().IsOperational);

//	}

//}