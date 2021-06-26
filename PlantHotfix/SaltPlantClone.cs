using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantHotfix
{

	public class SaltPlantClone : StateMachineComponent<SaltPlantClone.StatesInstance>
	{
		private static readonly EventSystem.IntraObjectHandler<SaltPlantClone> OnWiltDelegate = new EventSystem.IntraObjectHandler<SaltPlantClone>((Action<SaltPlantClone, object>)((component, data) => component.OnWilt(data)));
		private static readonly EventSystem.IntraObjectHandler<SaltPlantClone> OnWiltRecoverDelegate = new EventSystem.IntraObjectHandler<SaltPlantClone>((Action<SaltPlantClone, object>)((component, data) => component.OnWiltRecover(data)));

		private int wiltCounter = 0;

		protected override void OnSpawn()
		{
			base.OnSpawn();
			this.Subscribe<SaltPlantClone>(-724860998, SaltPlantClone.OnWiltDelegate);
			this.Subscribe<SaltPlantClone>(712767498, SaltPlantClone.OnWiltRecoverDelegate);
		}

		private void OnWilt(object data = null)
		{
			wiltCounter++;
			this.gameObject.GetComponent<ElementConsumer>().EnableConsumption(false);
		}

		private void OnWiltRecover(object data = null)
		{
			wiltCounter--;
			if (wiltCounter == 0)
			{
				this.gameObject.GetComponent<ElementConsumer>().EnableConsumption(true);
			}
		}

		public class StatesInstance : GameStateMachine<SaltPlantClone.States, SaltPlantClone.StatesInstance, SaltPlantClone, object>.GameInstance
		{
			public StatesInstance(SaltPlantClone master)
			  : base(master)
			{
			}
		}

		public class States : GameStateMachine<SaltPlantClone.States, SaltPlantClone.StatesInstance, SaltPlantClone>
		{
			public GameStateMachine<SaltPlantClone.States, SaltPlantClone.StatesInstance, SaltPlantClone, object>.State alive;

			public override void InitializeStates(out StateMachine.BaseState default_state)
			{
				this.serializable = StateMachine.SerializeType.Both_DEPRECATED;
				default_state = (StateMachine.BaseState)this.alive;
				this.alive.DoNothing();
			}
		}
	}

}
