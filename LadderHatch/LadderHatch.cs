using STRINGS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TUNING;
using UnityEngine;
using BUILDINGS = TUNING.BUILDINGS;

namespace StormShark.OniMods
{
	public class LadderHatch : Ladder
	{
		protected override void OnPrefabInit()
		{
			base.OnPrefabInit();
		}

		protected override void OnSpawn()
		{
			base.OnSpawn();

			int cell = Grid.PosToCell((KMonoBehaviour)this);
			//Grid.SetSolid(cell, true, CellEventLogger.Instance.SimCellOccupierSolidChanged);
			Game.Instance.SetDupePassableSolid(cell, true, true);
			Grid.HasDoor[cell] = true;
			//Grid.HasAccessDoor[cell] = (UnityEngine.Object)this.GetComponent<AccessControl>() != (UnityEngine.Object)null;
			SimMessages.SetCellProperties(cell, (byte)8);
			Grid.FakeFloor[cell] = true;
			Pathfinding.Instance.AddDirtyNavGridCell(cell);
		}

		protected override void OnCleanUp()
		{
			base.OnCleanUp();
			int cell = Grid.PosToCell((KMonoBehaviour)this);
			//Grid.SetSolid(cell, false, CellEventLogger.Instance.SimCellOccupierSolidChanged);
			Game.Instance.SetDupePassableSolid(cell, false, Grid.Solid[cell]);
			Grid.FakeFloor[cell] = false;
			Grid.HasDoor[cell] = false;
			//Grid.HasAccessDoor[cell] = false;
			Game.Instance.SetDupePassableSolid(cell, false, Grid.Solid[cell]);
			Grid.CritterImpassable[cell] = false;
			Grid.DupeImpassable[cell] = false;
			Pathfinding.Instance.AddDirtyNavGridCell(cell);
		}
	}

}
