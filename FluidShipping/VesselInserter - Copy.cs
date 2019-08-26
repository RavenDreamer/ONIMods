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
	//[SerializationConfig(MemberSerialization.OptIn)]
	//public class VesselInserter : KMonoBehaviour
	//{

	//	private static readonly EventSystem.IntraObjectHandler<VesselInserter> OnOperationalChangedDelegate = new EventSystem.IntraObjectHandler<VesselInserter>((System.Action<VesselInserter, object>)((component, data) => component.OnOperationalChanged(data)));
	//	private static readonly EventSystem.IntraObjectHandler<VesselInserter> OnCopySettingsDelegate = new EventSystem.IntraObjectHandler<VesselInserter>((System.Action<VesselInserter, object>)((component, data) => component.OnCopySettings(data)));
	//	[Serialize]
	//	private float userMaxCapacity = float.PositiveInfinity;
	//	[MyCmpReq]
	//	private Storage storage;
	//	private FilteredStorage filteredStorage;

	//	protected override void OnPrefabInit()
	//	{
	//		this.filteredStorage = new FilteredStorage((KMonoBehaviour)this, null, null, null, false, Db.Get().ChoreTypes.StorageFetch);
	//		this.Subscribe<VesselInserter>(-592767678, VesselInserter.OnOperationalChangedDelegate);
	//		this.Subscribe<VesselInserter>(-905833192, VesselInserter.OnCopySettingsDelegate);
	//		//WorldInventory.Instance.Discover("FieldRation".ToTag(), GameTags.Edible);
	//	}

	//	protected override void OnSpawn()
	//	{
	//		Operational component = this.GetComponent<Operational>();
	//		component.SetActive(component.IsOperational, false);
	//		this.filteredStorage.FilterChanged();
	//	}

	//	protected override void OnCleanUp()
	//	{
	//		this.filteredStorage.CleanUp();
	//	}

	//	private void OnOperationalChanged(object data)
	//	{
	//		Operational component = this.GetComponent<Operational>();
	//		component.SetActive(component.IsOperational, false);
	//	}

	//	private void OnCopySettings(object data)
	//	{
	//		GameObject gameObject = (GameObject)data;
	//		if ((UnityEngine.Object)gameObject == (UnityEngine.Object)null)
	//			return;
	//		RationBox component = gameObject.GetComponent<RationBox>();
	//		if ((UnityEngine.Object)component == (UnityEngine.Object)null)
	//			return;
	//		//this.UserMaxCapacity = component.UserMaxCapacity;
	//	}

	//	//public void Render1000ms(float dt)
	//	//{
	//	//	Rottable.SetStatusItems(this.GetComponent<KSelectable>(), Rottable.IsRefrigerated(this.gameObject), Rottable.AtmosphereQuality(this.gameObject));
	//	//}

	//	//public float UserMaxCapacity
	//	//{
	//	//	get
	//	//	{
	//	//		return Mathf.Min(this.userMaxCapacity, this.storage.capacityKg);
	//	//	}
	//	//	set
	//	//	{
	//	//		this.userMaxCapacity = value;
	//	//		this.filteredStorage.FilterChanged();
	//	//	}
	//	//}

	//	public float AmountStored
	//	{
	//		get
	//		{
	//			return this.storage.MassStored();
	//		}
	//	}

	//	public float MinCapacity
	//	{
	//		get
	//		{
	//			return 0.0f;
	//		}
	//	}

	//	public float MaxCapacity
	//	{
	//		get
	//		{
	//			return this.storage.capacityKg;
	//		}
	//	}

	//	public bool WholeValues
	//	{
	//		get
	//		{
	//			return false;
	//		}
	//	}

	//	public LocString CapacityUnits
	//	{
	//		get
	//		{
	//			return GameUtil.GetCurrentMassUnit(false);
	//		}
	//	}

	//}
}
