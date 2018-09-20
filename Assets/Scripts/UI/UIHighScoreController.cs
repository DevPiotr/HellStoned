using UnityEngine;
using UnityEngine.UI;
using HellStoned.Core;

namespace HellStoned.UI
{
    public class UIHighScoreController : MonoBehaviour
    {
        public IMenuState listener;

        public void OnBackButtonClick()
        {
            listener.OnHighScoreBackButton();
        }

    }
}
