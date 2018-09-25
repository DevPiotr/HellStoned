using UnityEngine;
using HellStoned.Core;

namespace HellStoned.UI
{
    public class UILoseGameViewController : MonoBehaviour
    {

        public IMenuState listener;

        private void Update()
        {
            if (Input.anyKeyDown)
            {
                listener.BackToMenuFromLose();
            }
        }
    }
}