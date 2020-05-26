using Klei;
using KSerialization;
using STRINGS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace StormShark.OniFluidShipping
{
	[SerializationConfig(MemberSerialization.OptIn)]
	public class VesselInserter : StateMachineComponent<VesselInserter.StatesInstance>, IEffectDescriptor
	{
		private static readonly EventSystem.IntraObjectHandler<VesselInserter> OnRefreshUserMenuDelegate = new EventSystem.IntraObjectHandler<VesselInserter>((Action<VesselInserter, object>)((component, data) => component.OnRefreshUserMenu(data)));
		private static readonly EventSystem.IntraObjectHandler<VesselInserter> OnCopySettingsDelegate = new EventSystem.IntraObjectHandler<VesselInserter>((System.Action<VesselInserter, object>)((component, data) => component.OnCopySettings(data)));
		public float emptyRate = 10f;
		[SerializeField]
		public Color noFilterTint = (Color)FilteredStorage.NO_FILTER_TINT;
		[SerializeField]
		public Color filterTint = (Color)FilteredStorage.FILTER_TINT;
		[Serialize]
		public bool allowManualPumpingStationFetching;

		protected override void OnSpawn()
		{
			base.OnSpawn();
			this.smi.StartSM();
			this.Subscribe<VesselInserter>(493375141, VesselInserter.OnRefreshUserMenuDelegate);
			this.Subscribe<VesselInserter>(-905833192, VesselInserter.OnCopySettingsDelegate);
		}

		public List<Descriptor> GetDescriptors(BuildingDef def)
		{
			return (List<Descriptor>)null;
		}

		private void OnChangeAllowManualPumpingStationFetching()
		{
			this.allowManualPumpingStationFetching = !this.allowManualPumpingStationFetching;
			this.smi.RefreshChore();
		}

		private void OnRefreshUserMenu(object data)
		{
			Game.Instance.userMenu.AddButton(this.gameObject, !this.allowManualPumpingStationFetching ?
				new KIconButtonMenu.ButtonInfo("action_bottler_delivery", (string)UI.USERMENUACTIONS.MANUAL_PUMP_DELIVERY.ALLOWED.NAME, new System.Action(this.OnChangeAllowManualPumpingStationFetching), Action.NumActions,
				(System.Action<GameObject>)null, (System.Action<KIconButtonMenu.ButtonInfo>)null, (Texture)null, (string)UI.USERMENUACTIONS.MANUAL_PUMP_DELIVERY.ALLOWED.TOOLTIP, true)
				: new KIconButtonMenu.ButtonInfo("action_bottler_delivery", (string)UI.USERMENUACTIONS.MANUAL_PUMP_DELIVERY.DENIED.NAME, new System.Action(this.OnChangeAllowManualPumpingStationFetching), Action.NumActions,
				(System.Action<GameObject>)null, (System.Action<KIconButtonMenu.ButtonInfo>)null, (Texture)null, (string)UI.USERMENUACTIONS.MANUAL_PUMP_DELIVERY.DENIED.TOOLTIP, true), 1f);
		}

		private void OnCopySettings(object data)
		{
			this.allowManualPumpingStationFetching = ((GameObject)data).GetComponent<VesselInserter>().allowManualPumpingStationFetching;
		}

		public class StatesInstance : GameStateMachine<VesselInserter.States, VesselInserter.StatesInstance, VesselInserter, object>.GameInstance
		{
			private FetchChore chore;

			public StatesInstance(VesselInserter smi)
			  : base(smi)
			{
				this.master.GetComponent<TreeFilterable>().OnFilterChanged += new System.Action<Tag[]>(this.OnFilterChanged);
				this.meter = new MeterController((KAnimControllerBase)this.GetComponent<KBatchedAnimController>(), "meter_target", nameof(meter), Meter.Offset.Infront, Grid.SceneLayer.NoLayer, new string[3]
				{
		"meter_target",
		"meter_arrow",
		"meter_scale"
				});
				this.Subscribe(-1697596308, new System.Action<object>(this.OnStorageChange));
			}

			public MeterController meter { get; private set; }

			public void CreateChore()
			{
				KBatchedAnimController component1 = this.GetComponent<KBatchedAnimController>();
				Tag[] tags = this.GetComponent<TreeFilterable>().GetTags();
				if (tags == null || tags.Length == 0)
				{
					component1.TintColour = (Color32)this.master.noFilterTint;
				}
				else
				{
					component1.TintColour = (Color32)this.master.filterTint;
					Tag[] forbidden_tags;
					if (!this.master.allowManualPumpingStationFetching)
						forbidden_tags = new Tag[1]
						{
							GameTags.LiquidSource
						};
					else
						forbidden_tags = new Tag[0];
					Storage component2 = this.GetComponent<Storage>();
					this.chore = new FetchChore(Db.Get().ChoreTypes.StorageFetch, component2, component2.Capacity(), this.GetComponent<TreeFilterable>().GetTags(),
						(Tag[])null, forbidden_tags, (ChoreProvider)null, true, (System.Action<Chore>)null, (System.Action<Chore>)null, (System.Action<Chore>)null,
						FetchOrder2.OperationalRequirement.Operational, 0);
				}
			}

			public void CancelChore()
			{
				if (this.chore == null)
					return;
				this.chore.Cancel("Storage Changed");
				this.chore = (FetchChore)null;
			}

			public void RefreshChore()
			{
				this.GoTo((StateMachine.BaseState)this.sm.unoperational);
			}

			private void OnFilterChanged(Tag[] tags)
			{
				this.RefreshChore();
			}

			private void OnStorageChange(object data)
			{
				Storage component = this.GetComponent<Storage>();
				this.meter.SetPositionPercent(Mathf.Clamp01(component.MassStored() / component.capacityKg));
			}

			//public void StartMeter()
			//{
			//	PrimaryElement firstPrimaryElement = this.GetFirstPrimaryElement();
			//	if ((UnityEngine.Object)firstPrimaryElement == (UnityEngine.Object)null)
			//		return;
			//	this.meter.SetSymbolTint(new KAnimHashedString("meter_fill"), firstPrimaryElement.Element.substance.colour);
			//	this.meter.SetSymbolTint(new KAnimHashedString("water1"), firstPrimaryElement.Element.substance.colour);
			//	this.GetComponent<KBatchedAnimController>().SetSymbolTint(new KAnimHashedString("leak_ceiling"), (Color)firstPrimaryElement.Element.substance.colour);
			//}

			private PrimaryElement GetFirstPrimaryElement()
			{
				Storage component1 = this.GetComponent<Storage>();
				for (int index = 0; index < component1.Count; ++index)
				{
					GameObject gameObject = component1[index];
					if (!((UnityEngine.Object)gameObject == (UnityEngine.Object)null))
					{
						PrimaryElement component2 = gameObject.GetComponent<PrimaryElement>();
						if (!((UnityEngine.Object)component2 == (UnityEngine.Object)null))
							return component2;
					}
				}
				return (PrimaryElement)null;
			}

			public void Emit(float dt)
			{
				//do nothing.
			}

		}

		public class States : GameStateMachine<VesselInserter.States, VesselInserter.StatesInstance, VesselInserter>
		{
			private StatusItem statusItem;
			public GameStateMachine<VesselInserter.States, VesselInserter.StatesInstance, VesselInserter, object>.State unoperational;
			public GameStateMachine<VesselInserter.States, VesselInserter.StatesInstance, VesselInserter, object>.State waitingfordelivery;
			public GameStateMachine<VesselInserter.States, VesselInserter.StatesInstance, VesselInserter, object>.State emptying;

			public override void InitializeStates(out StateMachine.BaseState default_state)
			{
				default_state = (StateMachine.BaseState)this.waitingfordelivery;
				this.statusItem = new StatusItem(nameof(VesselInserter), string.Empty, string.Empty, string.Empty, StatusItem.IconType.Info, NotificationType.Neutral, false, OverlayModes.None.ID, 129022);
				this.statusItem.resolveStringCallback = (Func<string, object, string>)((str, data) =>
				{
					VesselInserter bottleEmptier = (VesselInserter)data;
					if ((UnityEngine.Object)bottleEmptier == (UnityEngine.Object)null)
						return str;
					if (bottleEmptier.allowManualPumpingStationFetching)
						return (string)BUILDING.STATUSITEMS.BOTTLE_EMPTIER.ALLOWED.NAME;
					return (string)BUILDING.STATUSITEMS.BOTTLE_EMPTIER.DENIED.NAME;
				});
				this.statusItem.resolveTooltipCallback = (Func<string, object, string>)((str, data) =>
				{
					VesselInserter bottleEmptier = (VesselInserter)data;
					if ((UnityEngine.Object)bottleEmptier == (UnityEngine.Object)null)
						return str;
					if (bottleEmptier.allowManualPumpingStationFetching)
						return (string)BUILDING.STATUSITEMS.BOTTLE_EMPTIER.ALLOWED.TOOLTIP;
					return (string)BUILDING.STATUSITEMS.BOTTLE_EMPTIER.DENIED.TOOLTIP;
				});
				this.root.ToggleStatusItem(this.statusItem, (Func<VesselInserter.StatesInstance, object>)(smi => (object)smi.master));
				this.unoperational.TagTransition(GameTags.Operational, this.waitingfordelivery, false).PlayAnim("off");
				this.waitingfordelivery.TagTransition(GameTags.Operational, this.unoperational, true)
					.EventTransition(GameHashes.OnStorageChange, this.emptying, (StateMachine<VesselInserter.States, VesselInserter.StatesInstance, VesselInserter, object>.Transition.ConditionCallback)
						(smi => smi.GetComponent<Storage>().MassStored() != 0))
					.Enter("CreateChore", (StateMachine<VesselInserter.States, VesselInserter.StatesInstance, VesselInserter, object>.State.Callback)(smi => smi.CreateChore()))
					.Exit("CancelChore", (StateMachine<VesselInserter.States, VesselInserter.StatesInstance, VesselInserter, object>.State.Callback)(smi => smi.CancelChore()))
					.PlayAnim("on");
				this.emptying.TagTransition(GameTags.Operational, this.unoperational, true)
					.EventTransition(GameHashes.OnStorageChange, this.waitingfordelivery,
						(StateMachine<VesselInserter.States, VesselInserter.StatesInstance, VesselInserter, object>.Transition.ConditionCallback)
						(smi => smi.GetComponent<Storage>().MassStored() == 0));
				//.Enter("StartMeter", (StateMachine<VesselInserter.States, VesselInserter.StatesInstance, VesselInserter, object>.State.Callback)
				//	(smi => smi.SetStorageZeroes()));
				//.Update("Emit", (System.Action<VesselInserter.StatesInstance, float>)
				//	((smi, dt) => smi.Emit(dt)), UpdateRate.SIM_200ms, false).PlayAnim("working_loop", KAnim.PlayMode.Loop);
			}
		}
	}
}
