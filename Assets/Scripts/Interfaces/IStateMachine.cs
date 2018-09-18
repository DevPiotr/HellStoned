using UnityEngine;
namespace HellStoned.Core {
    public interface IStateMachine<T> {

        void ChangeState(IState<T> newState);
        void UpdateState();
    }
}
