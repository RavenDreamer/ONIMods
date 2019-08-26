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

	//	private FilteredStorage filteredStorage;
	//	private static readonly EventSystem.IntraObjectHandler<VesselInserter> OnOperationalChangedDelegate = new EventSystem.IntraObjectHandler<VesselInserter>((System.Action<VesselInserter, object>)((component, data) => component.OnOperationalChanged(data)));
	//	private static readonly EventSystem.IntraObjectHandler<VesselInserter> OnCopySettingsDelegate = new EventSystem.IntraObjectHandler<VesselInserter>((System.Action<VesselInserter, object>)((component, data) => component.OnCopySettings(data)));



	//	[SerializeField]
	//	public Color noFilterTint = (Color)FilteredStorage.NO_FILTER_TINT;
	//	[SerializeField]
	//	public Color filterTint = (Color)FilteredStorage.FILTER_TINT;
	//	protected override void OnPrefabInit()
	//	{
	//		base.OnPrefabInit();
	//		filteredStorage = new FilteredStorage(this, null, null, null, false, Db.Get().ChoreTypes.StorageFetch);
	//		this.Subscribe<VesselInserter>(-592767678, VesselInserter.OnOperationalChangedDelegate);
	//		this.Subscribe<VesselInserter>(-905833192, VesselInserter.OnCopySettingsDelegate);
	//		filteredStorage.filterTint = filterTint;
	//		filteredStorage.noFilterTint = noFilterTint;

	//	}

	//	protected override void OnSpawn()
	//	{
	//		base.OnSpawn();
	//		Operational component = this.GetComponent<Operational>();
	//		component.SetActive(component.IsOperational, false);
	//		this.filteredStorage.FilterChanged();
	//	}

	//	protected override void OnCleanUp()
	//	{
	//		this.filteredStorage.CleanUp();
	//		base.OnCleanUp();
	//	}

	//	private void OnOperationalChanged(object data)
	//	{
	//		Operational component = this.GetComponent<Operational>();
	//		component.SetActive(component.IsOperational, false);
	//	}

	//	private void OnCopySettings(object data)
	//	{

	//	}

	//}
}
