using UnityEngine;
using HellStoned.Core;

namespace HellStoned.UI
{
    public class UIGameHistoryViewController : MonoBehaviour
    {
        public IMenuState listener;

        private void Update()
        {
            if (Input.anyKeyDown)
            {
                listener.GoToMenuFromHistory();
            }
        }
    }
}
