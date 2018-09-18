using UnityEngine;
using HellStoned.Core;

namespace HellStoned.State
{
    public class BaseState : IState<GameController>
    {
        #region IState implementation

        public virtual void InitState(GameController controller)
        {
            Debug.Log("BaseState :: Init state");
        }

        public virtual void UpdateState(GameController controller)
        {
            Debug.Log("BaseState :: Update state");
        }

        public virtual void DeinitState(GameController controller)
        {
            Debug.Log("BaseState :: Deinit state");
        }
        #endregion
    }
}