using UnityEngine;
using HellStoned.Core;

namespace HellStoned.UI
{
    public class UIPauseViewController : MonoBehaviour
    {
        public IGameState listener;

        public void OnResumeButtonClick()
        {
            listener.OnResumeButton();
        }
        public void OnQuitButtonClick()
        {
            listener.OnQuitButton();
        }
    }
}
