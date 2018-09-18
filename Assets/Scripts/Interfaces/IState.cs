using UnityEngine;
namespace HellStoned.Core
{
    public interface IState<T>
    {

        void InitState(T controller);
        void UpdateState(T controller);
        void DeinitState(T controller);
    }
}