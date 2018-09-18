using UnityEngine;
using HellStoned.Core;

namespace HellStoned.UI
{
    public class UIPauseViewController : MonoBehaviour
    {
        public IPauseState listener;

        public void onResumeButtonClick()
        {
            listener.onResumeButton();
        }
        public void onQuitButtonClick()
        {
            listener.onQuitButton();
        }
    }
}
