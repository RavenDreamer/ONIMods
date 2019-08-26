//// Decompiled with JetBrains decompiler
//// Type: StorageLocker
//// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
//// MVID: C4FA4E6F-758D-4D97-B8F6-20B31F856ED3
//// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

//using KSerialization;
//using UnityEngine;

//public class StorageButGases : KMonoBehaviour, IUserControlledCapacity
//{
//	private static readonly EventSystem.IntraObjectHandler<StorageButGases> OnCopySettingsDelegate = new EventSystem.IntraObjectHandler<StorageButGases>((System.Action<StorageButGases, object>)((component, data) => component.OnCopySettings(data)));
//	[Serialize]
//	private float userMaxCapacity = float.PositiveInfinity;
//	[Serialize]
//	public string lockerName = string.Empty;
//	private LoggerFS log;
//	protected FilteredStorage filteredStorage;

//	protected override void OnPrefabInit()
//	{
//		this.Initialize(false);
//	}

//	protected void Initialize(bool use_logic_meter)
//	{
//		base.OnPrefabInit();
//		this.log = new LoggerFS(nameof(StorageButGases), 35);
//		this.filteredStorage = new FilteredStorage((KMonoBehaviour)this, (Tag[])null, (Tag[])null, (IUserControlledCapacity)this, use_logic_meter, Db.Get().ChoreTypes.StorageFetch);
//		this.Subscribe<StorageButGases>(-905833192, StorageButGases.OnCopySettingsDelegate);
//	}

//	protected override void OnSpawn()
//	{
//		this.filteredStorage.FilterChanged();
//		if (this.lockerName.IsNullOrWhiteSpace())
//			return;
//		this.SetName(this.lockerName);
//	}

//	protected override void OnCleanUp()
//	{
//		this.filteredStorage.CleanUp();
//	}

//	private void OnCopySettings(object data)
//	{
//		GameObject gameObject = (GameObject)data;
//		if ((UnityEngine.Object)gameObject == (UnityEngine.Object)null)
//			return;
//		StorageButGases component = gameObject.GetComponent<StorageButGases>();
//		if ((UnityEngine.Object)component == (UnityEngine.Object)null)
//			return;
//		this.UserMaxCapacity = component.UserMaxCapacity;
//	}

//	public virtual float UserMaxCapacity
//	{
//		get
//		{
//			return Mathf.Min(this.userMaxCapacity, this.GetComponent<Storage>().capacityKg);
//		}
//		set
//		{
//			this.userMaxCapacity = value;
//			this.filteredStorage.FilterChanged();
//		}
//	}

//	public float AmountStored
//	{
//		get
//		{
//			return this.GetComponent<Storage>().MassStored();
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
//			return this.GetComponent<Storage>().capacityKg;
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

//	public void SetName(string name)
//	{
//		KSelectable component = this.GetComponent<KSelectable>();
//		this.name = name;
//		this.lockerName = name;
//		if ((UnityEngine.Object)component != (UnityEngine.Object)null)
//			component.SetName(name);
//		this.gameObject.name = name;
//		NameDisplayScreen.Instance.UpdateName(this.gameObject);
//	}
//}
