using UnityEngine;
using HellStoned.Core;

namespace HellStoned.UI
{
    public class UIMainMenuController : MonoBehaviour
    {

        public IMenuState listener;

        public void OnPlayButtonClick()
        {
            listener.OnPlayButton();
        }
        public void OnHighScoreButtonClick()
        {
            listener.OnHighScoreButton();
        }
        public void OnCreditsButtonClick()
        {
            listener.OnCreditsButton();
        }
        public void OnQuitButtonClick()
        {
            listener.OnQuitButton();
        }
    }
}
