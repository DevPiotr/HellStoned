using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test.State{

    public class GameState : BaseState{

    	public override void InitState(Test.Core.GameController controller)
        {
            base.InitState(controller);
            Debug.LogWarning("GameState :: Im in game Init");
        }

        public override void UpdateState(Test.Core.GameController controller)
        {
            base.UpdateState(controller);
            Debug.LogWarning("GameState :: Im in game Update");
        }

        public override void DeinitState(Test.Core.GameController controller)
        {
            base.DeinitState(controller);
            Debug.LogWarning("GameState :: Im in game Deinit");
        }
    }
}