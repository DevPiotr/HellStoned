using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test.Core{

    public interface IState<T> {

        void InitState(T controller);
        void UpdateState(T controller);
        void DeinitState(T controller);

    }
}