using UnityEngine;
using UnityEngine.UI;
using HellStoned.Core;
using TMPro;

namespace HellStoned.UI
{
    public class UIHighScoreController : MonoBehaviour
    {
        public IMenuState listener;

        [SerializeField]

        private TextMeshProUGUI[] scores;
        public TextMeshProUGUI[] Scores { get { return this.scores; } }

        public void OnBackButtonClick()
        {
            listener.OnHighScoreBackButton();
        }

    }
}
