using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Test.Core;

namespace Test.State{

    public class MenuState : BaseState {

        public IMenuListener listener;

    	public override void InitState(Test.Core.GameController controller)
        {
            base.InitState(controller);
            Debug.LogWarning("MenuState :: Im in menu Init");
        }

        public override void UpdateState(Test.Core.GameController controller)
        {
            base.UpdateState(controller);
            Debug.LogWarning("MenuState :: Im in menu Update");
        }

        public override void DeinitState(Test.Core.GameController controller)
        {
            base.DeinitState(controller);
            Debug.LogWarning("MenuState :: Im in menu Deinit");
            listener.OnDeinitState();
        }
    }
}