using UnityEngine;
using HellStoned.Core;

namespace HellStoned.State
{
    public class BaseState : IState<GameController>
    {
        #region IState implementation

        public virtual void InitState(GameController controller)
        {

        }

        public virtual void UpdateState(GameController controller)
        {

        }

        public virtual void DeinitState(GameController controller)
        {

        }
        #endregion
    }
}