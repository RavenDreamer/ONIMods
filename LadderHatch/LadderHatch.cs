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
			Grid.SetSolid(cell, true, CellEventLogger.Instance.SimCellOccupierSolidChanged);
			Game.Instance.SetDupePassableSolid(cell, true, false);
			SimMessages.ReplaceAndDisplaceElement(cell, SimHashes.Vacuum, CellEventLogger.Instance.DoorOpen, 0.0f, -1f, byte.MaxValue, 0, -1);
		}

		protected override void OnCleanUp()
		{
			base.OnCleanUp();
			int cell = Grid.PosToCell((KMonoBehaviour)this);
			Grid.SetSolid(cell, false, CellEventLogger.Instance.SimCellOccupierSolidChanged);
			Game.Instance.SetDupePassableSolid(cell, false, Grid.Solid[cell]);
		}
	}

}
