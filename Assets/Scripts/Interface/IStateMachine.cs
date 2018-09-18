using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test.Core{

    public interface IStateMachine<T>{

        void ChangeState(IState<T> newState);
        void UpdateState();
    }
}