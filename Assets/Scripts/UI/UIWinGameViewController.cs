using UnityEngine;
using TMPro;
using HellStoned.Core;
namespace HellStoned.UI
{
    public class UIWinGameViewController : MonoBehaviour
    {

        public IMenuState listener;

        [SerializeField]
        private TextMeshProUGUI score;
        public TextMeshProUGUI Score { get { return this.score; } }

        [SerializeField]
        private TextMeshProUGUI time;
        public TextMeshProUGUI Time { get { return this.time; } }

        public void OnBackButtonClick()
        {
            listener.OnWinGameViewBackButton();
        }
    }
}
